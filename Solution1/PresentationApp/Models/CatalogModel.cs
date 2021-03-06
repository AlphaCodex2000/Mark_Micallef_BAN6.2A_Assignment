﻿using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationApp.Models
{
    public class CatalogModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<CartViewModel> Carts { get; set; }
        public IEnumerable<OrderViewModel> Orders{ get; set; }
    }
}
