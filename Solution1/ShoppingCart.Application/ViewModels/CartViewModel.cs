using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CartViewModel
    {

        public Guid Id { get; set; }

        public string Email { get; set; }

        public Guid ProductFK { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
