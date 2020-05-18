using System;

namespace Agrovision.Common.Dtos.Dto
{
    public sealed class SprayingAgentDto
    {

        public long Id { get; set; }
        public Guid AgentKey { get; set; }
        public string AgentDescription { get; set; }
        public decimal RecomendedDosage { get; set; }
        public bool IsActive { get; set; }

    }
}
