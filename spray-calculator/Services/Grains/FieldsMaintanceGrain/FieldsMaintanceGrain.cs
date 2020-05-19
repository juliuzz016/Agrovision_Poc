using Agrovision.Common.Dtos.Dto;
using FieldsMaintanceGrain.Extensions;
using IFieldsMaintance.Interfaces;
using Orleans;
using SprayCalculatorRepository.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldsMaintance
{
    public class FieldsMaintanceGrain : Grain, IFieldsMaintanceGrain
    {
        public static Guid HardcodedUserKey = Guid.Parse("42A6FEB2-69AF-44AE-823B-5A260E4FF050");
        private readonly FieldsRepository _fieldsRepository;
        public FieldsMaintanceGrain(FieldsRepository fieldsRepository)
        {
            _fieldsRepository = fieldsRepository;
        }
        public async Task<(long, FieldsDto)> CreateField(string fieldName, double fieldSize)
        {
            var (RecordsAffected, Entity) = await _fieldsRepository.Create(new Agrovision.Spray_Calculator.Data.Model.Fields
            {
                Description = fieldName,
                FieldSize = (double)fieldSize
            });
            return await Task.FromResult((RecordsAffected, Entity.MapField()));
        }
        public async Task<IEnumerable<FieldsDto>> GetFields()
        {
            var res = await _fieldsRepository.Lookup(z => z.UserKey == HardcodedUserKey);
            return await Task.FromResult(res.Select(z => z.MapField()));

        }
        public async Task<IEnumerable<FieldsDto>> GetActiveFields()
        {
            var res = await _fieldsRepository.Lookup(z => z.IsActive && z.UserKey == HardcodedUserKey);
            if (!res.Any())
                return  new List<FieldsDto>();
            return await Task.FromResult(res.Select(z => z.MapField()).ToList());

        }
    }
}
