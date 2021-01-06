using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class InvoiceViewModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal Net { get; set; }
        public decimal Taxes { get; set; }

        public ICollection<InvoiceItemUnitViewModel> InvoiceItemUnit { get; set; }
    }
}
