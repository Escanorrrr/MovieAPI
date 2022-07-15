using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class MovieContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=MovieData;Username=postgres;Password=147258");

    public DbSet<Movie> mytable { get; set; }
    public DbSet<Login> Logins  { get; set; }
}