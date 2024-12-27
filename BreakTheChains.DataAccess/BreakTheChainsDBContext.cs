using Microsoft.EntityFrameworkCore;
using BreakTheChains.DataAccess.Entities;
public class BreakTheChainsDBContext : DbContext
{
    public BreakTheChainsDBContext(DbContextOptions<BreakTheChainsDBContext> options) : base(options) { }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Equipment> Equipment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add seed data
        modelBuilder.Entity<Character>().HasData(
            new Character { Id = 1, Name = "Kaneki Ken", Rarity = "SSR", Role = "DPS", Description = "Main protagonist" },
            new Character { Id = 2, Name = "Touka Kirishima", Rarity = "SR", Role = "Support", Description = "Ghoul ally" }
        );

        modelBuilder.Entity<Equipment>().HasData(
            new Equipment { Id = 1, Name = "Kagune Blade", Type = "Weapon", Effect = "Increases damage" },
            new Equipment { Id = 2, Name = "Healing Serum", Type = "Consumable", Effect = "Restores HP" }
        );
    }
}
