using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class SaleStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
