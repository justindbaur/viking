using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Viking.Entities
{
    public class Filter : AuditableEntity
    {
        public string Company { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<FilterSortColumn> FilterSortColumns { get; set; }
        public virtual ICollection<FilterDisplayColumn> FilterDisplayColumns { get; set; }
    }
}
