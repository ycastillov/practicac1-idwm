using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.src.DTOs
{
    public class CreateProductDto
    {
        public required string Code { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public required string Name { get; set; }

        [RegularExpression(@"1|2|3")]
        public required int CategoryId { get; set; }

        [Range(1,99)] 
        public required int Stock { get; set; }

    }
}