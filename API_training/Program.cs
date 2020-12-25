using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Security.Authentication;

namespace API_training
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddNLog();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // configure self-host
                // see https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-5.0
                webBuilder.ConfigureKestrel(serverOptions =>
               {
                   serverOptions.Limits.MinRequestBodyDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                   serverOptions.Limits.MinResponseDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                   serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                   serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                      // configure SSL protocol for example
                      serverOptions.ConfigureHttpsDefaults(listenOptions =>
                  {
                      listenOptions.SslProtocols = SslProtocols.Tls12;
                  });
               })
               .UseStartup<Startup>();
            });
    }
}