using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Range(0,400)]
        public double Price { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Shade Color")]
        public string ShadeColor { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
