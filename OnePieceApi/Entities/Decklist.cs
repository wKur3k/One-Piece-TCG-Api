using OnePieceApi.Entities.Enums;
using OnePieceApi.Enums;

namespace OnePieceApi.Entities;

public class Decklist
{
    public long Id { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
    public Visibility Visibility { get; set; }
    public List<CardQuantity> DecklistCardsList { get; set; }
}