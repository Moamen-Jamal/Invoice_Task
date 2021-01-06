using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Store : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
