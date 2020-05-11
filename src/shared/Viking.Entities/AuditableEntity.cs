using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public abstract class AuditableEntity : EntityBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastRevisedBy { get; set; }
        public DateTime? LastRevisedTime { get; set; }
    }
}
