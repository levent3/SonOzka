using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UlkeAdi",
                table: "Sehirler");

            migrationBuilder.AlterColumn<string>(
                name: "SehirAdi",
                table: "Sehirler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UlkeId",
                table: "Sehirler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ulkeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAdi = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulkeler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_SehirAdi",
                table: "Sehirler",
                column: "SehirAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_UlkeId",
                table: "Sehirler",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulkeler_UlkeAdi",
                table: "Ulkeler",
                column: "UlkeAdi",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sehirler_Ulkeler_UlkeId",
                table: "Sehirler",
                column: "UlkeId",
                principalTable: "Ulkeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sehirler_Ulkeler_UlkeId",
                table: "Sehirler");

            migrationBuilder.DropTable(
                name: "Ulkeler");

            migrationBuilder.DropIndex(
                name: "IX_Sehirler_SehirAdi",
                table: "Sehirler");

            migrationBuilder.DropIndex(
                name: "IX_Sehirler_UlkeId",
                table: "Sehirler");

            migrationBuilder.DropColumn(
                name: "UlkeId",
                table: "Sehirler");

            migrationBuilder.AlterColumn<string>(
                name: "SehirAdi",
                table: "Sehirler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "UlkeAdi",
                table: "Sehirler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
