﻿using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailService
    {
        IQueryable<OrderViewModel> GetOrderDetails();
        OrderDetailViewModel GetOrderDetail(OrderDetailViewModel model);
        public void Checkout(OrderDetail model);
    }
}
