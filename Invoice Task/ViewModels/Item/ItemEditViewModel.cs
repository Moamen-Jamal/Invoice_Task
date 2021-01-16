using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class ItemEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public IList<ItemUnitEditViewModel> ItemUnit { get; set; }
    }
}
