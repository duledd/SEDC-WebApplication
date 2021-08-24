using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using SEDC_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private List<Product> products;

        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
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
            productVM.ProductImage = product.PicturePath;

            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "avatar.png";
                if (model.PicturePath != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PicturePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PicturePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Product product = new Product
                {
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    IsDiscounted = model.IsDiscounted,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    Size = model.Size,
                    Description = model.Description,
                    PicturePath = "~/img/" + uniqueFileName
                };
                Product newProduct = _productRepository.Add(product);
                return RedirectToAction("List");
            } else
            {
                return View();
            }
        }



        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            Product product = _productRepository.GetProductById(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                ProductId = product.Id,
                Name = product.ProductName,
                Price = product.UnitPrice,
                ProductDescription = product.Description
            };
            return View(productEditViewModel);
        }

        //[HttpPost]
        //[Route("Edit/{id}")]
        //public IActionResult Edit(ProductEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Product product = _productRepository.GetProductById(model.ProductId);
        //        product.ProductName = model.Name;
        //        product.Description = model.ProductDescription;
        //        product.UnitPrice = model.Price;
        //        product.IsActive = model.Active;
        //        product.IsDeleted = model.Deleted;
        //        product.IsDiscounted = model.Discounted;

        //        string uniqueFileName = "defaultPizza.png";
        //        if (model.Picture != null)
        //        {
        //            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
        //        }
        //        Product productUp = new Product
        //        {
        //            ProductName = model.Name,
        //            UnitPrice = model.Price,
        //            IsDiscounted = model.Discounted,
        //            IsActive = model.Active,
        //            IsDeleted = model.Deleted,
        //            Size = model.ProductSize,
        //            Description = model.ProductDescription,
        //            PicturePath = "~/img/" + uniqueFileName
        //        };
        //        Product newProduct = _productRepository.Add(productUp);
        //        return RedirectToAction("List");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
