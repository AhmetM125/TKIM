using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

internal class PurchaseRecordConfiguration : IEntityTypeConfiguration<PurchaseRecord>
{
    public void Configure(EntityTypeBuilder<PurchaseRecord> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x=>x.QUANTITY_CURRENT).HasColumnType("smallint");
        builder.Property(x => x.QUANTITY_AFTER).HasColumnType("smallint");
        builder.Property(x => x.QUANTITY_PURCHASED).HasColumnType("smallint");

        builder.Property(x => x.PURCHASE_PRICE_BEFORE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PURCHASE_PRICE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PURCHASE_PRICE_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.TAX_BEFORE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TAX).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TAX_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.TOTAL).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TOTAL_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.PROFIT).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PROFIT_EDITED).HasColumnType("decimal(18,2)");

        builder.Property(x => x.SALE_PRICE).HasColumnType("decimal(18,2)");
        builder.Property(x => x.SALE_PRICE_EDITED).HasColumnType("decimal(18,2)");

    }
}
