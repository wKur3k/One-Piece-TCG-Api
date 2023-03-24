using OnePieceApi.Enums;

namespace OnePieceApi.Entities.Enums;

public class Archetype
{
    public ArchetypeId ArchetypeId { get; set; }
    public string Name { get; set; }
    public List<Card> Cards { get; set; }
}