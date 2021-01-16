using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public static class InvoiceExtensions
    {
        public static InvoiceViewModel ToViewModel(this Invoice model)
        {
            return new InvoiceViewModel
            {
                ID = model.ID,
                Date = model.Date,
                Total = model.Total,
                Taxes = model.Taxes,
                Net = model.Net,
                InvoiceItemUnit = model.InvoiceItemUnits.Select(i => i.ToViewModel())
            };
        }

        public static Invoice ToModel(this InvoiceEditViewModel editModel)
        {
            return new Invoice
            {
                ID = editModel.ID,
                Date = editModel.Date,
                Total = editModel.Total,
                Taxes = editModel.Taxes,
                Net = editModel.Net,
                InvoiceItemUnits = editModel.InvoiceItemUnit.Select(i => i.ToModel()).ToList()
            };
        }
        public static InvoiceEditViewModel ToEditableModel(this Invoice model)
        {
            return new InvoiceEditViewModel
            {
                ID = model.ID,
                Date = model.Date,
                Total = model.Total,
                Taxes = model.Taxes,
                Net = model.Net,
                InvoiceItemUnit = model.InvoiceItemUnits.Select(i => i.ToEditableModel())
            };
        }
    }
}
