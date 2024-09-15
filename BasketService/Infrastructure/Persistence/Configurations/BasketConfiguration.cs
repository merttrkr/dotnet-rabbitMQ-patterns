using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketService.Infrastructure.Persistence.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            // Configure the primary key
            builder.HasKey(b => b.Id);

            // Configure UserId
            builder.Property(b => b.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            // Configure the relationship with BasketItems (one-to-many)
            builder.HasMany(b => b.BasketItems)
                .WithOne()  // No navigation property for Basket in BasketItem
                .HasForeignKey("BasketId")  // This adds the foreign key column
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete items if the basket is deleted

            // Index for UserId to optimize queries by user
            builder.HasIndex(b => b.UserId).HasDatabaseName("Idx_UserId");

            // Configure auditing fields
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.UpdatedDate).IsRequired(false);
            builder.Property(b => b.DeletedDate).IsRequired(false);
        }
    }

}
