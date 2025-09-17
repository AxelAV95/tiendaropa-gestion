using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.DTOs.Product
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public string Sku { get; set; } = null!;
        public string? SizeName { get; set; } // Nombre de la talla
        public string? ColorName { get; set; } // Nombre del color
        public int StockQuantity { get; set; }
        public decimal FinalPrice { get; set; } // Precio final calculado
        public bool IsActive { get; set; }
    }
}
