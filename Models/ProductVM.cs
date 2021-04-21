using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEmos.Models
{
    public class ProductVM
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Product Price")]
        [Required]
        public int price { get; set; }
    }
}
