namespace TIENDAROPA.Application.DTOs.Product
{
    public class ProductSearchDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}