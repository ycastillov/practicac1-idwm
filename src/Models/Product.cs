using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.src.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe ser mayor a 3 y menor a 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Range(1,99)]
        public int Stock { get; set; }

        // Relacion con Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}