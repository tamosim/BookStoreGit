using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Product : BaseEntity
    {                
        [Required]
        [StringLength(100)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [StringLength(500)]
        [Required]
        public String Description { get; set; }

        [Required]
        [Range(0,500)]
        public decimal Price { get; set; }
        [Required]
        public String Category { get; set; }
      //  [Required]
        public String Image { get; set; }
        [Required]
        [StringLength(100)]
        public String Author { get; set; }
    }
}
