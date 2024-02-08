using Clean.Arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Arch.Data.EntitiesConfiguration;

public class IndividualEntityDbContext : IEntityTypeConfiguration<IndividualEntity>
{
    public void Configure(EntityTypeBuilder<IndividualEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Gender).HasPrecision(2, 0).IsRequired();
    }
}
