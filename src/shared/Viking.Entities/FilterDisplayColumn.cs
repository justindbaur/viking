using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public class FilterDisplayColumn
    {
        public string Company { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }
        public string ColumnPath { get; set; }
        public int OrderNum { get; set; }
        public virtual Filter Filter { get; set; }
    }
}
