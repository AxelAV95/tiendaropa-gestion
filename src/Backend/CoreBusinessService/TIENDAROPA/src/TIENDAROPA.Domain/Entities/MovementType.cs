using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class MovementType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
}
