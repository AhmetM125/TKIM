using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.PERSON_ID).IsRequired();
        builder.Property(x => x.TOTAL_PRICE).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_TAX).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_DISCOUNT).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
        builder.Property(x => x.TOTAL_PAYMENT).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);

        builder.HasMany(x=>x.BasketItems).WithOne(x => x.Basket).HasForeignKey(x => x.BASKET_ID);


        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20).IsRequired(false);
        builder.Property(x => x.InsertDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
    }

}
