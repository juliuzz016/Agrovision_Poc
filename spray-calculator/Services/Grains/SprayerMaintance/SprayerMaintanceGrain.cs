using Agrovision.Common.Dtos.Dto;
using Orleans;
using SprayCalculatorRepository.RepositoryImplementations;
using System;
using System.Threading.Tasks;
using Agrovision.Spray_Calculator.Data.Model;
using SprayerMaintance.Extensions;
using System.Collections.Generic;
using System.Linq;
using ISprayMaintance;

namespace SprayerMaintance
{
    public class SprayerMaintanceGrain :  Grain, ISprayMaintanceGrain
    {
        public static Guid HardcodedUserKey = Guid.Parse("42A6FEB2-69AF-44AE-823B-5A260E4FF050");
        private readonly SprayersRepository _sprayersRepository;
        public SprayerMaintanceGrain(SprayersRepository sprayersRepository)
        {
            _sprayersRepository = sprayersRepository;
        }
        public async Task<(long, SprayersDto)> CreateSprayer(string description , double sparyerVolumeL) 
        {

            var (RecordsAffected, Entity) = await _sprayersRepository.Create(new Sprayers
            {
                Description = description,
                SparyerVolumeL = (decimal)sparyerVolumeL
            });
            return await Task.FromResult((RecordsAffected, Entity.MapSprayerDto()));
        }
        public async Task<IEnumerable<SprayersDto>> GetActiveSprays() 
        {
            var res = await _sprayersRepository.Lookup(z => z.IsActive);
            return await Task.FromResult(res.Select(z => z.MapSprayerDto()));

        }
    }
}
