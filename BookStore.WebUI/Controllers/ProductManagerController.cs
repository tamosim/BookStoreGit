﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Core.Models;
using BookStore.DataAccess.InMemory;

namespace BookStore.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else 
            {
                context.Insert(product);
                context.Save();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            Product product = context.Find(ID);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string ID)
        {
            Product ProductToEdit = context.Find(ID);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    ProductToEdit.Category = product.Category;
                    ProductToEdit.Description = product.Description;
                    ProductToEdit.Image = product.Image;
                    ProductToEdit.Name = product.Name;
                    ProductToEdit.Price = product.Price;
                    ProductToEdit.Author = product.Author;
                    context.Save();

                    return RedirectToAction("Index");
                }
            }
            
        }
        public ActionResult Delete(string ID)
        {
            Product ProductToDelete = context.Find(ID);
            if (ProductToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Product ProductToDelete = context.Find(ID);
            if (ProductToDelete == null)
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