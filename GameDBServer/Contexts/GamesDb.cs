namespace Users.gRPC.Server.Contexts;
using Microsoft.EntityFrameworkCore;

/*

 */
public sealed class GamesDb : DbContext
{
    public DbSet<GamesHolder.Game> Games => Set<GamesHolder.Game>();
    
    
    public GamesDb() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder
            .UseSqlServer(@"Server=localhost,1433;Database=GamesBase;Trusted_Connection=False;User ID=sa;Password=Pa55w0rd");
}