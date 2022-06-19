﻿using System.Linq;
using Authenticator;

namespace Users.gRPC.Server.Contexts.Core;

public class UsersRepository : IRepository<PersonalData>, IDisposable, IAsyncDisposable
{
    private UsersDb UsersDb { get; set; } = new UsersDb();

    public IEnumerable<PersonalData> Data => UsersDb.Users;

    public void AddData(PersonalData data)
    {
        UsersDb.Users.Add(data);
        UsersDb.SaveChanges();
    }

    public void AddData(IEnumerable<PersonalData> data)
    {
        foreach (var user in data)
        {
            if (UsersDb.Users.Any(u => u.Id == user.Id))
                throw new ArgumentException(nameof(user.Id));
            UsersDb.Users.Add(user);
        }
        UsersDb.SaveChanges();
    }

    public async Task AddDataAsync(PersonalData data)
    {
        if (UsersDb.Users.Any(u => u.Id == data.Id))
            throw new ArgumentException(nameof(data.Id));
        UsersDb.Users.Add(data);
        await UsersDb.SaveChangesAsync();
    }

    public async Task AddDataAsync(IEnumerable<PersonalData> data)
    {
        foreach (var user in data)
        {
            if (UsersDb.Users.Any(u => u.Id == user.Id))
                throw new ArgumentException(nameof(user.Id));
            UsersDb.Users.Add(user);
        }
        await UsersDb.SaveChangesAsync();
    }

    public void ChangeData(int id, PersonalData data)
    {
        throw new NotImplementedException();
    }

    public void ChangeData(int id, IEnumerable<PersonalData> data)
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
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
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
        {
            await UsersDb.DisposeAsync().ConfigureAwait(false);
        }

        UsersDb = null;
    }

    #endregion

}