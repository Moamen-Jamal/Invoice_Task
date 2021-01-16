using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class UnitViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<ItemUnitViewModel> ItemUnit { get; set; }
    }
}
