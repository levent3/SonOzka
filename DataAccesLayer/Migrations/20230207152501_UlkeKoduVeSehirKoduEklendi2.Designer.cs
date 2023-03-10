// <auto-generated />
using DataAccesLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20230207152501_UlkeKoduVeSehirKoduEklendi2")]
    partial class UlkeKoduVeSehirKoduEklendi2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entites.Sehir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SehirAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SehirKodu")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("UlkeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SehirAdi")
                        .IsUnique();

                    b.HasIndex("SehirKodu")
                        .IsUnique();

                    b.HasIndex("UlkeId");

                    b.ToTable("Sehirler");
                });

            modelBuilder.Entity("Entites.Ulke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TelefonKodu")
                        .HasColumnType("int");

                    b.Property<string>("UlkeAdi")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UlkeKodu")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("UlkeAdi")
                        .IsUnique();

                    b.HasIndex("UlkeKodu")
                        .IsUnique();

                    b.ToTable("Ulkeler");
                });

            modelBuilder.Entity("Entites.Sehir", b =>
                {
                    b.HasOne("Entites.Ulke", "Ulke")
                        .WithMany("Sehirler")
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ulke");
                });

            modelBuilder.Entity("Entites.Ulke", b =>
                {
                    b.Navigation("Sehirler");
                });
#pragma warning restore 612, 618
        }
    }
}
