using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.src.DTOs;
using practica1.src.Models;

namespace practica1.src.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ExistsByCode(string code);
        Task<Product> Post(Product product);
        Task<List<Product>> GetAll(string? category);
        Task<Product?> DeleteProduct(string code);
        Task<Product?> Put(string code, UpdateProductRequestDto updateProductRequestDto);
    }
}