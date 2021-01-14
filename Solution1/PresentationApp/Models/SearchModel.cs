using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApp.Models
{
    public class SearchModel
    {
        //public ProductViewModel Product { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public int SelectedCategory { get; set; }
    }
}