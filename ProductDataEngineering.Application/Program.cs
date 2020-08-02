using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductDataEngineering.Data;
using Refit;
using Services;

namespace ProductDataEngineering.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddScoped<INumberRepository, NumberRepository>();
                    services.AddDbContext<NumberContext>(opts =>
                        opts.UseSqlite(hostContext.Configuration.GetConnectionString("Numbers"))
                            .EnableSensitiveDataLogging());

                    services.AddRefitClient<IBeeceptorApi>().ConfigureHttpClient(c =>
                        c.BaseAddress = new Uri(hostContext.Configuration.GetSection("Beeceptor:Url").Value));
                    services.AddScoped<IBeeceptorService, BeeceptorService>();

                    services.AddScoped<INumberProcessor, NumberProcessor>();

                });
    }
}
