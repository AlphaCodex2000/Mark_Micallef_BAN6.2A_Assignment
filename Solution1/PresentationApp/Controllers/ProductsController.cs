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
using Microsoft.AspNetCore.Session;

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
                CatalogModel mdel = new CatalogModel() { Products = list, Categories = _catService.GetCategories() };
                return View(mdel);
            }
            catch
            {
                TempData["Warning"] = "Failed to load products. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }
        

        public IActionResult Details(Guid id)
        {
            try { 
                return View(_prodService.GetProduct(id));
            }
            catch
            {
                TempData["Warning"] = "Failed to load details. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }

        /*public IActionResult Hide(Guid id)
        {
            try
            {
                
            }
            catch
            {
                TempData["Warning"] = "Failed to load details. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }*/


        // Search Function

        [HttpPost]
        public IActionResult Search (Guid SelectedCategory) //view you have to use a Form
        {
            //1. perform the search therefore you have to return in to a list products by category
            //2. CatalogModel
            try
            {
                var list = _prodService.GetProducts(SelectedCategory);
                CatalogModel mdel = new CatalogModel() { Products = list, Categories = _catService.GetCategories() };
                return View("Index", mdel);
            }
            catch
            {
                TempData["Warning"] = "Failed to Search for products. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }

        //--------------------------ADD------------------------------

        [HttpGet] //this will be called before loading the Create page
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            try
            {
                var list = _catService.GetCategories();

                CreateModel model = new CreateModel();
                model.Categories = list.ToList();

                return View(model);
            }
            catch
            {
                TempData["Warning"] = "Failed to Create Product. Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost] //2nd method will be triggered when the user clicks on the submit buttom
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateModel data) //fiffler, burp, zap
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

            try
            {
                _prodService.DeleteProduct(id);

                TempData["feedback"] = "product deleted successfully"; //View data should be changed to TempData

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Warning"] = "Failed to Delete Product. Please try again later";
                return RedirectToAction("Error", "Home");
            }


        }

        [Authorize(Roles = "Admin")]
        public IActionResult Hide(Guid Id)
        {
            _prodService.HideProduct(Id);
            TempData["feedback"] = "product Hidden ";
            return RedirectToAction("Index");
        }

        public IActionResult Next()
            
        {

            int index = 0;
            List<ProductViewModel> list = new List<ProductViewModel>();
            string page = HttpContext.Session.GetString("positionOfRecordBeingDisplayed");

            if (page == null)
            {
                index = 0;
                list = _prodService.GetNextProduct(10, index).ToList();

            }

            else
            {
                index = Convert.ToInt32(HttpContext.Session.GetString("positionOfRecordBeingDisplayed"));
                index += 10;
                list = _prodService.GetNextProduct(10, index).ToList();

                HttpContext.Session.SetString("positionOfRecordBeingDisplayed", index.ToString());
                
            }
            return View("Index", list);

        }

        public IActionResult Previous()

        {

            int index = 0;
            List<ProductViewModel> list = new List<ProductViewModel>();
            string page = HttpContext.Session.GetString("positionOfRecordBeingDisplayed");

            if (page == null)
            {
                index = 0;
                list = _prodService.GetNextProduct(10, index).ToList();

            }

            else
            {
                index = Convert.ToInt32(HttpContext.Session.GetString("positionOfRecordBeingDisplayed"));
                index += 10;
                list = _prodService.GetNextProduct(10, index).ToList();

                HttpContext.Session.SetString("positionOfRecordBeingDisplayed", index.ToString());

            }
            return View("Index", list);

        }
    }
}
