using Agrovision.Common.Dtos.Dto;
using Agrovision.Spray_Calculator.gRPC.Protos;

namespace Agrovision.Spray_Calculator.gRPC.Extensions
{
    public static class Mappers
    {
        public static gRPC.Protos.FieldModel MapFieldDto(this FieldsDto value)
        {
            if (value is null)
                return new FieldModel();
            return new FieldModel
            {
                Description = value.Description,
                FieldKey = value.FieldKey.ToString(),
                FieldSize = value.FieldSize,
                Id = value.Id,
                IsActive = value.IsActive,
                UserKey = value.UserKey.ToString()
            };

        }
        public static gRPC.Protos.SprayersModel MapSprayDto(this SprayersDto sprayersDto) 
        {
            if (sprayersDto is null)
                return new SprayersModel();
            return new SprayersModel
            {
                Id = sprayersDto.Id,
                Description = sprayersDto.Description,
                IsActive = sprayersDto.IsActive,
                SparyerVolumeL = sprayersDto.SparyerVolumeL,
                SprayerKey = sprayersDto.SprayerKey.ToString()
            };
        
        }
        public static SprayingAgentModel MapSprayingAgent(this SprayingAgentDto value) 
        {
            if (value is null)
                return new SprayingAgentModel();
            return new SprayingAgentModel
            {
                Description = value.AgentDescription,
                Id = value.Id,
                IsActive = value.IsActive,
                RecomendedDosage = (double)value.RecomendedDosage,
                SprayerKey = value.AgentKey.ToString()
            };
        
        }
    }
}
