using System;

namespace Agrovision.Common.Dtos.Dto
{
    public sealed class SprayersDto
    {
        public long Id { get; set; }
        public Guid SprayerKey { get; set; }
        public string Description { get; set; }
        public double SparyerVolumeL { get; set; }
        public bool IsActive { get; set; }
    }
}
