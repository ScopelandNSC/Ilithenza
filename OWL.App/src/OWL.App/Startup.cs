using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OWL.App.Config;
using OWL.App.Helpers.Implementations;
using OWL.App.Helpers.Interfaces;
using OWL.App.Repositories.Implementation;
using OWL.App.Repositories.Interface;
using OWL.App.Services.Implementation;
using OWL.App.Services.Interface;
using Prometheus;

namespace OWL.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            /* services.AddOptions()
                .Configure<OverwatchApiSettings>(configuration); */

            ConfigureDependencyInjection(services);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureMetrics(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseHealthChecks("/health");

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private static void ConfigureRequestDurationMetric(IApplicationBuilder app)
        {
            var diagram = Metrics.CreateHistogram(
                            "http_request_duration_seconds",
                            "track the duration of the API requests",
                            new HistogramConfiguration { Buckets = new[] { 0.2d, 0.5d } });
            app.Use((context, next) =>
            {
                var stopwatch = Stopwatch.StartNew();
                var response = next();
                stopwatch.Stop();
                diagram.Observe((double)stopwatch.ElapsedMilliseconds / 1000);
                return response;
            });
        }

        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            ConfigureRepositoryDependancies(services);
            ConfigureServiceDependancies(services);
            ConfigureHelperDependancies(services);
        }

        private static void ConfigureRepositoryDependancies(IServiceCollection services)
        {
            services.AddTransient<IPlayerRepository, PlayerRepository>();
        }

        private static void ConfigureServiceDependancies(IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
        }

        private static void ConfigureHelperDependancies(IServiceCollection services)
        {
            services.AddTransient<IApiRequestHelper, ApiRequestHelper>();
        }

        private static void ConfigureBuildInfoMetric()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            var informationalVersion =
                currentAssembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
                    .OfType<AssemblyInformationalVersionAttribute>()
                    .FirstOrDefault();
            var assemblyVersion = currentAssembly.GetName().Version;

            var versionNumber =
                Metrics.CreateGauge("rd_build_info", "track the deployment version number", "version", "informational_version");
            versionNumber.WithLabels(assemblyVersion.ToString(), informationalVersion.InformationalVersion).Set(1);
        }

        private void ConfigureMetrics(IApplicationBuilder app)
        {
            ConfigureRequestDurationMetric(app);

            ConfigureBuildInfoMetric();

            var metricsPort = Configuration.GetValue<int>("MetricsPort");
            using var metricServer = new KestrelMetricServer(metricsPort);
            metricServer.Start();
        }
    }
}
