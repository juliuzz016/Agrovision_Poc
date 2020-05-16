using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using Orleans;
using Spray_Calculator_NServiceBus.Services;
using System;

namespace Spray_Calculator_NServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureServices(services =>
             {

                 services.AddSingleton<SprayCalculatorService>();
                 services.AddSingleton<IHostedService>(z => z.GetService<SprayCalculatorService>());
                 services.AddSingleton<IClusterClient>(z => z.GetService<SprayCalculatorService>()._client);
                 services.AddSingleton<IGrainFactory>(sp => sp.GetService<SprayCalculatorService>()._client);

             }).UseNServiceBus(x =>
             {
                 var endpointConfiguration = new EndpointConfiguration("Agrovision Spray Calculator");
                 endpointConfiguration.EnableInstallers();
                 endpointConfiguration.UseTransport<RabbitMQTransport>()
                 .UseDirectRoutingTopology()
                 .ConnectionString("host=localhost;username=guest;password=guest;");
                 endpointConfiguration.EnableMetrics();//.SendMetricDataToServiceControl("Agrovision.ServiceControl", TimeSpan.FromSeconds(2));
                 return endpointConfiguration;
             });
    }
}
