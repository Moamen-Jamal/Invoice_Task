using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class InvoiceItemUnitViewModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }
        public int? ItemUnitID { get; set; }
        public int InvoiceID { get; set; }
       
    }
}
