using GameService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
var app = builder.Build();

// app.MapGrpcService<GreeterService>();
app.Run();
