using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public virtual Store Store { get; set; }
        public int StoreID { get; set; }
        public virtual ICollection<ItemUnit> ItemUnits { get; set; }
    }
}
