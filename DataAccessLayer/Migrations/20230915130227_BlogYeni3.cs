using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlogYeni3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GonderiBaslik",
                table: "Gonderiler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GonderiIcerik",
                table: "Gonderiler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GonderiResim",
                table: "Gonderiler",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GonderiBaslik",
                table: "Gonderiler");

            migrationBuilder.DropColumn(
                name: "GonderiIcerik",
                table: "Gonderiler");

            migrationBuilder.DropColumn(
                name: "GonderiResim",
                table: "Gonderiler");
        }
    }
}
