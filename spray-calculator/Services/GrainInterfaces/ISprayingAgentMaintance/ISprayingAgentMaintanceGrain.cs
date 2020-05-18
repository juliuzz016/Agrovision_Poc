using Agrovision.Common.Dtos.Dto;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISprayingAgentMaintance
{
    public interface ISprayingAgentMaintanceGrain : IGrainWithGuidKey
    {
        Task<(long, SprayingAgentDto)> CreateSprayingAgent(string description, double recomendedDosage);
        Task<IEnumerable<SprayingAgentDto>> GetActiveSprayingAgents();
    }
}
