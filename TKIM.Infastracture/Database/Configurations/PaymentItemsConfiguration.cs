using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class PaymentItemsConfiguration : IEntityTypeConfiguration<PaymentItems>
{
    public void Configure(EntityTypeBuilder<PaymentItems> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.BASKET_ID).IsRequired();
        builder.Property(x => x.PRODUCT_ID).IsRequired();
        builder.Property(x => x.QUANTITY_AFTER).IsRequired();
        builder.Property(x => x.QUANTITY_CURRENT).IsRequired();
        builder.Property(x => x.QUANTITY_IN_CART).IsRequired();
        builder.Property(x => x.CURRENT_PURCHASE_PRICE).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.CURRENT_SALE_PRICE).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.CURRENT_PROFIT).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.CURRENT_TAX).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.TOTAL_PRICE).HasColumnType("decimal(18,2)").IsRequired();


        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

    }
}
