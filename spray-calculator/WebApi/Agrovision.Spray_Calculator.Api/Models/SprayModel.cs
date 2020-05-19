using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrovision.Spray_Calculator.Api.Models
{
    public class SprayModel
    {
        public long Id { get; set; }
        public Guid SprayerKey { get; set; }
        public string Description { get; set; }
        public double SparyerVolumeL { get; set; }
        public bool IsActive { get; set; }
    }
}
