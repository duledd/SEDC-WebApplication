using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using SEDC_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        //private List<Product> products;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            //products = _productRepository.GetAllProducts().ToList();
        }

        [Route("List")]
        public IActionResult List()
        {
            //ViewData["Products"] = products;
            List<Product> products = _productRepository.GetAllProducts().ToList();
            ViewBag.Title = "Products";

            return View(products);
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            Product product = _productRepository.GetProductById(id);

            ProductDetailsViewModel productVM = new ProductDetailsViewModel();
            productVM.ProductId = product.Id;
            productVM.PageTitle = "Product details";
            productVM.Name = product.ProductName;
            productVM.ProductDescription = product.Description;
            productVM.Price = product.UnitPrice;
            productVM.Discounted = product.IsDiscounted;
            productVM.Active = product.IsActive;
            productVM.Deleted = product.IsDeleted;
            productVM.ProductImage = product.Picture;

            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = _productRepository.Add(product);
                return RedirectToAction("List", new { id = newProduct.Id });
            } else
            {
                return View();
            }
        }
    }
}
