using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practica1.src.Data;
using practica1.src.DTOs;
using practica1.src.Interfaces;
using practica1.src.Models;

namespace practica1.src.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> ExistsByCode(string code)
        {
            return await _dataContext.Products.AnyAsync(p => p.Code == code);
        }
        public async Task<Product> Post(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> GetAll(string? category)
        {
            var query = _dataContext.Products.Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.CategoryName.ToLower() == category.ToLower());                
            } 
            return await query.ToListAsync();
        }

        public async Task<Product?> DeleteProduct(string code)
        {
            var productToDelete = await _dataContext.Products.FirstOrDefaultAsync(p => p.Code == code);
            if (productToDelete != null)
            {
                _dataContext.Products.Remove(productToDelete);
                await _dataContext.SaveChangesAsync();
            }
            return productToDelete;
        }

        public Task<Product?> Put(string code, UpdateProductRequestDto updateProductRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}