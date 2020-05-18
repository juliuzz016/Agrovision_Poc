using Agrovision.Spray_Calculator.Data;
using BusinessLogic.Dosage_Calculator.Interfaces;
using BusinessLogic.Dosage_Calculator.Services;
using ISpray_Calculator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Spray_Calculator;
using SprayCalculatorRepository.RepositoryImplementations;
using SprayerMaintance;
using SprayingAgentMaintance;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Agrovision.Spray_Calculator.Services.Silo.Services
{
    public class SprayCalculatorSilo : IHostedService, IDisposable
    {
        public ISiloHost _siloHost;
        public void Dispose()
        {

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "*";
                    options.ServiceId = "*";
                })

                .Configure<EndpointOptions>(options =>
                {
                    options.AdvertisedIPAddress = IPAddress.Loopback;
                    options.GatewayPort = 30000;
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(BaseGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(FieldsMaintance.FieldsMaintanceGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(Dosage_CalculatorGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(SprayerMaintanceGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(SprayingAgentMaintanceGrain).Assembly).WithReferences();

                })
                .UseDashboard(options =>
                {
                    options.Username = "USERNAME";
                    options.Password = "PASSWORD";
                    options.Host = "*";
                    options.Port = 8080;
                    options.HostSelf = true;
                    options.CounterUpdateIntervalMs = 1000;

                }).ConfigureServices(services =>
                {
                    services.AddTransient<SprayCalculatorContext>();

                    services.AddTransient<FieldsRepository>();
                    services.AddTransient<SprayersRepository>();
                    services.AddTransient<SprayingAgentsRepository>();

                    services.AddTransient<IDosage_CalculatorBL, Dosage_Calculator>();

                });

            _siloHost = builder.Build();
            await _siloHost.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _siloHost.StopAsync(cancellationToken);
        }
    }
}
