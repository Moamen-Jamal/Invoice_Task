using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public static class  UnitExtensions
    {
        public static UnitViewModel ToViewModel(this Unit model)
        {
            return new UnitViewModel
            {
                ID = model.ID,
                Name = model.Name,
                ItemUnit = model.ItemUnits.Where(i => i.UnitID == model.ID).Select(i => i.ToViewModel()).ToList(),
            };
        }

        public static Unit ToModel(this UnitEditViewModel editModel)
        {
            return new Unit
            {
                ID = editModel.ID,
                Name = editModel.Name
            };
        }
        public static UnitEditViewModel ToEditableModel(this Unit model)
        {
            return new UnitEditViewModel
            {
                ID = model.ID,
                Name = model.Name
            };
        }
    }
}
