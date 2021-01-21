using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PresentationApp.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApp.Controllers
{
    public class CartController : Controller
    {
        private IProductService _prodService;
        private iCategoryService _catService;
        private IWebHostEnvironment _env;
        private iCartService _cartservice;


        public CartController(IProductService prodService, iCategoryService categoryService, IWebHostEnvironment env, iCartService cartService)
        {
            _prodService = prodService;
            _catService = categoryService;
            _env = env;
            _cartservice = cartService;
        }

      
        public IActionResult Index()

        {
            try
            {
                var list = _cartservice.GetCarts();
                CatalogModel mdel = new CatalogModel() { Carts = list, Products = _prodService.GetProducts(), Categories = _catService.GetCategories() };
                string user = User.Identity.Name;
                return View(mdel);
            }
            catch
            {
                TempData["Warning"] = "Failed to load Index, Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost][Authorize]
        public IActionResult AddtoCart(Guid productId, int qty, string Email)
        {
            try
            {
                string user = User.Identity.Name;
                _cartservice.addToCart(productId, qty, Email);
                TempData["feedback"] = "Added Product to Cart";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Warning"] = "Failed to add Product to Cart, Please try again later";
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
