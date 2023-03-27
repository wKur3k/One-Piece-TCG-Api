using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnePieceApi.Entities;
using OnePieceApi.Models;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Queries;

public class GetCardsByFilterQuery : IRequest<PagedResult<CardDto>>
{
    public CardsFilterDto Filter { get; set; }

    public GetCardsByFilterQuery(CardsFilterDto filter)
    {
        Filter = filter;
    }
}

public class GetCardsByFilterQueryHandler : IRequestHandler<GetCardsByFilterQuery, PagedResult<CardDto>>
{
    private readonly string _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCardsByFilterQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PagedResult<CardDto>> Handle(GetCardsByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Cards.Include(x => x.Set).Include(x => x.Colors)
            .Include(x => x.Attribute).Include(x => x.Rarity).Include(x => x.CardType)
            .Include(x => x.Archetypes).Include(x => x.Effects).AsQueryable();
        if (request.Filter.Filter is not null)
        {
            query = query.Where(x => 
                (request.Filter.Filter.Name == null || EF.Functions.Like(x.Name, request.Filter.Filter.Name)) &&
                (request.Filter.Filter.SetNumber == null || EF.Functions.Like(x.Name, request.Filter.Filter.SetNumber)) &&
                (request.Filter.Filter.Effect == null || EF.Functions.Like(x.Name, request.Filter.Filter.Effect)) &&
                (request.Filter.Filter.PowerMin.HasValue || x.Power >= request.Filter.Filter.PowerMin) &&
                (request.Filter.Filter.PowerMax.HasValue || x.Power <= request.Filter.Filter.PowerMin) &&
                (request.Filter.Filter.CostMin.HasValue || x.Power >= request.Filter.Filter.CostMin) &&
                (request.Filter.Filter.CostMax.HasValue || x.Power <= request.Filter.Filter.CostMax) &&
                (request.Filter.Filter.Sets.IsNullOrEmpty() || request.Filter.Filter.Sets.Any(setId => x.Set.SetId == setId)) &&
                (request.Filter.Filter.Counters.IsNullOrEmpty() || request.Filter.Filter.Counters.Any(counter => x.Counter == counter)) &&
                (request.Filter.Filter.Colors.IsNullOrEmpty() || request.Filter.Filter.Colors.Any(colorId => x.Colors.Any(c => c.ColorId == colorId))) &&
                (request.Filter.Filter.Attribute.IsNullOrEmpty() || request.Filter.Filter.Attribute.Any(attributeId => x.Attribute.AttributeId == attributeId)) &&
                (request.Filter.Filter.Rarity.IsNullOrEmpty() || request.Filter.Filter.Rarity.Any(rarityId => x.Rarity.RarityId == rarityId)) &&
                (request.Filter.Filter.CardType.IsNullOrEmpty() || request.Filter.Filter.CardType.Any(cardTypeId => x.CardType.CardTypeId == cardTypeId)) &&
                (request.Filter.Filter.Archetypes.IsNullOrEmpty() || request.Filter.Filter.Archetypes.Any(archetypeId => x.Archetypes.Any(c => c.ArchetypeId == archetypeId))) &&
                (request.Filter.Filter.Effects.IsNullOrEmpty() || request.Filter.Filter.Effects.Any(effectId => x.Effects.Any(c => c.EffectId == effectId))))
                .AsQueryable();
        }
        
        var cards = await query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => new CardDto()
            {
                CardId = x.Id,
                Image = x.Image.ImageB64
            })
            .ToListAsync(cancellationToken);
        
        return new PagedResult<CardDto>(cards, query.Count(), request.Filter.PageSize, request.Filter.PageNumber);
    }
}