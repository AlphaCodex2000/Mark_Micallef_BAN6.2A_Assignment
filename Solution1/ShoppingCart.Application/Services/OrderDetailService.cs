using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private iOrderRepository _orderRepo;
        private iCartRepository _cartRepo;
        private IMapper _autoMapper;
        public OrderDetailService(iOrderRepository orderRepo, IMapper autoMapper, iCartRepository cartRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _autoMapper = autoMapper;
        }

        public void Checkout(int Id, Guid ProductFk, Guid OrderFK, int qty, double Price)
        {
            OrderDetailViewModel myModel = new OrderDetailViewModel() { Id = Id, OrderFk = OrderFK, Quantity = qty, Price = Price };
            _orderRepo.Checkout(_autoMapper.Map<OrderDetail>(myModel));
        }
    }
}
