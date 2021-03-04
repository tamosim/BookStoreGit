using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.ViewModels
{
    public class CartSummaryViewModel
    {
        public int CartCount { get; set; }
        public decimal CartTotal { get; set; }

        public CartSummaryViewModel(int cartCount, decimal carttotal)
        {
            this.CartCount = cartCount;
            this.CartTotal = carttotal;
        }
    }
}
