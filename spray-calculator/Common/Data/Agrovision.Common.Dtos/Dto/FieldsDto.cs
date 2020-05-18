using System;

namespace Agrovision.Common.Dtos.Dto
{
    public sealed class FieldsDto
    {
        public long Id { get; set; }
        public Guid FieldKey { get; set; }
        public Guid UserKey { get; set; }
        public string Description { get; set; }
        public double FieldSize { get; set; }
        public bool IsActive { get; set; }
    }
    public sealed class SprayersDto
    {
        public long Id { get; set; }
        public Guid SprayerKey { get; set; }
        public string Description { get; set; }
        public double SparyerVolumeL { get; set; }
        public bool IsActive { get; set; }
    }
    public sealed class SprayingAgentDto
    {

        public long Id { get; set; }
        public Guid AgentKey { get; set; }
        public string AgentDescription { get; set; }
        public decimal RecomendedDosage { get; set; }
        public bool IsActive { get; set; }

    }
}
