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

            var list = _cartservice.GetCarts();
            CatalogModel mdel = new CatalogModel() { Carts = list, Products = _prodService.GetProducts(), Categories = _catService.GetCategories() };
            string user = User.Identity.Name;
            return View(mdel);
            //get all the items in cart for the logged in user
            //string user = User.Identity.Name;

        }

        
        [HttpPost][Authorize]
        //public IActionResult AddtoCart (Guid productId, int qty)
        public IActionResult AddtoCart(Guid productId, int qty, string Email)
        {
            string user = User.Identity.Name;
            _cartservice.addToCart(productId, qty, Email);
            TempData["feedback"] = "Added Product to Cart";

           //code to add to cart
           //CartViewModel

           return RedirectToAction("Index");
        }
    }
}
