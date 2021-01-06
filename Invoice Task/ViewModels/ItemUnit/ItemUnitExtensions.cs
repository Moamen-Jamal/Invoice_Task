using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public static class ItemUnitUnitExtensions
    {
        public static ItemUnitViewModel ToViewModel(this ItemUnit model)
        {
            return new ItemUnitViewModel
            {
                ID = model.ID,
                Price = model.Price,
                ItemID = model.ItemID,
                ItemName = model.Item.Name,
                UnitID = model.UnitID,
                UnitName = model.Unit.Name
            };
        }

        public static ItemUnit ToModel(this ItemUnitEditViewModel editModel)
        {
            return new ItemUnit
            {
                ID = editModel.ID,
                Price = editModel.Price,
                ItemID = editModel.ItemID,
                UnitID = editModel.UnitID,

            };
        }
        public static ItemUnitEditViewModel ToEditableModel(this ItemUnit model)
        {
            return new ItemUnitEditViewModel
            {
                ID = model.ID,
                Price = model.Price,
                ItemID = model.ItemID,
                ItemName = model.Item.Name,
                UnitID = model.UnitID,
                UnitName = model.Unit.Name
            };
        }
    }
}
