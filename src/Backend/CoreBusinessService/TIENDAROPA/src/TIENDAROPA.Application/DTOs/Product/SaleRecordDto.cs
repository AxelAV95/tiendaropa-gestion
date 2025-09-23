using System;

namespace TIENDAROPA.Application.DTOs.Product
{
    public class SaleRecordDto
    {
        public long SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string Sku { get; set; } = null!;
        public int QuantitySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}