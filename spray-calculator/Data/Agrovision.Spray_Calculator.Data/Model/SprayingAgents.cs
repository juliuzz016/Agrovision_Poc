using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrovision.Spray_Calculator.Data.Model
{
    public partial class SprayingAgents
    {
        [Key]
        public long Id { get; set; }
        public Guid AgentKey { get; set; }
        [Required]
        public string AgentDescription { get; set; }
        [Column(TypeName = "decimal(16, 4)")]
        public decimal RecomendedDosage { get; set; }
        public bool IsActive { get; set; }
    }
}
