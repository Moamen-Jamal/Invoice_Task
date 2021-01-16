using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class ItemUnitViewModel
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
    }
}
