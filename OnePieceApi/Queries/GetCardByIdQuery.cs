using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceApi.Entities;
using OnePieceApi.Exceptions;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Queries;

public class GetCardByIdQuery : IRequest<CardDetailsDto>
{
    public long CardId { get; set; }

    public GetCardByIdQuery(long cardId)
    {
        CardId = cardId;
    }
}

public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, CardDetailsDto>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCardByIdQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CardDetailsDto> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        var card = await _dbContext.Cards.Include(x => x.Set).Include(x => x.Colors)
            .Include(x => x.Attribute).Include(x => x.Rarity).Include(x => x.CardType)
            .Include(x => x.Archetypes).Include(x => x.Effects)
            .FirstOrDefaultAsync(x => x.Id == request.CardId, cancellationToken);
        if (card is null)
        {
            throw new NotFoundException($"Couldn't find card with Id {request.CardId}");
        }
        return _mapper.Map<CardDetailsDto>(card);
    }
}