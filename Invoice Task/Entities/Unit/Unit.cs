using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Unit : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<ItemUnit> ItemUnits { get; set; }
    }
}
