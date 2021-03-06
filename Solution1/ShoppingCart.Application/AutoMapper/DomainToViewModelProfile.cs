﻿using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class DomainToViewModelProfile: Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Cart, CartViewModel>();
            CreateMap<Order, OrderViewModel>();

            //Product Class was used to model the database
            //ProductViewModel c;ass was used to pass on the data to/from the Presentation project/layer
        }
    }
}
