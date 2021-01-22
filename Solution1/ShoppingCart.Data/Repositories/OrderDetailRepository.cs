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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        ShoppingCartDbContext _context;
        public OrderDetailRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            return _context.OrderDetails.Include(x => x.Id);
        }
        public int Checkout(OrderDetail od)
        {

            
            _context.OrderDetails.Add(od);
            _context.SaveChanges();

            return od.Id;
        }

    }
}