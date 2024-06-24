using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class PaymentItemsConfiguration : IEntityTypeConfiguration<PaymentItems>
{
    public void Configure(EntityTypeBuilder<PaymentItems> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.PAYMENT_ID).IsRequired();

        builder.HasOne(x=>x.SaleRecord)
            .WithOne(x=>x.PaymentItems)
            .HasForeignKey<PaymentItems>(x=>x.SALE_RECORD_ID);


        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

    }
}
