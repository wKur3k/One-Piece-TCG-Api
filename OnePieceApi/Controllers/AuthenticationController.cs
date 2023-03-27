using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnePieceApi.Commands;
using OnePieceApi.Models.Dtos;
using OnePieceApi.Queries;

namespace OnePieceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto dto)
    {
        return Ok(await _mediator.Send(new CreateUserCommand(dto)));
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUser([FromBody] UserLoginDto dto)
    {
        return Ok(await _mediator.Send(new CreateJwtTokenQuery(dto)));
    }
}