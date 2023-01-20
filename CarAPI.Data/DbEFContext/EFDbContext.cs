using CarAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Data.DbEFContext;

public class EFDbContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();

    public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db3.db");
    }
    
}