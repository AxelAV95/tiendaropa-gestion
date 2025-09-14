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

        /// <summary>
        /// SKU (Stock Keeping Unit) único para esta variante específica.
        /// </summary>
        public string Sku { get; set; } = string.Empty;

        /// <summary>
        /// El nombre de la talla (ej: "S", "M", "L").
        /// Es mucho más útil para el cliente que el 'SizeId'.
        /// </summary>
        public string? SizeName { get; set; }

        /// <summary>
        /// El nombre del color (ej: "Rojo", "Azul Marino").
        /// Es más útil que el 'ColorId'.
        /// </summary>
        public string? ColorName { get; set; }

        /// <summary>
        /// Cantidad de unidades disponibles en inventario para esta variante.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Modificador de precio. El precio final de la variante sería
        /// Producto.BasePrice + esta cantidad.
        /// </summary>
        public decimal PriceModifier { get; set; }

        /// <summary>
        /// Indica si esta variante está disponible para la venta.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
