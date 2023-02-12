using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Azure.Identity;

namespace Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, configBuilder) =>
                    {
                        if (context.HostingEnvironment.IsDevelopment())
                        {
                            configBuilder.AddEnvFile("appsettings.Development.json");
                        }
                        else if (context.HostingEnvironment.IsStaging() || context.HostingEnvironment.IsProduction())
                        {
                            // var builtConfig = configBuilder.Build();
                            configBuilder.AddEnvFile("appsettings.json");
                        }
                    });

                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
