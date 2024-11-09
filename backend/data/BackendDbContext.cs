using backend.data.entities;
using Microsoft.EntityFrameworkCore;

namespace backend.data;

public class BackendDbContext: DbContext
{
    public DbSet<Polls> Polls { get; set; }
    public DbSet<Votes> Votes { get; set; }
    public DbSet<Options> Options { get; set; }
    private readonly IConfiguration _configuration;

    public BackendDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySQL(connectionString);
    }
}