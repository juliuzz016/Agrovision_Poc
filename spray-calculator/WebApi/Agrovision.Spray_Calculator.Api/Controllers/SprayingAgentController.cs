using Agrovision.Spray_Calculator.Api.Extensions;
using Agrovision.Spray_Calculator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Agrovision.Spray_Calculator.gRPC.Protos.Spray_CalculatorGRPCService;

namespace Agrovision.Spray_Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprayingAgentController : ControllerBase
    {
        private readonly Spray_CalculatorGRPCServiceClient _spray_CalculatorGRPCServiceClient;
        public SprayingAgentController(Spray_CalculatorGRPCServiceClient spray_CalculatorGRPCServiceClient)
        {
            _spray_CalculatorGRPCServiceClient = spray_CalculatorGRPCServiceClient;
        }
        [HttpPost]
        public async Task<SprayingAgentModel> CreateSprayingAgentModel(SprayingAgentModel sprayingAgentModel)
        {
            var res = await _spray_CalculatorGRPCServiceClient.CreateSprayingAgentAsync(new gRPC.Protos.SprayingAgentModel
            {
                Description = sprayingAgentModel.AgentDescription,
                RecomendedDosage = (double)sprayingAgentModel.RecomendedDosage

            });
            return await Task.FromResult(res.MapSprayingAgentModel());
        }
        [HttpGet]
        public async Task<List<SprayingAgentModel>> GetActiveSprayingAgent()
        {
            var res = await _spray_CalculatorGRPCServiceClient.GetActiveSprayingAgentAsync(new gRPC.Protos.LookupModel());
            return await Task.FromResult(res.FieldList.Select(z => z.MapSprayingAgentModel()).ToList());

        }
    }
}