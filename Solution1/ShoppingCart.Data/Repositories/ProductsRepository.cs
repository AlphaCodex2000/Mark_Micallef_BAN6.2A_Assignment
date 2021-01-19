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
    public class ProductsRepository : iProductRepository
    {
        ShoppingCartDbContext _context;
        public ProductsRepository(ShoppingCartDbContext context)
        {
            _context =  context;
        }

        public Guid AddProduct(Product p)
        {
            // p.Category = null; //because the runtime thinks that the Catergory needs to be added as well.

            //to add a product
            _context.Products.Add(p);
            _context.SaveChanges();

            return p.Id; 
        }

        public void DeleteProduct(Guid id)
        {
            //To get product ID and delete the product
            Product p = GetProduct(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.Where(p => p.Disabled == false).Include(x => x.Category).SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
                return _context.Products.Where(p => p.Disabled == false).Include(x => x.Category);
            
        }

        public void HideProduct(Guid id)
        {
            GetProduct(id).Disabled = true;
            _context.SaveChanges();
        }
    }
}
