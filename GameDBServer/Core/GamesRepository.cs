namespace Users.gRPC.Server.Contexts.Core;

public class GamesRepository : IRepository<GamesHolder.Game>, IDisposable, IAsyncDisposable
{
    private GamesDb UsersDb { get; set; } = new GamesDb();

    public IEnumerable<GamesHolder.Game> Data => UsersDb.Games;

    public void AddData(GamesHolder.Game data)
    {
        UsersDb.Games.Add(data);
        UsersDb.SaveChanges();
    }

    public void AddData(IEnumerable<GamesHolder.Game> data)
    {
        foreach (var user in data)
        {
            if (UsersDb.Games.Any(u => u.Id == user.Id))
                throw new ArgumentException(nameof(user.Id));
            UsersDb.Games.Add(user);
        }
        UsersDb.SaveChanges();
    }

    public async Task AddDataAsync(GamesHolder.Game data)
    {
        if (UsersDb.Games.Any(u => u.Id == data.Id))
            throw new ArgumentException(nameof(data.Id));
        UsersDb.Games.Add(data);
        await UsersDb.SaveChangesAsync();
    }

    public async Task AddDataAsync(IEnumerable<GamesHolder.Game> data)
    {
        foreach (var user in data)
        {
            if (UsersDb.Games.Any(u => u.Id == user.Id))
                throw new ArgumentException(nameof(user.Id));
            UsersDb.Games.Add(user);
        }
        await UsersDb.SaveChangesAsync();
    }

    public void ChangeData(int id, GamesHolder.Game data)
    {
        throw new NotImplementedException();
    }

    public void ChangeData(int id, IEnumerable<GamesHolder.Game> data)
    {
        throw new NotImplementedException();
    }

    #region Dispose Region

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            UsersDb?.Dispose();
            UsersDb = null!;
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (UsersDb is not null)
            await UsersDb.DisposeAsync().ConfigureAwait(false);

        UsersDb = null;
    }

    #endregion

}