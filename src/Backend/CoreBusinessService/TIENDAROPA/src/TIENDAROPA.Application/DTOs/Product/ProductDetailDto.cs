using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.DTOs.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public string Status { get; set; } = null!;
        public string? ImageUrl { get; set; }

        // Datos de relaciones que queremos mostrar
        public string CategoryName { get; set; } = null!;
        public string? BrandName { get; set; }
    }
}
