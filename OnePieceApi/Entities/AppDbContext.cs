using Microsoft.EntityFrameworkCore;
using OnePieceApi.Entities.Enums;
using OnePieceApi.Enums;
using Attribute = OnePieceApi.Entities.Enums.Attribute;

namespace OnePieceApi.Entities;

public class AppDbContext : DbContext
{

    private string _connectionString = "Server=localhost;Database=OnePieceDb;Trusted_Connection=True;TrustServerCertificate=True";
    
    public DbSet<User> Users { get; set; }
    public DbSet<Decklist> Decklists { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardQuantity> DecklistCards { get; set; }
    //Enums
    public DbSet<Archetype> Archetypes { get; set; }
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<Rarity> Rarities { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Set> Sets { get; set; }
    public DbSet<Visibility> Visibilities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Archetype>().HasData(
                Enum.GetValues(typeof(ArchetypeId))
                    .Cast<ArchetypeId>()
                    .Select(e => new Archetype()
                    {
                        ArchetypeId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Color>().HasData(
                Enum.GetValues(typeof(ColorId))
                    .Cast<ColorId>()
                    .Select(e => new Color()
                    {
                        ColorId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Effect>().HasData(
                Enum.GetValues(typeof(EffectId))
                    .Cast<EffectId>()
                    .Select(e => new Effect()
                    {
                        EffectId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Set>().HasData(
                Enum.GetValues(typeof(SetId))
                    .Cast<SetId>()
                    .Select(e => new Set()
                    {
                        SetId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Attribute>().HasData(
                Enum.GetValues(typeof(AttributeId))
                    .Cast<AttributeId>()
                    .Select(e => new Attribute()
                    {
                        AttributeId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Rarity>().HasData(
                Enum.GetValues(typeof(RarityId))
                    .Cast<RarityId>()
                    .Select(e => new Rarity()
                    {
                        RarityId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<CardType>().HasData(
                Enum.GetValues(typeof(CardTypeId))
                    .Cast<CardTypeId>()
                    .Select(e => new CardType()
                    {
                        CardTypeId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Role>().HasData(
                Enum.GetValues(typeof(RoleId))
                    .Cast<RoleId>()
                    .Select(e => new Role()
                    {
                        RoleId = e,
                        Name = e.ToString()
                    }));
        modelBuilder
            .Entity<Visibility>().HasData(
                Enum.GetValues(typeof(VisibilityId))
                    .Cast<VisibilityId>()
                    .Select(e => new Visibility()
                    {
                        VisibilityId = e,
                        Name = e.ToString()
                    }));
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}