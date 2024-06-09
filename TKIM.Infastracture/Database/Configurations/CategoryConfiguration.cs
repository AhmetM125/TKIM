using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100);
        builder.Property(x => x.DESCRIPTION).HasMaxLength(200).HasColumnType("nvarchar");
        builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.ID);

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20);
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar").HasMaxLength(20);

    }
}
