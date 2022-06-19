using GamesHolder;
using Grpc.Core;
using Users.gRPC.Server.Contexts.Core;

namespace Users.gRPC.Server.Services;

public class GamesService : GamesHolder.GamesHolder.GamesHolderBase
{
    private readonly ILogger<GamesService> _logger;
    private readonly GamesRepository Db;
    
    public GamesService(ILogger<GamesService> logger, GamesRepository db)
    {
        _logger = logger;
        Db = db;
    }

    public override async Task<AddGameReply> AddGame(AddGameRequest request, ServerCallContext context)
    {
        var reply = new AddGameReply();
        await Db.AddDataAsync(request.GameData);
        reply.Status = AddGameReply.Types.State.Successful;
        return reply;
    }

    public override async Task<GetGameReply> GetGame(GetGameRequest request, ServerCallContext context)
    {
        var reply = new GetGameReply
        {
            Status = GetGameReply.Types.State.Successful
        };
        var data = Db.Data.FirstOrDefault(item => item.Id == request.GameID);
        if (data == null)
            reply.Status = GetGameReply.Types.State.GameNotFounded;
        
        reply.Game = data;
        return reply;
    }

    public override async Task<GetUserGamesReply> GetGameByUser(GetUserGamesRequest request, ServerCallContext context)
    {
        var reply = new GetUserGamesReply();
        var data = Db
            .Data
            .Where(item => item.Player1 == request.UserID || item.Player2 == request.UserID);

        foreach (var game in data)
            reply.Games.Add(new GetGameReply(){Game = game, Status = GetGameReply.Types.State.Successful});
        
        return reply;
    }
}
