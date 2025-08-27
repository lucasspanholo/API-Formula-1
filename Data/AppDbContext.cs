using API_Formula1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Formula1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    DbSet<Driver> Drivers { get; set; }
    DbSet<Team> Teams { get; set; }
    DbSet<Championship> Championships { get; set; }
}