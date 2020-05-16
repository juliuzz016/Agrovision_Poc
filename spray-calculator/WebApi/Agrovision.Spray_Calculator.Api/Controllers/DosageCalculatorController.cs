using Agrovision.Spray_Calculator.Api.Extensions;
using Agrovision.Spray_Calculator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Agrovision.Spray_Calculator.gRPC.Protos.Spray_CalculatorGRPCService;

namespace Agrovision.Spray_Calculator.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DosageCalculatorController : ControllerBase
    {
        private readonly Spray_CalculatorGRPCServiceClient _spray_CalculatorGRPCServiceClient;
        public DosageCalculatorController(Spray_CalculatorGRPCServiceClient spray_CalculatorGRPCServiceClient)
        {
            _spray_CalculatorGRPCServiceClient = spray_CalculatorGRPCServiceClient;
        }
        [HttpPost]
        public async Task<DosageCalculationResponse> CalculateDosage(DosageCalculationRequest dosageCalculationRequest)
        {

            var res = await _spray_CalculatorGRPCServiceClient.CalculateSprayAsync(new gRPC.Protos.CalculateSprayRequest
            {
                AgentReq = dosageCalculationRequest.AgenVolume,
                FieldSize = dosageCalculationRequest.FieldSize,
                WaterRate = dosageCalculationRequest.WaterRate
            });
            return await Task.FromResult(res.MapDosageCalculationResponse());
        }
    }
}