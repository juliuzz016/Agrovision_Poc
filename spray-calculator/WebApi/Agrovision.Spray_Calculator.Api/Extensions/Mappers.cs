using Agrovision.Spray_Calculator.Api.Models;
using Agrovision.Spray_Calculator.gRPC.Protos;
using Microsoft.AspNetCore.Authentication;

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
    }
}
