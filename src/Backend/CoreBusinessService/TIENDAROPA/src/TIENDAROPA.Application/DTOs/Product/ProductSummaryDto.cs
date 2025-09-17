using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.DTOs.Product
{
  public class ProductSummaryDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal BasePrice { get; set; }
        public string? ImageUrl { get; set; }
        public string Status { get; set; } = null!;
    }
}
