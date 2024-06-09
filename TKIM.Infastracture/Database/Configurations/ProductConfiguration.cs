using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DESCRIPTION).HasMaxLength(200).HasColumnType("nvarchar");
        builder.Property(x => x.PRICE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.STOCK).HasColumnType("int");
        builder.Property(x => x.IMAGE);

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20);

        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CATEGORY_ID);
    }
}
