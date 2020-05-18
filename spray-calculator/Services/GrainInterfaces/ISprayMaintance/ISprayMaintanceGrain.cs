using Agrovision.Common.Dtos.Dto;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISprayMaintance
{
    public interface ISprayMaintanceGrain : IGrainWithGuidKey
    {
        Task<(long, SprayersDto)> CreateSprayer(string description, double sparyerVolumeL);
        Task<IEnumerable<SprayersDto>> GetActiveSprays();
    }
}
