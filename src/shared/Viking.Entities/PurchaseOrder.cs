using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public sealed class PurchaseOrder : AuditableEntity
    {
        public string Company { get; set; }
        public string PONum { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
