using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.src.DTOs
{
    public class UpdateProductRequestDto
    {
        public string Code { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Debe tener entre 3 y 100 caracteres el nombre")]
        public string Name { get; set; } = string.Empty;

        [RegularExpression(@"1|2|3")]
        public int CategoryId { get; set; }

        [Range(1,99)]
        public int Stock { get; set; }
    }
}