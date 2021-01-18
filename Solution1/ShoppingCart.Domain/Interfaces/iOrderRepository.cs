using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces
{
    public interface iOrderRepository
    {
        IQueryable<Order> GetOrders();

    }

}
