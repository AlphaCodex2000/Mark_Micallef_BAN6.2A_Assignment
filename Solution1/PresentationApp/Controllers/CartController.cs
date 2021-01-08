using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()

        {
            //get all the items in cart for the logged in user
            //to get the logged in user: string user = User.Identity.Name
            return View();
        }

        [HttpPost][Authorize]
        public IActionResult AddtoCart (Guid productId, int qty)
        {
            string user = User.Identity.Name;

            //code to add to cart
            //CartViewModel

            return RedirectToAction("Index");
        }
    }
}
