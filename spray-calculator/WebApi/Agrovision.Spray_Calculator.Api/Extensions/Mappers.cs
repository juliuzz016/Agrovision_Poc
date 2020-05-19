using Agrovision.Spray_Calculator.Api.Models;
using Agrovision.Spray_Calculator.gRPC.Protos;
using System;

namespace Agrovision.Spray_Calculator.Api.Extensions
{
    public static class Mappers
    {
        public static DosageCalculationResponse MapDosageCalculationResponse(this CalculateSprayResponse value)
        {
            if (value is null)
                return new DosageCalculationResponse();
            return new DosageCalculationResponse
            {
                AgenVolume = value.AgentValue,
                WaterVolume = value.WaterValue

            };
        }
        public static Models.FieldModel MapFieldModel(this gRPC.Protos.FieldModel value)
        {
            if (value is null)
                return new Models.FieldModel();

            return new Models.FieldModel
            {
                Description = value.Description,
                FieldKey = Guid.Parse(value.FieldKey),
                FieldSize = value.FieldSize,
                Id = value.Id,
                IsActive = value.IsActive,
                UserKey = Guid.Parse(value.UserKey)
            };
        }
        public static Models.SprayingAgentModel MapSprayingAgentModel(this gRPC.Protos.SprayingAgentModel value)
        {
            if (value is null)
                return new Models.SprayingAgentModel();
            return new Models.SprayingAgentModel
            {
                AgentDescription = value.Description,
                SprayerKey = Guid.Parse(value.SprayerKey),
                RecomendedDosage = (decimal)value.RecomendedDosage
            };
        }

        public static SprayModel MapSprayModel(this SprayersModel value)
        {
            if (value is null)
                return new SprayModel();
            return new SprayModel
            {
                Description = value.Description,
                Id = value.Id,
                IsActive = value.IsActive,
                SparyerVolumeL = value.SparyerVolumeL,
                SprayerKey = Guid.Parse(value.SprayerKey)
            };

        }
    }
}
