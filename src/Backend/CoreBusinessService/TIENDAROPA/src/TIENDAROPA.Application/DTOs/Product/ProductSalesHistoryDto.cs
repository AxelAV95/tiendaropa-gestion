using System.Collections.Generic;

namespace TIENDAROPA.Application.DTOs.Product
{
    public class ProductSalesHistoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public List<SaleRecordDto> Sales { get; set; } = new List<SaleRecordDto>();
    }
}