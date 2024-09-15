using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketService.Infrastructure.Persistence.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            // Primary key
            builder.HasKey(b => b.Id);

            // Configure ProductId and index it for performance
            builder.Property(bi => bi.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();

            builder.HasIndex(bi => bi.ProductId)
                .HasDatabaseName("IX_BasketItem_ProductId");

            // ProductName, Price, and Quantity
            builder.Property(bi => bi.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(bi => bi.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(bi => bi.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            // Auditing fields
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.UpdatedDate).IsRequired(false);
            builder.Property(b => b.DeletedDate).IsRequired(false);
        }
    }

}
