using Microsoft.EntityFrameworkCore;
using OnePieceApi.Entities.Enums;
using OnePieceApi.Enums;
using Attribute = OnePieceApi.Entities.Enums.Attribute;

namespace OnePieceApi.Entities;

public class AppDbContext : DbContext
{
    private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=OnePieceDb;Trusted_Connection=True";
    
    //public DbSet<User> Users { get; set; }
    //public DbSet<Decklist> Decklists { get; set; }
    public DbSet<Card> Cards { get; set; }
    //public DbSet<DecklistCards> DecklistCards { get; set; }
    //Enums
    public DbSet<Archetype> Archetypes { get; set; }
    //public DbSet<Attribute> Attributes { get; set; }
    //public DbSet<CardType> CardTypes { get; set; }
    //public DbSet<Color> Colors { get; set; }
    //public DbSet<Effect> Effects { get; set; }
    //public DbSet<Rarity> Rarities { get; set; }
    //public DbSet<Role> Roles { get; set; }
    //public DbSet<Set> Sets { get; set; }
    //public DbSet<Visibility> Visibilities { get; set; }

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

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}