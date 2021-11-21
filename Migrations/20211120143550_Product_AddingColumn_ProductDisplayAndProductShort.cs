using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaroTechTest1.Migrations
{
    public partial class Product_AddingColumn_ProductDisplayAndProductShort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductDisplay",
                schema: "Prod",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductShort",
                schema: "Prod",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDisplay",
                schema: "Prod",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductShort",
                schema: "Prod",
                table: "Product");
        }
    }
}
