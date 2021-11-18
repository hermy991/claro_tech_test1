using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClaroTechTest1.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Prod");

            migrationBuilder.EnsureSchema(
                name: "Inv");

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "Prod",
                columns: table => new
                {
                    Feature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Feature_ID);
                    table.CheckConstraint("CHK_FeatureDisplay", "[FeatureDisplay] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "InventoryStatus",
                schema: "Inv",
                columns: table => new
                {
                    InventoryStatus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryStatusDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatus", x => x.InventoryStatus_ID);
                    table.CheckConstraint("CHK_InventoryStatusDisplay", "[InventoryStatusDisplay] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Merchandise",
                schema: "Prod",
                columns: table => new
                {
                    Merchandise_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchandiseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MerchandiseDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandise", x => x.Merchandise_ID);
                    table.CheckConstraint("CHK_MerchandiseCode", "[MerchandiseCode] <> ''");
                    table.CheckConstraint("CHK_MerchandiseDisplay", "[MerchandiseDisplay] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "Inv",
                columns: table => new
                {
                    Warehouse_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Warehouse_ID);
                    table.CheckConstraint("CHK_WarehouseDisplay", "[WarehouseDisplay] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "FeatureDetail",
                schema: "Prod",
                columns: table => new
                {
                    FeatureDetail_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature_ID = table.Column<int>(type: "int", nullable: false),
                    FeatureDetailDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureDetail", x => x.FeatureDetail_ID);
                    table.CheckConstraint("CHK_FeatureDetailDisplay", "[FeatureDetailDisplay] <> ''");
                    table.ForeignKey(
                        name: "FK_FeatureDetail_Feature_Feature_ID",
                        column: x => x.Feature_ID,
                        principalSchema: "Prod",
                        principalTable: "Feature",
                        principalColumn: "Feature_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchandiseFeature",
                schema: "Prod",
                columns: table => new
                {
                    MerchandiseFeature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merchandise_ID = table.Column<int>(type: "int", nullable: false),
                    Feature_ID = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandiseFeature", x => x.MerchandiseFeature_ID);
                    table.ForeignKey(
                        name: "FK_MerchandiseFeature_Feature_Feature_ID",
                        column: x => x.Feature_ID,
                        principalSchema: "Prod",
                        principalTable: "Feature",
                        principalColumn: "Feature_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MerchandiseFeature_Merchandise_Merchandise_ID",
                        column: x => x.Merchandise_ID,
                        principalSchema: "Prod",
                        principalTable: "Merchandise",
                        principalColumn: "Merchandise_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Prod",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merchandise_ID = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_ID);
                    table.CheckConstraint("CHK_ProductCode", "[ProductCode] <> ''");
                    table.CheckConstraint("CHK_Product_Tax", "[Tax] >= 0");
                    table.CheckConstraint("CHK_Product_TotalPrice", "[TotalPrice] > 0");
                    table.ForeignKey(
                        name: "FK_Product_Merchandise_Merchandise_ID",
                        column: x => x.Merchandise_ID,
                        principalSchema: "Prod",
                        principalTable: "Merchandise",
                        principalColumn: "Merchandise_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "Inv",
                columns: table => new
                {
                    Inventory_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Warehouse_ID = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    InventorySequence = table.Column<int>(type: "int", nullable: false),
                    Document_ID = table.Column<int>(type: "int", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliverDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InventoryStatus_ID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Inventory_ID);
                    table.CheckConstraint("CHK_Inventory_Direction", "[Direction] IN ( 'E', 'S' )");
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryStatus_InventoryStatus_ID",
                        column: x => x.InventoryStatus_ID,
                        principalSchema: "Inv",
                        principalTable: "InventoryStatus",
                        principalColumn: "InventoryStatus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalSchema: "Prod",
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouse_Warehouse_ID",
                        column: x => x.Warehouse_ID,
                        principalSchema: "Inv",
                        principalTable: "Warehouse",
                        principalColumn: "Warehouse_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                schema: "Prod",
                columns: table => new
                {
                    ProductFeature_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Merchandise_ID = table.Column<int>(type: "int", nullable: false),
                    Feature_ID = table.Column<int>(type: "int", nullable: false),
                    FeatureDetail_ID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, defaultValue: ""),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GETDATE())"),
                    ModifiedBy_ID = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.ProductFeature_ID);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Feature_Feature_ID",
                        column: x => x.Feature_ID,
                        principalSchema: "Prod",
                        principalTable: "Feature",
                        principalColumn: "Feature_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFeature_FeatureDetail_FeatureDetail_ID",
                        column: x => x.FeatureDetail_ID,
                        principalSchema: "Prod",
                        principalTable: "FeatureDetail",
                        principalColumn: "FeatureDetail_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Merchandise_Merchandise_ID",
                        column: x => x.Merchandise_ID,
                        principalSchema: "Prod",
                        principalTable: "Merchandise",
                        principalColumn: "Merchandise_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalSchema: "Prod",
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Inv",
                table: "InventoryStatus",
                columns: new[] { "InventoryStatus_ID", "CreatedBy_ID", "InventoryStatusDisplay", "ModifiedBy_ID", "ModifiedDate" },
                values: new object[] { 1, 1, "Pendiente", null, new DateTime(2021, 11, 17, 22, 36, 34, 476, DateTimeKind.Local).AddTicks(1224) });

            migrationBuilder.InsertData(
                schema: "Inv",
                table: "InventoryStatus",
                columns: new[] { "InventoryStatus_ID", "CreatedBy_ID", "InventoryStatusDisplay", "ModifiedBy_ID", "ModifiedDate" },
                values: new object[] { 2, 1, "Procesado", null, new DateTime(2021, 11, 17, 22, 36, 34, 510, DateTimeKind.Local).AddTicks(5399) });

            migrationBuilder.InsertData(
                schema: "Inv",
                table: "InventoryStatus",
                columns: new[] { "InventoryStatus_ID", "CreatedBy_ID", "InventoryStatusDisplay", "ModifiedBy_ID", "ModifiedDate" },
                values: new object[] { 3, 1, "Cancelado", null, new DateTime(2021, 11, 17, 22, 36, 34, 510, DateTimeKind.Local).AddTicks(6342) });

            migrationBuilder.CreateIndex(
                name: "UQ_FeatureDisplay",
                schema: "Prod",
                table: "Feature",
                column: "FeatureDisplay",
                unique: true,
                filter: "[FeatureDisplay] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_FeatureDetail",
                schema: "Prod",
                table: "FeatureDetail",
                columns: new[] { "Feature_ID", "FeatureDetailDisplay" },
                unique: true,
                filter: "[FeatureDetailDisplay] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryStatus_ID",
                schema: "Inv",
                table: "Inventory",
                column: "InventoryStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_ID",
                schema: "Inv",
                table: "Inventory",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_InventorySequence",
                schema: "Inv",
                table: "Inventory",
                columns: new[] { "Warehouse_ID", "InventorySequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryStatus",
                schema: "Inv",
                table: "InventoryStatus",
                column: "InventoryStatusDisplay",
                unique: true,
                filter: "[InventoryStatusDisplay] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_MerchandiseCode",
                schema: "Prod",
                table: "Merchandise",
                column: "MerchandiseCode",
                unique: true,
                filter: "[MerchandiseCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_MerchandiseDisplay",
                schema: "Prod",
                table: "Merchandise",
                column: "MerchandiseDisplay",
                unique: true,
                filter: "[MerchandiseDisplay] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MerchandiseFeature_Feature_ID",
                schema: "Prod",
                table: "MerchandiseFeature",
                column: "Feature_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_MerchandiseFeature",
                schema: "Prod",
                table: "MerchandiseFeature",
                columns: new[] { "Merchandise_ID", "Feature_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Product",
                schema: "Prod",
                table: "Product",
                columns: new[] { "Merchandise_ID", "ProductCode" },
                unique: true,
                filter: "[ProductCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_Feature_ID",
                schema: "Prod",
                table: "ProductFeature",
                column: "Feature_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_FeatureDetail_ID",
                schema: "Prod",
                table: "ProductFeature",
                column: "FeatureDetail_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_Product_ID",
                schema: "Prod",
                table: "ProductFeature",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_ProductFeature",
                schema: "Prod",
                table: "ProductFeature",
                columns: new[] { "Merchandise_ID", "Feature_ID", "FeatureDetail_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Warehouse",
                schema: "Inv",
                table: "Warehouse",
                column: "WarehouseDisplay",
                unique: true,
                filter: "[WarehouseDisplay] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "Inv");

            migrationBuilder.DropTable(
                name: "MerchandiseFeature",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "ProductFeature",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "InventoryStatus",
                schema: "Inv");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "Inv");

            migrationBuilder.DropTable(
                name: "FeatureDetail",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "Prod");

            migrationBuilder.DropTable(
                name: "Merchandise",
                schema: "Prod");
        }
    }
}
