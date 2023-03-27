using OnePieceApi.Entities.Enums;
using Attribute = OnePieceApi.Entities.Enums.Attribute;

namespace OnePieceApi.Entities;

public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Power { get; set; }
    public byte? Cost { get; set; }
    public Set Set { get; set; }
    public string SetNumber { get; set; }
    public int? Counter { get; set; }
    public List<Color> Colors { get; set; }
    public Attribute Attribute { get; set; }
    public Rarity Rarity { get; set; }
    public CardType CardType { get; set; }
    public List<Archetype> Archetypes { get; set; }
    public List<Effect> Effects { get; set; }
    public string Effect { get; set; }
    public Image Image { get; set; }
}