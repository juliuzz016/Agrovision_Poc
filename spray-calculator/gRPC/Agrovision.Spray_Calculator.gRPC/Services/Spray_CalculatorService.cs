using Agrovision.Spray_Calculator.gRPC.Protos;
using Grpc.Core;
using ISpray_Calculator.Interfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrovision.Spray_Calculator.gRPC.Services
{
    public class Spray_CalculatorService: Spray_CalculatorGRPCService.Spray_CalculatorGRPCServiceBase
    {
        public IClusterClient _client;
        public Spray_CalculatorService(IClusterClient client)
        {
            _client = client;
        }
        public async override Task<CalculateSprayResponse> CalculateSpray(CalculateSprayRequest calculateSprayRequest, ServerCallContext context) 
        {
            var (water, agent) = await _client.GetGrain<IDosage_CalculatorGrain>(Guid.NewGuid()).CalculateDosage(calculateSprayRequest.AgentReq, calculateSprayRequest.FieldSize, calculateSprayRequest.WaterRate);
            return await Task.FromResult(new CalculateSprayResponse { 
            AgentValue = agent,
            WaterValue = water
            });
        }
    }
}
