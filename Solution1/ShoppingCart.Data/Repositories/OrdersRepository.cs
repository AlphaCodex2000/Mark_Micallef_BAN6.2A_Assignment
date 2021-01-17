using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    class OrdersRepository : iOrderRepository
    {
        ShoppingCartDbContext _context;
        public OrdersRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
