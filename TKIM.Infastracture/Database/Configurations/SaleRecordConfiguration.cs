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



        //        public ushort QUANTITY_CURRENT { get; set; }
        //public ushort QUANTITY_AFTER { get; set; }
        //public ushort QUANTITY_SOLD { get; set; }

        //public decimal PURCHASE_PRICE { get; set; }

        //public decimal SALE_PRICE { get; set; }
        //public decimal SALE_PRICE_EDITED { get; set; }

        //public decimal PROFIT { get; set; }
        //public decimal PROFIT_EDITED { get; set; }

        //public decimal TAX { get; set; }
        //public decimal TAX_EDITED { get; set; }

        //public decimal TOTAL { get; set; }
        //public decimal TOTAL_EDITED { get; set; }
    }
}
