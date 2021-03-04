using BookStore.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ICartService cartService;
        public CartController(ICartService CartService)
        {
            this.cartService = CartService;
        }
        public ActionResult Index()
        {
            var model = cartService.GetCartItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToCart(string Id)
        {
            cartService.AddToCart(this.HttpContext,Id);
            return RedirectToAction("Index");          
        }

        public ActionResult RemoveFromCart(string Id)
        {
            cartService.RemoveItem(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult CartSummary()
        {
            var cartsummary = cartService.GetCartSummary(this.HttpContext);
            return PartialView(cartsummary);
        }
    }
}