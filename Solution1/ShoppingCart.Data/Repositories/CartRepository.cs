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
    public class CartRepository : iCartRepository
    {
        ShoppingCartDbContext _context;
        public CartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Cart GetCart(Guid id)
        {
            return _context.Carts.Include(x => x.Product).SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Cart> GetCart()
        {
            return _context.Carts.Include(x => x.Product);
        }

        public IQueryable<Cart> GetCarts()
        {
            return _context.Carts.Include(x => x.Product);
        }
        public Guid addToCart(Cart c)
        {
            _context.Carts.Add(c);
            _context.SaveChanges();

            return c.Id;
        }
    }
}
