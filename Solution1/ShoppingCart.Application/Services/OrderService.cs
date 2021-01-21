using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderService : IOrderService
    {
        private iOrderRepository _orderRepo;
        private IMapper _autoMapper;
        public OrderService(iOrderRepository orderRepo, IMapper autoMapper)
        {
            _orderRepo = orderRepo;
            _autoMapper = autoMapper;
        }

        public OrderViewModel GetOrder(Guid id)
        {
            var o = _orderRepo.GetOrders(id);
            if (o == null)
            {
                return null;
            }

            else

            {
                var result = _autoMapper.Map<OrderViewModel>(o);
                return result;

            }
        }
    }
}
