
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WNZland.Data;

public class NZWalksAuthDbContext : IdentityDbContext
{
public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
{

}
protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

var readerRoleId = "6db438f6-9747-4be6-8e62-8c3495771933";
var writerRoleId = "6db438f6-9747-4be6-8e62-8c3495771944";
    var roles = new List<IdentityRole>
    {
        new IdentityRole {Id = readerRoleId, ConcurrencyStamp = readerRoleId , Name = "Reader", NormalizedName = "Reader".ToUpper()},
        new IdentityRole {Id = writerRoleId, ConcurrencyStamp = writerRoleId , Name = "Writer", NormalizedName = "Writer".ToUpper()}
        
      
    };
      builder.Entity<IdentityRole>().HasData(roles);
}

}
