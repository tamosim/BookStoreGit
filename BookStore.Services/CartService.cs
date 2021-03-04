using BookStore.Core.Contracts;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Services
{
    public class CartService
    {
        //added reference system.web

        IRepository<Product> productContext;
        IRepository<Cart> cartContext;
        public const string CartSesionName = "eCommerceCart";
        public CartService(IRepository<Product> ProductContext,IRepository<Cart> CartContext)
        {
            this.cartContext = CartContext;
            this.productContext = ProductContext;
        }

        private Cart GetCart(HttpContextBase httpContext, bool CreateIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(CartSesionName);
            Cart cart = new Cart();
            if (cookie != null)//user has cookie
            {
                string cartid = cookie.Value;
                if (!string.IsNullOrEmpty(cartid))//cookie has id, user has cart
                {
                    cart = cartContext.Find(cartid);
                }
                else
                {
                    if (CreateIfNull)//cookie is empty , ccreate new cart
                    {
                        cart = CreateNewCart(httpContext);
                    }
                }
            }
            else//user doesnt have cookie create new cart
            {
                if (CreateIfNull)
                {
                    cart = CreateNewCart(httpContext);
                }
            }
            return cart;
        }

        private Cart CreateNewCart(HttpContextBase httpContext)
        {
            Cart cart = new Cart();
            cartContext.Insert(cart);
            cartContext.Save();

            HttpCookie cookie = new HttpCookie(CartSesionName);
            cookie.Value = cart.ID;
            cookie.Expires.AddMonths(1);
            httpContext.Response.Cookies.Add(cookie);

            return cart;
        }

        public void AddToCart(HttpContextBase httpcontext, string ProductId)
        {
            Cart cart = GetCart(httpcontext, true);
            CartItem item = cart.CartItems.FirstOrDefault(i => i.ProductID == ProductId);

            if (item == null)//item doesn exist in cart so add it 
            {
                item = new CartItem()
                {
                    CartID = cart.ID,
                    ProductID = ProductId,
                    Quantity = 1,
                };
                cart.CartItems.Add(item);
            }
            else// item exists in cart so increase quantity
            {
                item.Quantity = item.Quantity + 1;
            }
            cartContext.Save();
        }
        public void RemoveItem(HttpContextBase httpcontext, string itemid)
        {
            Cart cart = GetCart(httpcontext, true);
            CartItem item = cart.CartItems.FirstOrDefault(i => i.ID == itemid);

            if (item != null)//item exist in basket so remove it 
            {
                cart.CartItems.Remove(item);
                cartContext.Save();
            }
        }


    }
}
