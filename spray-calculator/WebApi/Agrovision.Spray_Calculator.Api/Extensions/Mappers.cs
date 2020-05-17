using Agrovision.Spray_Calculator.Api.Models;
using Agrovision.Spray_Calculator.gRPC.Protos;
using Microsoft.AspNetCore.Authentication;
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
        public static Models.FieldModel MapFieldModel(this gRPC.Protos.FieldModel value){
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
    }
}
