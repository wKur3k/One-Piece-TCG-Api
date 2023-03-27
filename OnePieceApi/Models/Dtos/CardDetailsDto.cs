namespace OnePieceApi.Models.Dtos;

public class CardDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Power { get; set; }
    public byte? Cost { get; set; }
    public string Set { get; set; }
    public string SetNumber { get; set; }
    public int? Counter { get; set; }
    public List<string> Colors { get; set; }
    public string Attribute { get; set; }
    public string Rarity { get; set; }
    public string CardType { get; set; }
    public List<string> Archetypes { get; set; }
    public List<string> Effects { get; set; }
    public string Effect { get; set; }
    public string ImageB64 { get; set; }
}