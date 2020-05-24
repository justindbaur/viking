using System;
using System.Collections.Generic;
using System.Text;

namespace Vikings.Models
{
    public class CreatePurchaseOrderModel
    {
        public string Company { get; set; }
        public string PONum { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
