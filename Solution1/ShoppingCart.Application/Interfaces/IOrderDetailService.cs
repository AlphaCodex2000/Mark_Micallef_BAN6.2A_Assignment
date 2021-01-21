using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailService
    {
        public void Checkout(int Id, Guid ProductFk, Guid OrderFK, int qty, double Price);
    }
}
