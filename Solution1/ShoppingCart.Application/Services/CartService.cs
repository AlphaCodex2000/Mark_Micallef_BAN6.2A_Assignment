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
    public class CartService : iCartService
    {
        private iCartRepository _cartRepo;
        private IMapper _autoMapper;
        public CartService (iCartRepository cartRepo, IMapper autoMapper)
        {
            _cartRepo = cartRepo;
            _autoMapper = autoMapper;
        }

        public void addToCart(CartViewModel model)
        {
            _cartRepo.addToCart(_autoMapper.Map<Cart>(model));
        }

        public CartViewModel GetCart(Guid id)
        {
            var c = _cartRepo.GetCart(id);
            if (c == null)
            {
                return null;
            }

            else

            {
                var result = _autoMapper.Map<CartViewModel>(c);
                return result;

            }
        }

        public IQueryable<CartViewModel> GetCarts()
        {
            return _cartRepo.GetCarts().ProjectTo<CartViewModel>(_autoMapper.ConfigurationProvider);
        }

        public IQueryable<CartViewModel> GetCarts(Guid id)
        {
            return _cartRepo.GetCarts().Where(c => c.ProductFK == id)
                    .ProjectTo<CartViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
