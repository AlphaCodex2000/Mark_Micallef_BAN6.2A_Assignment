using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CartRepository : iCartRepository
    {
        ShoppingCartDbContext _context;
        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public IQueryable<Cart> GetCarts(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
