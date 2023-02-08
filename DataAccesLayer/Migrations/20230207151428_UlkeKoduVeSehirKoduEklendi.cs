using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class UlkeKoduVeSehirKoduEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UlkeKodu",
                table: "Ulkeler",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SehirKodu",
                table: "Sehirler",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ulkeler_UlkeKodu",
                table: "Ulkeler",
                column: "UlkeKodu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_SehirKodu",
                table: "Sehirler",
                column: "SehirKodu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ulkeler_UlkeKodu",
                table: "Ulkeler");

            migrationBuilder.DropIndex(
                name: "IX_Sehirler_SehirKodu",
                table: "Sehirler");

            migrationBuilder.DropColumn(
                name: "UlkeKodu",
                table: "Ulkeler");

            migrationBuilder.DropColumn(
                name: "SehirKodu",
                table: "Sehirler");
        }
    }
}
