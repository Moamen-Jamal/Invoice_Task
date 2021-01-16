using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Cart
    {
        public int? ID { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Net { get; set; }
    }
}
