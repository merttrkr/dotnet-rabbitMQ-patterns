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

            // Configure properties
            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(b => b.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            // Configure the relationship with BasketItems (one-to-many)
            builder.HasMany(b => b.BasketItems)
                .WithOne()
                .HasForeignKey("BasketId")
                .OnDelete(DeleteBehavior.Cascade); // Basket deletion cascades to BasketItems

            // Configure auditing fields (from base class)
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.UpdatedDate).IsRequired(false); // Optional if nullable
            builder.Property(b => b.DeletedDate).IsRequired(false); // Optional if nullable

            // Index for UserId to optimize queries by user
            builder.HasIndex(b => b.UserId).HasDatabaseName("Idx_UserId");
        }
    }
}
