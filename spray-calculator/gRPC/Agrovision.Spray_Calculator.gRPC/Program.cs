using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agrovision.Spray_Calculator.gRPC.OrleansClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;

namespace Agrovision.Spray_Calculator.gRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices(services =>
                {

                    services.AddSingleton<OrleansClientServices>();
                    services.AddSingleton<IHostedService>(z => z.GetService<OrleansClientServices>());
                    services.AddSingleton<IClusterClient>(z => z.GetService<OrleansClientServices>()._client);
                    services.AddSingleton<IGrainFactory>(sp => sp.GetService<OrleansClientServices>()._client);

                });
    }
}
