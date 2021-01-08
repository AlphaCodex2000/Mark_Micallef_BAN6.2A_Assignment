using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class ProductViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please input name of product")]
        public string Name { get; set; }
        public string Description { get; set; }

        //validation to have positive value
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public CategoryViewModel Category { get; set; }

        public string ImageURL { get; set; }

        //public List<CategoryViewModel> Categories { get; set; }

        public int Stock { get; set; }
    }
}
