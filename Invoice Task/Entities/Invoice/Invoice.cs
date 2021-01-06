using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Invoice : BaseModel
    {
        public decimal Total { get; set; }
        public decimal Taxes { get; set; }
        public decimal Net { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<InvoiceItemUnit> InvoiceItemUnits { get; set; }
    }
}
