using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaroTechTest1.Migrations
{
    public partial class Adding_FeatureCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureCode",
                schema: "Prod",
                table: "Feature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "UQ_FeatureCode",
                schema: "Prod",
                table: "Feature",
                column: "FeatureCode",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_FeatureCode",
                schema: "Prod",
                table: "Feature",
                sql: "[FeatureCode] > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_FeatureCode",
                schema: "Prod",
                table: "Feature");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_FeatureCode",
                schema: "Prod",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "FeatureCode",
                schema: "Prod",
                table: "Feature");
        }
    }
}
