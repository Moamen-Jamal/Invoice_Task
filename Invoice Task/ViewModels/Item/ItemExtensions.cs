using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public static class ItemExtensions
    {
        public static ItemViewModel ToViewModel(this Item model)
        {
            return new ItemViewModel
            {
                ID = model.ID,
                Name = model.Name,
                StoreID = model.StoreID,
                StoreName = model.Store.Name,
                ItemUnit = model.ItemUnits.Where(i => i.ItemID == model.ID).Select(i => i.ToViewModel()).ToList(),
            };
        }

        public static Item ToModel(this ItemEditViewModel editModel)
        {
            return new Item
            {
                ID = editModel.ID,
                Name = editModel.Name,
                StoreID = editModel.StoreID,
                
            };
        }
        public static ItemEditViewModel ToEditableModel(this Item model)
        {
            return new ItemEditViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }
    }
}
