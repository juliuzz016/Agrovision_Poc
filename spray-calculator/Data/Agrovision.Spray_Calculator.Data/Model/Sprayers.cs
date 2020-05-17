using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrovision.Spray_Calculator.Data.Model
{
    public partial class Sprayers
    {
        [Key]
        public long Id { get; set; }
        public Guid SprayerKey { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal SparyerVolumeL { get; set; }
        public bool IsActive { get; set; }
    }
}
