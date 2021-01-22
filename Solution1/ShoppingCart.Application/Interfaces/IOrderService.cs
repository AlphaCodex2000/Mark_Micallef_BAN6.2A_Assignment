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
        void CheckoutOrder(OrderViewModel model);
        OrderViewModel GetOrder(Guid id);
    }
}
