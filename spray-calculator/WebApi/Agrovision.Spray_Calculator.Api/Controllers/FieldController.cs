using Agrovision.Spray_Calculator.Api.Extensions;
using Agrovision.Spray_Calculator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Agrovision.Spray_Calculator.gRPC.Protos.Spray_CalculatorGRPCService;

namespace Agrovision.Spray_Calculator.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly Spray_CalculatorGRPCServiceClient _spray_CalculatorGRPCServiceClient;
        public FieldController(Spray_CalculatorGRPCServiceClient spray_CalculatorGRPCServiceClient)
        {
            _spray_CalculatorGRPCServiceClient = spray_CalculatorGRPCServiceClient;
        }
        [HttpPost]
        public async Task<FieldModel> CreateField(FieldModel field)
        {
            var res = await _spray_CalculatorGRPCServiceClient.CreateFieldAsync(new gRPC.Protos.FieldModel
            {
                Description = field.Description,
                FieldSize = field.FieldSize,
                UserKey = Guid.Empty.ToString(),
                FieldKey = Guid.Empty.ToString(),
                Id = 0,
                IsActive = false
            });
            return await Task.FromResult(res.MapFieldModel());
        }
    }
}