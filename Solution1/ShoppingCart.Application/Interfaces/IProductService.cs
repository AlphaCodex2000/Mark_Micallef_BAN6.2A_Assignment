using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductViewModel> GetProducts();
        IQueryable<ProductViewModel> GetProducts(Guid category);

        ProductViewModel GetProduct(Guid id);

        void AddProduct(ProductViewModel model);

        void DeleteProduct(Guid id);

    }
}
