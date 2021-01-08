using Microsoft.AspNetCore.Mvc;

namespace PresentationApp.Controllers
{
    public class SupportController : Controller
    {
        [HttpGet] //role is to load the page
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost] //role is to receive data from a Form submission
        public ActionResult Contact(string email, string query)
        {
            //stpre in db or inform the person in charge
            if (string.IsNullOrEmpty(query) || string.IsNullOrEmpty(email))
            {
                ViewData["warning"] = "One of the fields is empty";
            }
            else
            {
                ViewData["feedback"] = "Thanks for your query. We will revert back with a reply very soon";
            }
            return View();
        }

    }
}
