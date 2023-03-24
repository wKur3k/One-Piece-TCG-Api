using OnePieceApi.Entities.Enums;

namespace OnePieceApi.Entities;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public string Username { get; set; }
    public List<Role> Roles { get; set; }
}