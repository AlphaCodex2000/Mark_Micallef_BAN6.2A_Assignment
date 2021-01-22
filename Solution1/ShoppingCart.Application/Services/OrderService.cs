using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class OrderService : IOrderService
    {
        private iOrderDetailRepository _orderRepo;
        private iCartRepository _cartRepo;
        private IMapper _autoMapper;
        public OrderService(iOrderDetailRepository orderRepo, IMapper autoMapper, iCartRepository cartRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _autoMapper = autoMapper;
        }

        public void CheckoutOrder(OrderViewModel model)
        {
            //OrderViewModel myModel = new OrderViewModel() {Id = Id, DatePlaced = DatePlaced, Email = Email};
            _orderRepo.Checkout(_autoMapper.Map<Order>(model));
        }



        public OrderViewModel GetOrder(Guid id)
        {
            var o = _orderRepo.GetOrder(id);
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

        public IQueryable<OrderViewModel> GetOrders()
        {
            return _orderRepo.GetOrders().ProjectTo<OrderViewModel>(_autoMapper.ConfigurationProvider);
        }

        public IQueryable<OrderViewModel> GetOrders(Guid id)
        {
            return _orderRepo.GetOrders().Where(o => o.Id == id)
                    .ProjectTo<OrderViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
