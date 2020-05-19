using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrovision.Spray_Calculator.Api.Extensions;
using Agrovision.Spray_Calculator.Api.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Agrovision.Spray_Calculator.gRPC.Protos.Spray_CalculatorGRPCService;

namespace Agrovision.Spray_Calculator.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpraysController : ControllerBase
    {
        private readonly Spray_CalculatorGRPCServiceClient _spray_CalculatorGRPCServiceClient;
        public SpraysController(Spray_CalculatorGRPCServiceClient spray_CalculatorGRPCServiceClient)
        {
            _spray_CalculatorGRPCServiceClient = spray_CalculatorGRPCServiceClient;
        }
        [HttpPost]
        public async Task<SprayModel> CreateSpray(SprayModel sprayValue) 
        {
            var res = await _spray_CalculatorGRPCServiceClient.CreateSprayerAsync(new gRPC.Protos.SprayersModel { 
            Description = sprayValue.Description,
            SparyerVolumeL = sprayValue.SparyerVolumeL            
            });
            return await Task.FromResult(res.MapSprayModel());
        }
        [HttpGet]
        public async Task<IEnumerable<SprayModel>> GetActiveSprays()
        {
            var res = await _spray_CalculatorGRPCServiceClient.GetActiveSprayerAsync(new gRPC.Protos.LookupModel() { 
            Page = 1,
            PageSize = 10
            
            });
            return await Task.FromResult(res.FieldList.Select(z => z.MapSprayModel()));
        }
    }
}