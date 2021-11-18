using System.Linq;
using Microsoft.EntityFrameworkCore;
using ClaroTechTest1.Models.Inv;
using ClaroTechTest1.Models.Prod;

namespace ClaroTechTest1.Models {
   public class XorDbContext : Microsoft.EntityFrameworkCore.DbContext {
     public XorDbContext(DbContextOptions options) : base(options){   }

    #region Inventory Entities
      private DbSet<Inventory> Inventories { get; set; }
      private DbSet<InventoryStatus> InventoryStatus { get; set; }
      private DbSet<Warehouse> Warehouses { get; set; }
    #endregion

    #region Product Entities
      private DbSet<Feature> Features { get; set; }
      private DbSet<FeatureDetail> FeatureDetails { get; set; }
      private DbSet<Merchandise> Merchandises { get; set; }
      private DbSet<MerchandiseFeature> MerchandiseFeatures { get; set; }
      private DbSet<Product> Products { get; set; }
      private DbSet<ProductFeature> ProductFeatures { get; set; }
    #endregion
    
    protected override void OnModelCreating(ModelBuilder mb) {
      #region Inventory Entities
      InventoryConfiguration.Configure(mb);
      InventoryStatusConfiguration.Configure(mb);
      WarehouseConfiguration.Configure(mb);
      #endregion

      #region Product Entities
      FeatureConfiguration.Configure(mb);
      FeatureDetailConfiguration.Configure(mb);
      MerchandiseConfiguration.Configure(mb);
      MerchandiseFeatureConfiguration.Configure(mb);
      ProductConfiguration.Configure(mb);
      ProductFeatureConfiguration.Configure(mb);
      #endregion

    	base.OnModelCreating(mb);

      foreach(var foreignKey in mb.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())){
        foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
      }
    }
   }
}