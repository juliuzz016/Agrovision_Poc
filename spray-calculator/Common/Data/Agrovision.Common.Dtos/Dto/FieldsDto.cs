using System;

namespace Agrovision.Common.Dtos.Dto
{
    public sealed class FieldsDto
    {
        public long Id { get; set; }
        public Guid FieldKey { get; set; }
        public Guid UserKey { get; set; }    
        public string Description { get; set; }
        public double FieldSize { get; set; }
        public bool IsActive { get; set; }
    }
}
