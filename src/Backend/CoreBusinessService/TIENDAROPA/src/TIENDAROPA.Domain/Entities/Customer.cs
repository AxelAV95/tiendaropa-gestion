using System;
using System.Collections.Generic;

namespace TIENDAROPA.Domain.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int LoyaltyPoints { get; set; }

    public decimal TotalPurchases { get; set; }

    public int? PreferredSizeId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Size? PreferredSize { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
