using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.src.DTOs;
using practica1.src.Models;

namespace practica1.src.Mappers
{
    public static class ProductMapper
    {
        public static CreateProductDto ToProductDto(this Product product)
        {
            return new CreateProductDto
            {
                Code = product.Code,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Stock = product.Stock
            };
        }
        public static Product ToProductFromProductDto(this CreateProductDto createProductDto)
        {
            return new Product 
            {
                Code = createProductDto.Code,
                Name = createProductDto.Name,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId
            };         
        } 
    }
}