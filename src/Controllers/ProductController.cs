using Microsoft.AspNetCore.Mvc;
using practica1.src.DTOs;
using practica1.src.Interfaces;
using practica1.src.Mappers;

namespace practica1.src.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var exists = await _productRepository.ExistsByCode(createProductDto.Code);
            if (exists)
            {
                return Conflict("El codigo ya esta registrado.");
            } 
            else 
            {
                var productModel = createProductDto.ToProductFromProductDto();
                await _productRepository.Post(productModel);
                return CreatedAtAction(nameof(CreateProduct), new { code = productModel.Code }, productModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? category)
        {
            var validCategories = new List<string> {"poleras", "pantalones", "sombreros"};

            if (!string.IsNullOrEmpty(category) && !validCategories.Contains(category.ToLower()))
            {
                return BadRequest("Filtro de busqueda no valido");
            }

            var products = await _productRepository.GetAll(category);   
            var productDto = products.Select(p => p.ToProductDto());
            return Ok(productDto);
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string code)
        {
            var exists = await _productRepository.ExistsByCode(code);
            if (exists)
            {
                await _productRepository.DeleteProduct(code);
                return Ok("Producto eliminado");
            } 
            else
            {
                return NotFound("Codigo no valido");
            }
        }

        /*
        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]string code, [FromBody]UpdateProductRequestDto updateProductRequestDto)
        {
            
        }
        */
    }
}