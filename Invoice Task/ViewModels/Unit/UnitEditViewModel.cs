using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class UnitEditViewModel
    {
        [Required(ErrorMessage = "ID Is Required")]
        public int ID { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Max Must Be 500 Chars.")]
        [MinLength(3)]
        public string Name { get; set; }
        public IList<ItemUnitEditViewModel> ItemUnit { get; set; }
    }
}
