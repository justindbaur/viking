using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public class FilterSortColumn
    {
        public string Company { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }
        public string ColumnPath { get; set; }
        public bool IsAscending { get; set; }
        public virtual Filter Filter { get; set; }
    }
}
