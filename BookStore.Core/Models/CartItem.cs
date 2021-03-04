using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class CartItem : BaseEntity
    {
        public string CartID { get; set; }
        public string ProductID { get; set; }
        public string Quantity { get; set; }

    }
}
