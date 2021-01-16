using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ItemUnit : BaseModel
    {
        public decimal Price { get; set; }
        
        public virtual Item Item { get; set; }
        public int ItemID { get; set; }
        public virtual Unit Unit { get; set; }
        public int UnitID { get; set; }
        public virtual ICollection<InvoiceItemUnit> InvoiceItemUnits { get; set; }
    }
}
