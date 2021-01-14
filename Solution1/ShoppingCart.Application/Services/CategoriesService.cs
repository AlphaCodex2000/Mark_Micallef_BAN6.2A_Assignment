using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CategoriesService : iCategoryService
    {
        private iCategoryRepository _categoriesRepo;
    
        private IMapper _autoMapper;
        public CategoriesService(iCategoryRepository categoriesRepo, IMapper autoMapper)
        {
            _categoriesRepo = categoriesRepo;
            _autoMapper = autoMapper;
        }
        
        public IQueryable<CategoryViewModel> GetCategories()
        {
            var list = from c in _categoriesRepo.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name
                       };

            return list;
        }

    }
}
