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
    public class OrdersRepository : iOrderDetailRepository
    {
        ShoppingCartDbContext _context;
        public OrdersRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Order GetOrder(Guid id)
        {
            return _context.Orders.Include(x => x.Id).SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders.Include(x => x.Id);
        }

        public IQueryable<Order> GetOrder()
        {
            return _context.Orders.Include(x => x.Id);
        }

        public Guid Checkout(Order o)
        {

            o.Id = Guid.NewGuid();
            _context.Orders.Add(o);
            _context.SaveChanges();

            return o.Id;
        }
    }
}