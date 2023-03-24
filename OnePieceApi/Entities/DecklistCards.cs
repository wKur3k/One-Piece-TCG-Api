namespace OnePieceApi.Entities;

public class DecklistCards
{
    public long Id { get; set; }
    public byte Quantity { get; set; }
    public Card Card { get; set; }
}