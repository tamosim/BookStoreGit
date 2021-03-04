using BookStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Core.Contracts
{
    public interface ICartService
    {
        void AddToCart(HttpContextBase httpcontext, string ProductId);
        void RemoveItem(HttpContextBase httpcontext, string itemid);
        List<CartItemViewModel> GetCartItems(HttpContextBase httpcontext);
        CartSummaryViewModel GetCartSummary(HttpContextBase httpcontext);
    }
}
