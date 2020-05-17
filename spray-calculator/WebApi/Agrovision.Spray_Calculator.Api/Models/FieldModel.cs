using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Agrovision.Spray_Calculator.Api.Models
{
    public class FieldModel
    {
        public long Id { get; set; }
        public Guid FieldKey { get; set; }
        public Guid UserKey { get; set; }
        public string Description { get; set; }
        public double FieldSize { get; set; }
        public bool IsActive { get; set; }
    }
}
