using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class SaleItem
{
    public long Id { get; set; }

    public long SaleId { get; set; }

    public int ProductVariantId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountPercent { get; set; }

    public decimal? Subtotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ProductVariant ProductVariant { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
