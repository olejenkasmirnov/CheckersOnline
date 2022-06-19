using Authenticator;

namespace Users.gRPC.Server.Contexts;
using Microsoft.EntityFrameworkCore;

/*

 */
public sealed class UsersDb : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public DbSet<PersonalData> Users => Set<PersonalData>();
    
    
    public UsersDb() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder
            .UseSqlServer(@"Server=localhost,1433;Database=UsersBase;Trusted_Connection=False;User ID=sa;Password=Pa55w0rd");
}