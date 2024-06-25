using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.TOTAL_PRICE).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_TAX).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_DISCOUNT).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_PAYMENT).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);

        builder.HasMany(x => x.BasketItems).WithOne(x => x.Payment).HasForeignKey(x => x.PAYMENT_ID);

        builder.Property(x => x.COMPANY_ID).IsRequired(false);
        builder.Property(x=>x.CUSTOMER_ID).IsRequired(false);
        builder.HasOne(x=>x.Customer).WithMany(x=>x.Payments).HasForeignKey(x => x.CUSTOMER_ID);
        builder.HasOne(x => x.Company).WithMany(x => x.Payments).HasForeignKey(x => x.COMPANY_ID);



        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
    }

}
