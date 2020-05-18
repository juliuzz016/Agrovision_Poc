using Agrovision.Common.Dtos.Dto;
using Agrovision.Spray_Calculator.Data.Model;

namespace SprayerMaintance.Extensions
{
    public static class Mappers
    {
        public static SprayersDto MapSprayerDto(this Sprayers value)
        {
            if (value is null)
                return new SprayersDto();
            return new SprayersDto
            {
                Id = value.Id,
                IsActive = value.IsActive,
                SparyerVolumeL = (double)value.SparyerVolumeL,
                Description = value.Description,
                SprayerKey = value.SprayerKey

            };

        }
    }
}
