using System.IO;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OWL_REACT.Config;
using OWL_REACT.Helpers.Implementations;
using OWL_REACT.Helpers.Interfaces;

namespace OWL_REACT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddAutoMapper();

            services.AddOptions()
                .Configure<OverwatchApiSettings>(configuration);

            services.AddTransient<Startup>()
                .AddScoped<IApiRequestHelper, ApiRequestHelper>();
        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
