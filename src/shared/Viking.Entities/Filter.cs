using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public class Filter : AuditableEntity
    {
        public string Company { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }

        public ICollection<FilterSortColumn> FilterSortColumns { get; set; }
        public ICollection<FilterDisplayColumn> FilterDisplayColumns { get; set; }
    }
}
