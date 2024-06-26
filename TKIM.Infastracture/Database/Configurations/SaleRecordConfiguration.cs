using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

internal class SaleRecordConfiguration : IEntityTypeConfiguration<SaleRecord>
{
    public void Configure(EntityTypeBuilder<SaleRecord> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x=>x.QUANTITY_AFTER).HasColumnType("smallint");
        builder.Property(x => x.QUANTITY_CURRENT).HasColumnType("smallint");
        builder.Property(x => x.QUANTITY_SOLD).HasColumnType("smallint");

        builder.Property(x => x.PURCHASE_PRICE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.SALE_PRICE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.SALE_PRICE_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.PROFIT).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PROFIT_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.TAX).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TAX_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.TOTAL).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TOTAL_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.PRODUCT_ID).IsRequired(true);
        builder.HasOne(x => x.Product).WithMany(x => x.SaleRecords).HasForeignKey(x => x.PRODUCT_ID);


    }
}
