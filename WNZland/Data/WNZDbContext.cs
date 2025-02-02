using System;
using Microsoft.EntityFrameworkCore;
using WNZland.Models.Domain;
namespace WNZland.Data;

public class WNZDbContext : DbContext
{
    public WNZDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }



}
