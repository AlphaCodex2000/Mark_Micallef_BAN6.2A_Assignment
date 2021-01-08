using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationApp.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _prodService;
        private iCategoryService _catService;
        private IWebHostEnvironment _env;
        public ProductsController(IProductService prodService, iCategoryService categoryService, IWebHostEnvironment env)
        {
            _prodService = prodService;
            _catService = categoryService;
            _env = env;
        }
        public IActionResult Index()
        {
            try
            {

                var list = _prodService.GetProducts();
                return View(list);
            }
            catch
            {
                TempData["Warning"] = "Failed to load products. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }

        /*public IActionResult Next()
        {
            int batchNo = 0;
            string page = HttpContext.Session.GetString("batchNo");

            if (page == null)(batch = 0; ....)
            {
                batchNo = 0;
            }
            else 
            {
                batchNo = Convert.ToInt32(HttpContext.Session.GetString("batchNo"));
                batchNo += 10;

                var list = _prodService.GetProducts().Skip(batchNo).Take(10);

                HttpContext.Session.SetString("batchNo", batchNo.ToString());
                return View ("Index", list);
            }
        }*/

        public IActionResult Details(Guid id)
        {
            return View(_prodService.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Search(string category) //view you have to use a Form
        {
            var list = _prodService.GetProducts(category);
            return View("Index", list);
        }
        //--------------------------ADD------------------------------

        [HttpGet] //this will be called before loading the Create page
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var list = _catService.GetCategories();

            CreateModel model = new CreateModel();
            model.Categories = list.ToList();

            return View(model);

        }

        [HttpPost] //2nd method will be triggered when the user clicks on the submit buttom
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateModel data) //postman, fiffler, burp, zap
        {
            try
            {
                if(data.File != null)
                {
                    if(data.File.Length > 0)
                    {
                        string newFilename = @"/Images/" + Guid.NewGuid() + System.IO.Path.GetExtension(data.File.FileName);
                        string absolutePath = _env.WebRootPath;

                        //absolute path -> //C:\Users\markm\source\repos\BAN6.2A_EnterpriseProgramming\BAN6.2A_EnterpriseProgramming\Solution1\PresentationApp\wwwroot\Images\

                        using (var stream = System.IO.File.Create(absolutePath + newFilename))
                        {
                            data.File.CopyTo(stream);
                        }
                        data.Product.ImageURL = newFilename;
                    }
                }


                _prodService.AddProduct(data.Product);
                TempData["feedback"] = "Product added successfully";
                ModelState.Clear();
            }
            catch(Exception ex)
            {
                TempData["warning"] = "Product was not added successfully. Check the information inputted";
            }
            //validation
            var list = _catService.GetCategories();
            data.Categories = list.ToList();
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            _prodService.DeleteProduct(id);

            TempData["feedback"] = "product deleted successfully"; //View data should be changed to TempData

            return RedirectToAction("Index");
        }
    }
}
