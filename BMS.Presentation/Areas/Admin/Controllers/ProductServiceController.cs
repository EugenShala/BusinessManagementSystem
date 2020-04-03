using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMS.BusinessLogic.Infrastructure;
using BMS.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductServiceController : Controller
    {
        private readonly IProductService _productService;

        public ProductServiceController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index()
        {
            var service = _productService.GetAllService();
            return View(service);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createService = new ProductService();
            return View(createService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductService service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productService.Add(service);
            try
            {
                _productService.Save();
            }
            catch (Exception ex)
            {
                return View();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductService service = _productService.GetById(id);
            if (service == null)
            {
                throw new Exception("Product Service Not Found !");
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductService service)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            _productService.Update(service);
            _productService.Save();
            return RedirectToAction("Index", "ProductService", "Admin");
        }



        [HttpGet]
        public IActionResult DeleteDepartment(int id)
        {
            var deleteService = _productService.GetById(id);

            return View(deleteService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDepartment(int id, ProductService service)
        {
            var deleteService = _productService.GetById(id);
            _productService.Delete(id);
            _productService.Save();
            return RedirectToAction("Index");
        }
    }
}