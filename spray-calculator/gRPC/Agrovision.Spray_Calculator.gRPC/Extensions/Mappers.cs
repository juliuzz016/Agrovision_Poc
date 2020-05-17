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
    }
}
