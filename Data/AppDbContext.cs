using API_Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Formula1.Data;

public class AppDbContext : DbContext
{
    //Database Implementation
    //PostgreSQL
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Championship> Championships { get; set; }
    public DbSet<Race> Races { get; set; }
}