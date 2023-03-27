using OnePieceApi.Enums;

namespace OnePieceApi.Models.Dtos;

public class CardsFilterDto
{
    public int PageSize { get; set; } = 20;
    public int PageNumber { get; set; } = 1;
    public CardsFilter? Filter { get; set; }
    public class CardsFilter
    {
        public string? Name { get; set; } = null;
        public string? SetNumber { get; set; } = null;
        public string? Effect { get; set; } = null;
        public int? PowerMin { get; set; } = null;
        public int? PowerMax { get; set; } = null;
        public byte? CostMin { get; set; } = null;
        public byte? CostMax { get; set; } = null;
        public List<SetId>? Sets { get; set; } = null;
        public List<int>? Counters { get; set; } = null;
        public List<ColorId>? Colors { get; set; }  = null;
        public List<AttributeId>? Attribute { get; set; }  = null;
        public List<RarityId>? Rarity { get; set; }  = null;
        public List<CardTypeId>? CardType { get; set; }  = null;
        public List<ArchetypeId>? Archetypes { get; set; }  = null;
        public List<EffectId>? Effects { get; set; }  = null;
    }
}
