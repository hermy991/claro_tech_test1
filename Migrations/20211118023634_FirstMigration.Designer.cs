﻿// <auto-generated />
using System;
using ClaroTechTest1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClaroTechTest1.Migrations
{
    [DbContext(typeof(XorDbContext))]
    [Migration("20211118023634_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClaroTechTest1.Models.Inv.Inventory", b =>
                {
                    b.Property<int>("Inventory_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<DateTime?>("DeliverDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<string>("Direction")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("Document_ID")
                        .HasColumnType("int");

                    b.Property<int>("InventorySequence")
                        .HasColumnType("int");

                    b.Property<int>("InventoryStatus_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Warehouse_ID")
                        .HasColumnType("int");

                    b.HasKey("Inventory_ID");

                    b.HasIndex("InventoryStatus_ID");

                    b.HasIndex("Product_ID");

                    b.HasIndex("Warehouse_ID", "InventorySequence")
                        .IsUnique()
                        .HasDatabaseName("UQ_InventorySequence");

                    b.ToTable("Inventory", "Inv");

                    b.HasCheckConstraint("CHK_Inventory_Direction", "[Direction] IN ( 'E', 'S' )");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Inv.InventoryStatus", b =>
                {
                    b.Property<int>("InventoryStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<string>("InventoryStatusDisplay")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("InventoryStatus_ID");

                    b.HasIndex("InventoryStatusDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_InventoryStatus")
                        .HasFilter("[InventoryStatusDisplay] IS NOT NULL");

                    b.ToTable("InventoryStatus", "Inv");

                    b.HasCheckConstraint("CHK_InventoryStatusDisplay", "[InventoryStatusDisplay] <> ''");

                    b.HasData(
                        new
                        {
                            InventoryStatus_ID = 1,
                            CreatedBy_ID = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryStatusDisplay = "Pendiente",
                            Version = 0
                        },
                        new
                        {
                            InventoryStatus_ID = 2,
                            CreatedBy_ID = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryStatusDisplay = "Procesado",
                            Version = 0
                        },
                        new
                        {
                            InventoryStatus_ID = 3,
                            CreatedBy_ID = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InventoryStatusDisplay = "Cancelado",
                            Version = 0
                        });
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Inv.Warehouse", b =>
                {
                    b.Property<int>("Warehouse_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("WarehouseDisplay")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Warehouse_ID");

                    b.HasIndex("WarehouseDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_Warehouse")
                        .HasFilter("[WarehouseDisplay] IS NOT NULL");

                    b.ToTable("Warehouse", "Inv");

                    b.HasCheckConstraint("CHK_WarehouseDisplay", "[WarehouseDisplay] <> ''");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.Feature", b =>
                {
                    b.Property<int>("Feature_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<string>("FeatureDisplay")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Feature_ID");

                    b.HasIndex("FeatureDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_FeatureDisplay")
                        .HasFilter("[FeatureDisplay] IS NOT NULL");

                    b.ToTable("Feature", "Prod");

                    b.HasCheckConstraint("CHK_FeatureDisplay", "[FeatureDisplay] <> ''");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.FeatureDetail", b =>
                {
                    b.Property<int>("FeatureDetail_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<string>("FeatureDetailDisplay")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Feature_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("FeatureDetail_ID");

                    b.HasIndex("Feature_ID", "FeatureDetailDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_FeatureDetail")
                        .HasFilter("[FeatureDetailDisplay] IS NOT NULL");

                    b.ToTable("FeatureDetail", "Prod");

                    b.HasCheckConstraint("CHK_FeatureDetailDisplay", "[FeatureDetailDisplay] <> ''");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.Merchandise", b =>
                {
                    b.Property<int>("Merchandise_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<string>("MerchandiseCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MerchandiseDisplay")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Merchandise_ID");

                    b.HasIndex("MerchandiseCode")
                        .IsUnique()
                        .HasDatabaseName("UQ_MerchandiseCode")
                        .HasFilter("[MerchandiseCode] IS NOT NULL");

                    b.HasIndex("MerchandiseDisplay")
                        .IsUnique()
                        .HasDatabaseName("UQ_MerchandiseDisplay")
                        .HasFilter("[MerchandiseDisplay] IS NOT NULL");

                    b.ToTable("Merchandise", "Prod");

                    b.HasCheckConstraint("CHK_MerchandiseCode", "[MerchandiseCode] <> ''");

                    b.HasCheckConstraint("CHK_MerchandiseDisplay", "[MerchandiseDisplay] <> ''");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.MerchandiseFeature", b =>
                {
                    b.Property<int>("MerchandiseFeature_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<int>("Feature_ID")
                        .HasColumnType("int");

                    b.Property<int>("Merchandise_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<bool>("Required")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("MerchandiseFeature_ID");

                    b.HasIndex("Feature_ID");

                    b.HasIndex("Merchandise_ID", "Feature_ID")
                        .IsUnique()
                        .HasDatabaseName("UQ_MerchandiseFeature");

                    b.ToTable("MerchandiseFeature", "Prod");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.Product", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<int>("Merchandise_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Product_ID");

                    b.HasIndex("Merchandise_ID", "ProductCode")
                        .IsUnique()
                        .HasDatabaseName("UQ_Product")
                        .HasFilter("[ProductCode] IS NOT NULL");

                    b.ToTable("Product", "Prod");

                    b.HasCheckConstraint("CHK_ProductCode", "[ProductCode] <> ''");

                    b.HasCheckConstraint("CHK_Product_Tax", "[Tax] >= 0");

                    b.HasCheckConstraint("CHK_Product_TotalPrice", "[TotalPrice] > 0");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.ProductFeature", b =>
                {
                    b.Property<int>("ProductFeature_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CreatedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("(GETDATE())");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasDefaultValue("");

                    b.Property<int>("FeatureDetail_ID")
                        .HasColumnType("int");

                    b.Property<int>("Feature_ID")
                        .HasColumnType("int");

                    b.Property<int>("Merchandise_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("ProductFeature_ID");

                    b.HasIndex("FeatureDetail_ID");

                    b.HasIndex("Feature_ID");

                    b.HasIndex("Product_ID");

                    b.HasIndex("Merchandise_ID", "Feature_ID", "FeatureDetail_ID")
                        .IsUnique()
                        .HasDatabaseName("UQ_ProductFeature");

                    b.ToTable("ProductFeature", "Prod");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Inv.Inventory", b =>
                {
                    b.HasOne("ClaroTechTest1.Models.Inv.InventoryStatus", "InventoryStatus")
                        .WithMany()
                        .HasForeignKey("InventoryStatus_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Prod.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Inv.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("Warehouse_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InventoryStatus");

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.FeatureDetail", b =>
                {
                    b.HasOne("ClaroTechTest1.Models.Prod.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("Feature_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.MerchandiseFeature", b =>
                {
                    b.HasOne("ClaroTechTest1.Models.Prod.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("Feature_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Prod.Merchandise", "Merchandise")
                        .WithMany()
                        .HasForeignKey("Merchandise_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Merchandise");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.Product", b =>
                {
                    b.HasOne("ClaroTechTest1.Models.Prod.Merchandise", "Merchandise")
                        .WithMany()
                        .HasForeignKey("Merchandise_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Merchandise");
                });

            modelBuilder.Entity("ClaroTechTest1.Models.Prod.ProductFeature", b =>
                {
                    b.HasOne("ClaroTechTest1.Models.Prod.FeatureDetail", "FeatureDetail")
                        .WithMany()
                        .HasForeignKey("FeatureDetail_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Prod.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("Feature_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Prod.Merchandise", "Merchandise")
                        .WithMany()
                        .HasForeignKey("Merchandise_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClaroTechTest1.Models.Prod.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("FeatureDetail");

                    b.Navigation("Merchandise");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}