using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class ProductCategory
    {
        public String ID { get; set; }
        public String CategoryName { get; set; }
        public ProductCategory()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
