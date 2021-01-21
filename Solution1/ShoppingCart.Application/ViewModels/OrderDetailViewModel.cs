using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public Guid ProductFK { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderFk { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
