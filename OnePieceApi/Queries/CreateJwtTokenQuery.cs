using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnePieceApi.Entities;
using OnePieceApi.Exceptions;
using OnePieceApi.Models.Dtos;
using OnePieceApi.Security;

namespace OnePieceApi.Queries;

public class CreateJwtTokenQuery : IRequest<string>
{
    public UserLoginDto Dto { get; set; }

    public CreateJwtTokenQuery(UserLoginDto dto)
    {
        Dto = dto;
    }
}

public class CreateJwtTokenQueryHandler : IRequestHandler<CreateJwtTokenQuery, string>
{
    private readonly AppDbContext _dbContext;
    private readonly AuthenticationSettings _authenticationSettings;

    public CreateJwtTokenQueryHandler(AppDbContext dbContext, AuthenticationSettings authenticationSettings)
    {
        _dbContext = dbContext;
        _authenticationSettings = authenticationSettings;
    }

    public async Task<string> Handle(CreateJwtTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Username == request.Dto.Username, cancellationToken: cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"Couldn't find user with username: {request.Dto.Username}");
        }
        if (!BCrypt.Net.BCrypt.Verify(request.Dto.Password, user.PasswordHash))
        {
            throw new BadRequestException("Wrong credentials.");
        }
        return CreateToken(user);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username), 
        };
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            audience: _authenticationSettings.JwtIssuer,
            issuer: _authenticationSettings.JwtIssuer,
            claims: claims,
            expires: DateTime.Now.AddHours(_authenticationSettings.JwtExpireHours),
            signingCredentials: cred);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}