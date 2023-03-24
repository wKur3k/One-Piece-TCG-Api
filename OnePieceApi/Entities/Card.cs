using OnePieceApi.Entities.Enums;
using OnePieceApi.Enums;
using Attribute = System.Attribute;

namespace OnePieceApi.Entities;

public class Card
{
    public int Id { get; set; }
    public int? Power { get; set; }
    public int? Cost { get; set; }
    //public Set Set { get; set; }
    public string SetNumber { get; set; }
    
    //counter
    
    //public List<Color> Colors { get; set; }
    //public Attribute Attribute { get; set; }
    //public Rarity Rarity { get; set; }
    //public CardType CardType { get; set; }
    public List<Archetype> Archetypes { get; set; }
    //public List<Effect> Effects { get; set; }
}