using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.BLL.Logic.Models;
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
            List<ProductDTO> products = _productRepository.GetAllProducts().ToList();
            ViewBag.Title = "Products";

            return View(products);
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            ProductDTO product = _productRepository.GetProductById(id);

            ProductDetailsViewModel productVM = new ProductDetailsViewModel();
            productVM.ProductId = product.Id;
            productVM.PageTitle = "Product details";
            productVM.Name = product.Name;
            productVM.ProductDescription = product.ProductDescription;
            productVM.Price = product.Price;
            productVM.Discounted = product.Discounted;
            productVM.Active = product.Active;
            productVM.Deleted = product.Deleted;
            productVM.ProductImage = product.ImagePath;

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
                string uniqueFileName = "defaultPizza.jpg";
                if (model.PicturePath != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PicturePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PicturePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                ProductDTO product = new ProductDTO
                {
                    Name = model.ProductName,
                    Price = model.UnitPrice,
                    Discounted = model.IsDiscounted,
                    Active = model.IsActive,
                    Deleted = model.IsDeleted,
                    ProductSize = model.Size,
                    ProductDescription = model.Description,
                    ImagePath = "~/img/" + uniqueFileName
                };
                ProductDTO newProduct = _productRepository.Add(product);
                return RedirectToAction("List");
            } else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ProductDTO product = _productRepository.GetProductById(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductDescription = product.ProductDescription
            };
            return View(productEditViewModel);
        }

        //[HttpPost]
        //[Route("Edit/{id}")]
        //public IActionResult Edit(int id, ProductEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ProductDTO product = _productRepository.GetProductById(id);
        //        product.Name = model.Name;
        //        product.ProductDescription = model.ProductDescription;
        //        product.Price = model.Price;
        //        product.Active = model.Active;
        //        product.Deleted = model.Deleted;
        //        product.Discounted = model.Discounted;

        //        string uniqueFileName = "defaultPizza.jpg";
        //        if (model.Picture != null)
        //        {
        //            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
        //        }
        //        product.ImagePath = "~/img/" + uniqueFileName;
                
        //        ProductDTO newProduct = _productRepository.Update(product);
        //        return RedirectToAction("List");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
