using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Entities
{
    public class PurchaseOrderLine : AuditableEntity
    {
        public string Company { get; set; }
        public string PONum { get; set; }
        public int LineNum { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
