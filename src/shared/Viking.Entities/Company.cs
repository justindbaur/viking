using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Viking.Entities
{
    public class Company : AuditableEntity
    {
        public string Name { get; set; }
    }
}
