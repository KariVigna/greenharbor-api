using Microsoft.EntityFrameworkCore;

namespace GreenHarborApi.Models
{
  public class GreenHarborApiContext : DbContext
  {
    public DbSet<Compost> Composts { get; set; }

    public GreenHarborApiContext(DbContextOptions<GreenHarborApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Compost>()
        .HasData(
          new Compost { CompostId = 1, Location = "Near road marker 43, by the red barn", ContactName = "", ContactPhone = "", ContactEmail = "", Contents = ""},
          new Compost { CompostId = 2, Location = "Past HR rd, end of the gravel driveway", ContactName = "", ContactPhone = "", ContactEmail = "", Contents = ""},
          new Compost { CompostId = 3, Location = "Middle of town, near the post office", ContactName = "", ContactPhone = "", ContactEmail = "", Contents = ""}
        );
      }
  }
}