using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TKIM.Entity.Entity;

namespace TKIM.Infastracture.Database.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.NAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.SURNAME).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(x => x.EMAIL).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.ROLE).HasColumnType("nvarchar").HasMaxLength(5).IsRequired(false);

        builder.HasOne(x => x.Security).WithOne(x => x.Person).HasForeignKey<Person>(x => x.ID);

        builder.Property(x => x.InsertUser).HasColumnType("nvarchar").HasMaxLength(20);
        builder.Property(x => x.UpdateDate).HasColumnType("nvarchar").HasMaxLength(20);

    }
}
