using Entities;
using System;
using System.Collections.Generic;
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
                Net = model.Net
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
                Net = editModel.Net
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
                Net = model.Net
            };
        }
    }
}
