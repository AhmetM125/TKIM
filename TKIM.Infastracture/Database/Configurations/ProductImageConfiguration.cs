using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.Property(x => x.ID).IsRequired();
        builder.HasKey(x => x.ID);
        builder.Property(x => x.PRODUCT_ID).IsRequired();
        builder.Property(x => x.Image).IsRequired();
        builder.Property(x => x.ImageSize).HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.ImageType).HasMaxLength(20).IsRequired(false);




        builder.Property(x=>x.InsertUser).HasMaxLength(20);
        builder.Property(x => x.UpdateUser).HasMaxLength(20);
        builder.Property(x => x.InsertDate).IsRequired(false);
        builder.Property(x => x.UpdateDate).IsRequired(false);

        builder.HasOne(x => x.Product).WithMany(x => x.ProductImages)
            .HasForeignKey(x => x.PRODUCT_ID).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.PRODUCT_ID);

    }
}
