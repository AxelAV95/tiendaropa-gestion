using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class Sale
{
    public long Id { get; set; }

    public int? CustomerId { get; set; }

    public long ManagerUserId { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public int PaymentMethodId { get; set; }

    public string? PaymentReference { get; set; }

    public int StatusId { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual SaleStatus Status { get; set; } = null!;
}
