﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Domain.Interfaces
{
    public interface iOrderDetailRepository
    {
        Order GetOrder(Guid id);
        IQueryable<Order> GetOrders();
        Guid Checkout(Order o);
    }

}
