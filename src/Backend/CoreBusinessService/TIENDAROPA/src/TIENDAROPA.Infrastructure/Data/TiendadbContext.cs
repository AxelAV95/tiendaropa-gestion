using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TIENDAROPA.Domain.Entities;

namespace TIENDAROPA.Infrastructure.Data;

public partial class TiendadbContext : DbContext
{
    public TiendadbContext()
    {
    }

    public TiendadbContext(DbContextOptions<TiendadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<InventoryMovement> InventoryMovements { get; set; }

    public virtual DbSet<MovementType> MovementTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleItem> SaleItems { get; set; }

    public virtual DbSet<SaleStatus> SaleStatuses { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AxelAV\\SQLEXPRESS;Database=tiendadb;User Id=axelav;Password=admin1234;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC0750E8DF6F");

            entity.HasIndex(e => e.Name, "UQ__Brands__737584F6D6A6B788").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC070CB7D8A1");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F649567D04").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07895C7D7A");

            entity.HasIndex(e => e.Name, "UQ__Colors__737584F6DC24416F").IsUnique();

            entity.Property(e => e.HexCode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0729AA7225");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EC54E7FF7").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105345FE6C119").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.TotalPurchases)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.PreferredSize).WithMany(p => p.Customers)
                .HasForeignKey(d => d.PreferredSizeId)
                .HasConstraintName("FK_Customers_Sizes");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07500720D7");

            entity.HasIndex(e => e.MovementDate, "IX_InventoryMovements_MovementDate");

            entity.HasIndex(e => e.ProductVariantId, "IX_InventoryMovements_ProductVariantId");

            entity.HasIndex(e => new { e.ReferenceType, e.ReferenceId }, "IX_InventoryMovements_Reference");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MovementDate).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.ReferenceType).HasMaxLength(50);

            entity.HasOne(d => d.MovementType).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.MovementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryMovements_MovementTypes");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryMovements_ProductVariants");
        });

        modelBuilder.Entity<MovementType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movement__3214EC07667F7DA1");

            entity.HasIndex(e => e.Name, "UQ__Movement__737584F604775BB9").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentM__3214EC07B1BDFFAA");

            entity.HasIndex(e => e.Name, "UQ__PaymentM__737584F6107573E6").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07D4520503");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.Name, "IX_Products_Name");

            entity.HasIndex(e => e.Code, "UQ__Products__A25C5AA7F74DB47E").IsUnique();

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.MinStock).HasDefaultValue(5);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__BrandI__5812160E");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__571DF1D5");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductV__3214EC07BE754D9B");

            entity.HasIndex(e => e.ProductId, "IX_ProductVariants_ProductId");

            entity.HasIndex(e => e.Sku, "UQ__ProductV__CA1ECF0D49A0EB54").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PriceModifier)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .HasColumnName("SKU");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_ProductVariants_Colors");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductVariants_Products");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_ProductVariants_Sizes");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC0722E4D627");

            entity.HasIndex(e => e.CustomerId, "IX_Sales_CustomerId");

            entity.HasIndex(e => e.ManagerUserId, "IX_Sales_ManagerUserId");

            entity.HasIndex(e => e.SaleDate, "IX_Sales_SaleDate");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PaymentReference).HasMaxLength(100);
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.SubtotalAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TaxAmount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TotalAmount)
                .HasComputedColumnSql("(([SubtotalAmount]-[DiscountAmount])+[TaxAmount])", false)
                .HasColumnType("decimal(14, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Sales_Customers");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_PaymentMethods");

            entity.HasOne(d => d.Status).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_SaleStatuses");
        });

        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SaleItem__3214EC07B2CF9D3C");

            entity.HasIndex(e => e.ProductVariantId, "IX_SaleItems_ProductVariantId");

            entity.HasIndex(e => e.SaleId, "IX_SaleItems_SaleId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("(CONVERT([decimal](10,2),([Quantity]*[UnitPrice])*((1)-[DiscountPercent]/(100.0))))", false)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ProductVariant).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.ProductVariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleItems_ProductVariants");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleItems_Sales");
        });

        modelBuilder.Entity<SaleStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SaleStat__3214EC071AE7945E");

            entity.HasIndex(e => e.Name, "UQ__SaleStat__737584F6782AB5CB").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3214EC0748C623D3");

            entity.HasIndex(e => e.Name, "UQ__Sizes__737584F61384ED4B").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
