using Microsoft.EntityFrameworkCore;
using WNZland.Models.Domain;
namespace WNZland.Data;

public class WNZDbContext : DbContext
{
    public WNZDbContext(DbContextOptions<WNZDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var difficulties = new List<Difficulty>()
        {
            new Difficulty { Id = Guid.Parse("6db438f6-9747-4be6-8e62-8c34957719e1"), Name = "Easy" },
            new Difficulty { Id = Guid.Parse("67b2151d-b948-4a32-ab60-f8cbf48b1349"), Name = "Moderate" },
            new Difficulty { Id = Guid.Parse("1ed5deec-7b0c-441a-a7ea-a67d11864f77"), Name = "Hard" }
        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>()
        {
            new Region { Id = Guid.Parse("6db438f6-9747-4be6-8e62-8c34957719e3"), Name = "Northland",Code = "N" ,RegionImageUrl = "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-1.jpg"},
            new Region { Id = Guid.Parse("67b2151d-b948-4a32-ab60-f8cbf48b1343"), Name = "Auckland" ,Code = "A" ,RegionImageUrl = "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-2.jpg"},
            new Region { Id = Guid.Parse("1ed5deec-7b0c-441a-a7ea-a67d11864f73"), Name = "Waikato"  ,Code = "W" ,RegionImageUrl = "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-3.jpg"}
        };
        modelBuilder.Entity<Region>().HasData(regions);
    }

    

}
