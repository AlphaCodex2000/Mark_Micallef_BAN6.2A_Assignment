using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private iOrderDetailRepository _orderRepo;
        private iCartRepository _cartRepo;
        private IMapper _autoMapper;
        private iOrderDetailRepository _orderDetailRepo;
        public OrderDetailService(iOrderDetailRepository orderRepo, IMapper autoMapper, iCartRepository cartRepo, iOrderDetailRepository orderDetailRepository)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _autoMapper = autoMapper;
            _orderDetailRepo = orderDetailRepository;
        }

        public void Checkout(OrderDetail model)
        {
            throw new NotImplementedException();
        }

        public void CheckoutDetail(OrderDetail model)
        {
            throw new NotImplementedException();
            //_orderDetailRepo.Checkout(_autoMapper.Map<OrderDetail>(model));
        }

        public OrderDetailViewModel GetOrderDetail(OrderDetailViewModel model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderViewModel> GetOrderDetails()
        {
            throw new NotImplementedException();
        }
    }
}
