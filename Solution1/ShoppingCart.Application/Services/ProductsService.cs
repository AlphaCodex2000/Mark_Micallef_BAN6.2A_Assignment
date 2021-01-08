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
    public class ProductsService : IProductService
    {
        private iProductRepository _productsRepo;
        private IMapper _autoMapper;
        public ProductsService(iProductRepository productsRepo, IMapper autoMapper)
        {
            _productsRepo = productsRepo;
            _autoMapper = autoMapper;
        }

        public void AddProduct(ProductViewModel model)
        {
            //ProductViewModel >>>>>>>>> Product

            /*Product p = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                ImageURL = model.ImageURL,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.Category.Id
            };

            _productsRepo.AddProduct(p);
            */

            _productsRepo.AddProduct(_autoMapper.Map<Product>(model));
        }

        public void DeleteProduct(Guid id)
        {
            _productsRepo.DeleteProduct(id);
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var p = _productsRepo.GetProduct(id);
            if (p == null)
            {
                return null;
            }

            else
                
                {/*
                    return new ProductViewModel()
                    {
                        Id = p.Id,
                        Description = p.Description,
                        ImageURL = p.ImageURL,
                        Name = p.Name,
                        Price = p.Price,

                        Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                    };
                */

                var result = _autoMapper.Map<ProductViewModel>(p);
                return result;

            }
                
                
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            //this whole method will use linq to convery from IQueryable<Product> to IQueryable<ProductViewModel>
            /* var list = from p in _productsRepo.GetProducts()
                        select new ProductViewModel()
                        {
                            Id = p.Id,
                            Description = p.Description,
                            ImageURL = p.ImageURL,
                            Name = p.Name,
                            Price = p.Price,
                            Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                        };
             return list;*/

            //IQueryable<Product> >>>>>>> IQueryable<ProductViewModel>
            return _productsRepo.GetProducts().ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);
        }
        
        public IQueryable<ProductViewModel> GetProducts(string category)
        {
            return _productsRepo.GetProducts().Where(p => p.Description.Contains(category)
                                                     || p.Name.Contains(category))
                    .ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);

        }

    }
}
