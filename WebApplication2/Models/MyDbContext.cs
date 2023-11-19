namespace WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Earthquake> Earthquakes { get; set; }
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
}

