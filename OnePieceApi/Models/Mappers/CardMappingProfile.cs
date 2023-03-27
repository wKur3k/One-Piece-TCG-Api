using AutoMapper;
using OnePieceApi.Entities;
using OnePieceApi.Models.Dtos;

namespace OnePieceApi.Models.Mappers;

public class CardMappingProfile : Profile
{
    public CardMappingProfile()
    {
        CreateMap<Card, CardDetailsDto>()
            .ForMember(x => x.Set,
                c => c.MapFrom(s => s.Set.Name))
            .ForMember(x => x.Attribute,
                c => c.MapFrom(s => s.Attribute.Name))
            .ForMember(x => x.Rarity,
                c => c.MapFrom(s => s.Rarity.Name))
            .ForMember(x => x.CardType,
                c => c.MapFrom(s => s.CardType.Name))
            .ForMember(x => x.Colors,
                c => c.MapFrom(s => s.Colors.Select(e => e.Name).ToList()))
            .ForMember(x => x.Archetypes,
                c => c.MapFrom(s => s.Archetypes.Select(e => e.Name).ToList()))
            .ForMember(x => x.Effects,
                c => c.MapFrom(s => s.Effects.Select(e => e.Name).ToList()))
            .ForMember(x => x.ImageB64,
                c => c.MapFrom(s => s.Image.ImageB64));
    }
}