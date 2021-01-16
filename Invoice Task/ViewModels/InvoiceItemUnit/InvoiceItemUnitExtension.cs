using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public static class InvoiceInvoiceItemUnitExtension
    {
        public static InvoiceItemUnitViewModel ToViewModel(this InvoiceItemUnit model)
        {
            return new InvoiceItemUnitViewModel
            {
                ID = model.ID,
                Quantity = model.Quantity,
                ItemUnitID = model.ItemUnitID,
                InvoiceID = model.InvoiceID,
                TotalPrice = model.TotalPrice,
                Discount = model.Discount,
                NetPrice = model.NetPrice
            };
        }

        public static InvoiceItemUnit ToModel(this InvoiceItemUnitEditViewModel editModel)
        {
            return new InvoiceItemUnit
            {
                ID = editModel.ID,
                Quantity = editModel.Quantity,
                ItemUnitID = editModel.ItemUnitID,
                InvoiceID = editModel.InvoiceID,
                TotalPrice = editModel.TotalPrice,
                Discount = editModel.Discount,
                NetPrice = editModel.NetPrice


            };
        }
        public static InvoiceItemUnitEditViewModel ToEditableModel(this InvoiceItemUnit model)
        {
            return new InvoiceItemUnitEditViewModel
            {
                ID = model.ID,
                Quantity = model.Quantity,
                ItemUnitID = model.ItemUnitID,
                InvoiceID = model.InvoiceID,
                TotalPrice = model.TotalPrice,
                Discount = model.Discount,
                NetPrice = model.NetPrice
            };
        }
    }
}
