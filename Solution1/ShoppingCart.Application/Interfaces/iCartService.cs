﻿using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface iCartService
    {
        IQueryable<CartViewModel> GetCarts();
        IQueryable<CartViewModel> GetCarts(Guid id);
        CartViewModel GetCart(Guid id);

        void addToCart(Guid productId, int qty, string Email);
    }
}
