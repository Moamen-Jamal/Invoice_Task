using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class InvoiceItemUnit : BaseModel
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int InvoiceID { get; set; }
        public virtual ItemUnit ItemUnit { get; set; }
        public int? ItemUnitID { get; set; }
    }
}
