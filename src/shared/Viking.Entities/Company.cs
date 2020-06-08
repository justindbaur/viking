﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Viking.Entities
{
    public sealed class Company : AuditableEntity
    {
        [Key]
        public string Name { get; set; }
    }
}
