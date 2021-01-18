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

        public IQueryable<ProductViewModel> GetNextProduct(int noOfRecords, int starting)
        {
            var listofProducts = _productsRepo.GetProducts().Skip(starting).Take(noOfRecords);
                return listofProducts.ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);
        }

        public IQueryable<ProductViewModel> GetPreviousProduct(int noOfRecords, int starting)
        {
            var listofProducts = _productsRepo.GetProducts().Skip(starting).Take(noOfRecords);
            return listofProducts.ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var p = _productsRepo.GetProduct(id);
            if (p == null)
            {
                return null;
            }

            else
                
                {
                var result = _autoMapper.Map<ProductViewModel>(p);
                return result;

            }
                
                
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            return _productsRepo.GetProducts().ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);
        }
        
        /*public IQueryable<ProductViewModel> GetProducts(string keyword)
        {
            return _productsRepo.GetProducts().Where(p => p.Description.Contains(keyword)
                                                     || p.Name.Contains(keyword))
                    .ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);

        }*/

        public IQueryable<ProductViewModel> GetProducts(Guid category)
        {
            return _productsRepo.GetProducts().Where(p => p.CategoryId == category)
                    .ProjectTo<ProductViewModel>(_autoMapper.ConfigurationProvider);

        }
    }
}
