using Microsoft.EntityFrameworkCore;
using BreakTheChains.DataAccess.Entities;
using System.Collections.Generic;
public class BreakTheChainsDBContext : DbContext
{
    public BreakTheChainsDBContext(DbContextOptions<BreakTheChainsDBContext> options) : base(options) { }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
}
