
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Users.gRPC.Server.Contexts.Core;
using Users.gRPC.Server.Services;

namespace GameDBServer
{
	public class Startup
	{
		public static IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			if (configuration == null) 
				throw new ArgumentNullException(nameof(configuration));
            
			var builder = new ConfigurationBuilder();
			configuration = builder.Build();
			Configuration = configuration;
		}
        
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<KestrelServerOptions>(o => o.AllowSynchronousIO = true);
			services.AddMetrics();
			services.AddLogging();
			services.AddGrpc();
			services.AddSingleton<GamesRepository>();
			services.AddSingleton<GamesService>(); 
		}

        
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<GamesService>();
			});
		}
	}
}
