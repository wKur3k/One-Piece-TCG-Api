using OnePieceApi.Entities.Enums;

namespace OnePieceApi.Entities;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; } = false;
    public string Username { get; set; }
    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Decklist> Decklists { get; set; } = new List<Decklist>();
    public List<CardQuantity> Collection { get; set; } = new List<CardQuantity>();
}