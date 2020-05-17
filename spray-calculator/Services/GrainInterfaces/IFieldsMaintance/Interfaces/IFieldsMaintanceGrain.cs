using Agrovision.Common.Dtos.Dto;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IFieldsMaintance.Interfaces
{
    public interface IFieldsMaintanceGrain : IGrainWithGuidKey
    {
        Task<(long, FieldsDto)> CreateField(string fieldName, double fieldSize);
        Task<IEnumerable<FieldsDto>> GetFields();
        Task<IEnumerable<FieldsDto>> GetActiveFields();
    }
}
