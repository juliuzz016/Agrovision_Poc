using Agrovision.Common.Dtos.Dto;
using Agrovision.Spray_Calculator.Data.Model;
using System.Linq;

namespace FieldsMaintanceGrain.Extensions
{
    public static class Mappers
    {

        public static FieldsDto MapField(this Fields value) {
            if (value is null)
                return new FieldsDto();
            return new FieldsDto
            {
                Id = value.Id,
                Description = value.Description,
                FieldKey= value.FieldKey,
                FieldSize = value.FieldSize,
                IsActive = value.IsActive,
                UserKey = value.UserKey
                
            };
        
        }
    }
}
