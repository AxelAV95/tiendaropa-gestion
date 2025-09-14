

namespace TIENDAROPA.Application.DTOs.Product
{
    public class ProductDtoResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string? ImageUrl { get; set; }

       

        // Es mejor enviar el nombre que el ID para que el cliente no tenga que buscarlo.
        public string CategoryName { get; set; } = string.Empty;
        public string? BrandName { get; set; }
        public string Status { get; set; } = string.Empty; // Estado del producto (Active, Discontinued)
    }
}
