using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnePieceApi.Models;
using OnePieceApi.Models.Dtos;
using OnePieceApi.Queries;

namespace OnePieceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles="User")]
public class CardController : ControllerBase
{
    private readonly IMediator _mediator;

    public CardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    [Produces(typeof(CardDetailsDto))]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        return Ok(await _mediator.Send(new GetCardByIdQuery(id)));
    }

    [HttpGet]
    [Produces(typeof(PagedResult<CardDto>))]
    public async Task<IActionResult> GetByFilter([FromQuery] CardsFilterDto filterDto)
    {
        return Ok(await _mediator.Send(new GetCardsByFilterQuery(filterDto)));
    }
}