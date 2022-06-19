using Authenticator;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Users.gRPC.Server.Contexts.Core;

namespace Users.gRPC.Server.Services;

public class UsersService : Authenticator.Authenticator.AuthenticatorBase
{
    private readonly ILogger<UsersService> _logger;
    private readonly UsersRepository Db;
    
    public UsersService(ILogger<UsersService> logger, UsersRepository db)
    {
        _logger = logger;
        Db = db;
    }

    public override async Task<AuthenticatorReply> Authenticate(AuthenticatorRequest request, ServerCallContext context)
    {
        var reply = new AuthenticatorReply
        {
            StatusCode = (int)StatusCode.OK
        };

        var user = Db.Data.FirstOrDefault(user => user.Login == request.Login);
        if (user == null)
        {
            reply.StatusCode = (int)StatusCode.InvalidArgument;
            _logger.LogInformation($"User is never registrated");
            return reply;
        }

        user = Db.Data.FirstOrDefault(user => user.Login == request.Login && user.Password == request.Password);
        
        if (user == null)
        {
            reply.StatusCode = (int)StatusCode.Unauthenticated;
            _logger.LogInformation($"IncorrectData");
            return reply;
        }

        reply.PersonalData = user;

        return reply;
    }

    public override async Task<AuthenticatorReply> Register(AuthenticatorRequest request, ServerCallContext context)
    {
        var reply = new AuthenticatorReply
        {
            StatusCode = (int)StatusCode.OK
        };

        if (Db.Data.FirstOrDefault(user => user.Login == request.Login) != null)
        {
            reply.StatusCode = (int)StatusCode.InvalidArgument;
            _logger.LogInformation($"Same user already registrated");
            return reply;
        }
        await Db.AddDataAsync(new PersonalData()
        {
            Login = request.Login,
            Password = request.Password,
            RegistrationDate = Timestamp.FromDateTime(DateTime.UtcNow),
            LastActiveDate = Timestamp.FromDateTime(DateTime.UtcNow),
            BannedData = new BannedData
            {
                IsBanned = false
            }
        });
        reply.PersonalData = Db.Data.FirstOrDefault(user => user.Login == request.Login);

        return reply;
    }

    public override async Task<RememberPasswordReply> RememberPassword(RememberPasswordRequest request, ServerCallContext context)
    {
        var reply = new RememberPasswordReply();

        return reply;
    }

    public override async Task<PersonalDataReply> GetPersonalData(PersonalDataRequest request, ServerCallContext context)
    {
        var reply = new PersonalDataReply();

        return reply;
    }
}