using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceApi.Entities;
using OnePieceApi.Enums;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Commands;

public class CreateUserCommand : IRequest<long>
{
    public UserRegisterDto Dto { get; set; }

    public CreateUserCommand(UserRegisterDto dto)
    {
        Dto = dto;
    }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.Dto);
        var userRole = await _dbContext.Roles.FirstAsync(x => x.RoleId == RoleId.User, cancellationToken);
        user.Roles.Add(userRole);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Dto.Password);
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}