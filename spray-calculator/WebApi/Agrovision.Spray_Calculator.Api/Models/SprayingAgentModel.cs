using System;

namespace Agrovision.Spray_Calculator.Api.Models
{
    public class SprayingAgentModel
    {
        public long Id { get; set; }
        public Guid SprayerKey { get; set; }
        public string AgentDescription { get; set; }
        public decimal RecomendedDosage { get; set; }
        public bool IsActive { get; set; }
    }
}
