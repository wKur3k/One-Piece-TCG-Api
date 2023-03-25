namespace OnePieceApi.Entities;

public class CardQuantity
{
    public long Id { get; set; }
    public byte Quantity { get; set; }
    public Card Card { get; set; }
}