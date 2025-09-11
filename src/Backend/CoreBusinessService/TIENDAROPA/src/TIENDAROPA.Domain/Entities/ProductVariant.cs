using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class ProductVariant
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? SizeId { get; set; }

    public int? ColorId { get; set; }

    public string Sku { get; set; } = null!;

    public int StockQuantity { get; set; }

    public decimal PriceModifier { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Color? Color { get; set; }

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual Size? Size { get; set; }
}
