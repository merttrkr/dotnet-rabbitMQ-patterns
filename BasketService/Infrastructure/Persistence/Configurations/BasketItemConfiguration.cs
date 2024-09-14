using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketService.Infrastructure.Persistence.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            // Configure the primary key
            builder.HasKey(b => b.Id);

            // Configure properties
            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsRequired();

            // Configure ProductId and index it for faster lookups
            builder.Property(bi => bi.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();

            builder.HasIndex(bi => bi.ProductId)  // Index ProductId for performance
                .HasDatabaseName("IX_BasketItem_ProductId");

            // Configure ProductName with a length constraint
            builder.Property(bi => bi.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(100)
                .IsRequired();

            // Configure Price with precision
            builder.Property(bi => bi.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Configure Quantity
            builder.Property(bi => bi.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            // Configure auditing fields (from base class)
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.UpdatedDate).IsRequired(false); // Optional
            builder.Property(b => b.DeletedDate).IsRequired(false); // Optional
        }
    }
}
