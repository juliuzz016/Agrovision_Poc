using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Agrovision.Spray_Calculator.Services.Silo
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
               services.AddHostedService<Services.SprayCalculatorSilo>();


           });
    }
}
