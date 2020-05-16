using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Agrovision.Spray_Calculator.gRPC.OrleansClient
{
    public class OrleansClientServices : IHostedService
    {
        public IClusterClient _client { get; }

        public OrleansClientServices()
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
