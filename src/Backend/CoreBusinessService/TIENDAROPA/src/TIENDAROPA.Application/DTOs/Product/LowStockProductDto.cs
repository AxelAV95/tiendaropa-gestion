namespace TIENDAROPA.Application.DTOs.Product
{
    public class LowStockProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public int StockQuantity { get; set; } // El stock actual
        public int MinStockThreshold { get; set; } // El umbral que se usó para considerarlo bajo stock
    }
}