using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Domain.Entities;

namespace Skinet.Domain.MapConfiguration;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(256);
        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(180);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.HasOne(b => b.ProductBrand)
               .WithMany()
               .HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(t => t.ProductType)
               .WithMany()
               .HasForeignKey(p => p.ProductTypeId);
    }
}