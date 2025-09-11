using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class InventoryMovement
{
    public long Id { get; set; }

    public int ProductVariantId { get; set; }

    public int MovementTypeId { get; set; }

    public int Quantity { get; set; }

    public string? ReferenceType { get; set; }

    public long? ReferenceId { get; set; }

    public string? Reason { get; set; }

    public string? Notes { get; set; }

    public long UserId { get; set; }

    public DateTime MovementDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual MovementType MovementType { get; set; } = null!;

    public virtual ProductVariant ProductVariant { get; set; } = null!;
}
