using JDS_PRICELIST_2021.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDS_PRICELIST_2021.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }
        public IActionResult UpdateProduct(int id)
        {
            products prod = repo.GetProduct(id);
            if(prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(products product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ItemID });
        }
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignItem();

            return View(prod);
            
        }
        public IActionResult InsertProductToDatabase(products productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(products product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
