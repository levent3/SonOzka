using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccesLayer.EntityConfigurations
{
    public class UlkeConfiguration : IEntityTypeConfiguration<Ulke>
    {
        public void Configure(EntityTypeBuilder<Ulke> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UlkeKodu).HasMaxLength(4);
            builder.Property(p => p.UlkeAdi).HasMaxLength(128);
            builder.HasIndex(p => p.UlkeAdi).IsUnique(true);
            builder.HasIndex(p => p.UlkeKodu).IsUnique(true);

            //one-to-many configurations
            builder.HasMany(p => p.Sehirler).WithOne(p => p.Ulke);


        }
    }
}
