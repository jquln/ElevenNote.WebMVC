using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryEdit
    {
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Display(Name ="Category Name")]
        public string CategoryName {  get; set; }

    }
}
