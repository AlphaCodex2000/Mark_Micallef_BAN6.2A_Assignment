using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository : iOrderRepository
    {
        ShoppingCartDbContext _context;
        public OrdersRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Order GetOrder(Guid Id)
        {
            return _context.Orders.Include(x => x.Id).SingleOrDefault(x => x.Id == Id);
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders.Include(x => x.Id);
        }

        public IQueryable<Order> GetOrders(Guid Id)
        {
            return _context.Orders.Include(x => x.Id);
        }

    }
}
