using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderService
    {
        IQueryable<OrderViewModel> GetOrders();
        //public void Checkout(int Id, Guid ProductFK, Guid OrderFK, int qty, double price);
        public void Checkout(OrderViewModel model);
        //public void Checkout(Guid Id, DateTime DatePlaced, string Email);
        OrderViewModel GetOrder(Guid id);
    }
}
