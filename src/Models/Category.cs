using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.src.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Product> Products = new List<Product>();
    }
}