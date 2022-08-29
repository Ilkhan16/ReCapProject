using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class ReCapDB : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=ReCapDB;Trusted_connection=true");
    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<Color>? Colors { get; set; }
    public DbSet<Brand>? Brands { get; set; }
}