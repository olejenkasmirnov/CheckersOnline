using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using UserDBServer;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseMetricsWebTracking()
            .UseMetrics(options =>
            {
                options.EndpointOptions = endpoints =>
                {
                    endpoints.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    endpoints.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                    endpoints.EnvironmentInfoEndpointEnabled = false;
                };
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("hosting.json", optional: true)
                    .Build();

                webBuilder
                    .UseConfiguration(config)
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel()
                    .UseUrls(config.GetSection("server.urls").Value)
                    .UseIISIntegration()
                    .UseStartup<Startup>();
            });
}