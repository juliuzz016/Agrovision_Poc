using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrovision.Spray_Calculator.Data.Model
{
    public partial class Fields
    {
        [Key]
        public long Id { get; set; }
        public Guid FieldKey { get; set; }
        public Guid UserKey { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public double FieldSize { get; set; }
        public bool IsActive { get; set; }
    }
}
