using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccesLayer.EntityConfigurations
{
    public class SehirConfiguration : IEntityTypeConfiguration<Sehir>
    {
        public void Configure(EntityTypeBuilder<Sehir> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SehirKodu).HasMaxLength(3);
            builder.Property(p => p.SehirAdi).HasMaxLength(50);
            builder.HasIndex(p => p.SehirAdi).IsUnique(true);
            builder.HasIndex(p => p.SehirKodu).IsUnique(true);
        }
    }
}
