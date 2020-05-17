using Agrovision.Spray_Calculator.gRPC.Extensions;
using Agrovision.Spray_Calculator.gRPC.Protos;
using Grpc.Core;
using IFieldsMaintance.Interfaces;
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
            var (agent , water ) = await _client.GetGrain<IDosage_CalculatorGrain>(Guid.NewGuid()).CalculateDosage(calculateSprayRequest.AgentReq, calculateSprayRequest.FieldSize, calculateSprayRequest.WaterRate);
            return await Task.FromResult(new CalculateSprayResponse { 
            AgentValue = agent,
            WaterValue = water
            });
        }
        public override async Task<gRPC.Protos.FieldModel> CreateField(gRPC.Protos.FieldModel field, ServerCallContext context)
        {
            var (RecordsAffected, Entity) = await _client.GetGrain<IFieldsMaintanceGrain>(Guid.NewGuid()).CreateField(field.Description, field.FieldSize);
            return await Task.FromResult(Entity.MapFieldDto());

        }
    }
}
