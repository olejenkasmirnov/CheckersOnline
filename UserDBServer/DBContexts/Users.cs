using Authenticator;
using Microsoft.EntityFrameworkCore;

namespace CryptoServer.DBContexts;

public sealed class UsersDb : DbContext
{
    public DbSet<PersonalData> Users => Set<PersonalData>();

    private readonly string connectionString =
        "Server=localhost,1433;Database=UsersDB;Trusted_Connection=False;User ID=sa;Password=Pa55w0rd";
     
    public UsersDb()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}