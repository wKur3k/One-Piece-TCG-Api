using OnePieceApi.Enums;

namespace OnePieceApi.Entities.Enums;

public class Role
{
    public RoleId RoleId { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
}