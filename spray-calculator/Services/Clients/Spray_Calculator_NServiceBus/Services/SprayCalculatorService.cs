using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Spray_Calculator_NServiceBus.Services
{

    public class SprayCalculatorService : IHostedService
    {
        public IClusterClient _client { get; }
        public SprayCalculatorService()
        {
            _client = new ClientBuilder()
             .UseLocalhostClustering()
             .ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory())
             .Configure<ClusterOptions>(options =>
             {
                 options.ClusterId = "Agrovision_Spray_Calculator";
                 options.ServiceId = "Agrovision SprayCalculator";
             })
             .ConfigureLogging(logging => logging.AddConsole())
             .Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _client.Connect();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Close();
        }
    }
}
