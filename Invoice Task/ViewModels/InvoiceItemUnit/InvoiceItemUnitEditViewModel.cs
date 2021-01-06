using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class InvoiceItemUnitEditViewModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int ItemUnitID { get; set; }
        public int InvoiceID { get; set; }
    }
}
