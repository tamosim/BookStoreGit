using BookStore.Core.Contracts;
using BookStore.Core.Models;
using BookStore.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategoryManager
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context = context;
        }
        
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productcategory = new ProductCategory();
            return View(productcategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productcategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productcategory);
            }
            else
            {
                context.Insert(productcategory);
                context.Save();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            ProductCategory productcategory = context.Find(ID);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory, string ID)
        {
            ProductCategory ProductCategoryToEdit = context.Find(ID);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productcategory);
                }
                else
                {
                    ProductCategoryToEdit.CategoryName = productcategory.CategoryName;
                    context.Save();
                    return RedirectToAction("Index");
                }
            }

        }
        public ActionResult Delete(string ID)
        {
            ProductCategory ProductCategoryToDelete = context.Find(ID);
            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            ProductCategory ProductCategoryToDelete = context.Find(ID);
            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Save();
                return RedirectToAction("Index");
            }
        }
    }
}