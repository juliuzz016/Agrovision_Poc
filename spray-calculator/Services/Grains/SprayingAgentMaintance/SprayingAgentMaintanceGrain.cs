using Orleans;
using SprayCalculatorRepository.RepositoryImplementations;
using System;
using System.Threading.Tasks;
using Agrovision.Spray_Calculator.Data.Model;
using SprayingAgentMaintance.Extensions;
using Agrovision.Common.Dtos.Dto;
using System.Collections.Generic;
using System.Linq;
using ISprayingAgentMaintance;

namespace SprayingAgentMaintance
{
    public class SprayingAgentMaintanceGrain : Grain, ISprayingAgentMaintanceGrain
    {
        private readonly SprayingAgentsRepository _sprayingAgentsRepository;
        public SprayingAgentMaintanceGrain(SprayingAgentsRepository sprayingAgentsRepository)
        {
            _sprayingAgentsRepository = sprayingAgentsRepository;
        }
        public async Task<(long, SprayingAgentDto)> CreateSprayingAgent(string description, double recomendedDosage) 
        {

            var (RecordsAffected, Entity) = await _sprayingAgentsRepository.Create(new SprayingAgents {
                AgentDescription = description,
                RecomendedDosage = (decimal)recomendedDosage
            });

            return await Task.FromResult((RecordsAffected, Entity.MapSprayingAgentDto()));
        }
        public async Task<IEnumerable<SprayingAgentDto>> GetActiveSprayingAgents() {

            var res = await _sprayingAgentsRepository.Lookup(z => z.IsActive);
            return await Task.FromResult(res.Select(z => z.MapSprayingAgentDto()));
        }
    }
}
