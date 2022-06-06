using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skinet.Data.Migrations
{
    public partial class UpdateBrandsAndTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductBrands");
        }
    }
}
