using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class InvoiceEditViewModel
    {
        [Required(ErrorMessage = "ID Is Required")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Date Is Required")]
        public DateTime Date { get; set; } 
        [Required(ErrorMessage = "Total Is Required")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "Net Is Required")]
        public decimal Net { get; set; }
        [Required(ErrorMessage = "Taxes Is Required")]
        public decimal Taxes { get; set; }
        public IEnumerable<InvoiceItemUnitEditViewModel> InvoiceItemUnit { get; set; }
    }
}
