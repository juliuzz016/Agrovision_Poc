using Agrovision.Spray_Calculator.gRPC.Extensions;
using Agrovision.Spray_Calculator.gRPC.Protos;
using Grpc.Core;
using IFieldsMaintance.Interfaces;
using ISpray_Calculator.Interfaces;
using ISprayingAgentMaintance;
using ISprayMaintance;
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
        public override async Task<ListFieldModel> GetActiveFields(LookupModel request, ServerCallContext context)
        {
            var res = await _client.GetGrain<IFieldsMaintanceGrain>(Guid.NewGuid()).GetActiveFields();
            var list = new ListFieldModel();
            list.FieldList.AddRange(res.Select(z => z.MapFieldDto()).ToList());
            return await Task.FromResult(list);
        }
        public override async Task<gRPC.Protos.SprayersModel> CreateSprayer(gRPC.Protos.SprayersModel field, ServerCallContext context)
        {
            var (RecordsAffected, Entity) = await _client.GetGrain<ISprayMaintanceGrain>(Guid.NewGuid()).CreateSprayer(field.Description, field.SparyerVolumeL);
            return await Task.FromResult(Entity.MapSprayDto());

        }
        public override async Task<ListSprayersModel> GetActiveSprayer(LookupModel request, ServerCallContext context)
        {
            var res =  await _client.GetGrain<ISprayMaintanceGrain>(Guid.NewGuid()).GetActiveSprays();
            var list = new ListSprayersModel();
            list.FieldList.AddRange(res.Select(z => z.MapSprayDto()).ToList());
            return await Task.FromResult(list);
        }
        public override async Task<SprayingAgentModel> CreateSprayingAgent(SprayingAgentModel request, ServerCallContext context)
        {
            var (RecordsAffected, Entity) = await _client.GetGrain<ISprayingAgentMaintanceGrain>(Guid.NewGuid()).CreateSprayingAgent(request.Description, request.RecomendedDosage);
            return await Task.FromResult(Entity.MapSprayingAgent());
        }
        public override async Task<ListSprayingAgentModel> GetActiveSprayingAgent(LookupModel request, ServerCallContext context)
        {
            var res = await _client.GetGrain<ISprayingAgentMaintanceGrain>(Guid.NewGuid()).GetActiveSprayingAgents();
            var list = new ListSprayingAgentModel();
            list.FieldList.AddRange(res.Select(z => z.MapSprayingAgent()).ToList());
            return await Task.FromResult(list);
        }
    }
}
