using Agrovision.Common.Dtos.Dto;
using Agrovision.Spray_Calculator.Data.Model;

namespace SprayingAgentMaintance.Extensions
{
    public static class Mappers
    {
        public static SprayingAgentDto MapSprayingAgentDto(this SprayingAgents value)
        {
            if (value is null)
                return new SprayingAgentDto();
            return new SprayingAgentDto
            {
                AgentDescription = value.AgentDescription,
                AgentKey = value.AgentKey,
                Id = value.Id,
                IsActive = value.IsActive,
                RecomendedDosage = value.RecomendedDosage
            };

        }
    }
}
