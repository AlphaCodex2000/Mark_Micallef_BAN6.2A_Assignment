using ShoppingCart.Domain.Models;
using System;
using System.Linq;

namespace ShoppingCart.Domain.Interfaces
{
    public interface iProductRepository
    {
        Product GetProduct(Guid id);

        IQueryable<Product> GetProducts();

        Guid AddProduct(Product p);

        void DeleteProduct(Guid id);
        void HideProduct(Guid id);
    }
}
