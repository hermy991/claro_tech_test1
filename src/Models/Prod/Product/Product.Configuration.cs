using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class ProductConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Product>(opt => {
        opt.ToTable("Product", "Prod");
        opt.HasKey(x => x.Product_ID);
        opt.Property(x => x.Product_ID)
          .ValueGeneratedOnAdd();

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Merchandise)
          .WithMany()
          .HasForeignKey(x => x.Merchandise_ID);
        #endregion

        #region Constraints
        opt.HasIndex(x => new { x.Merchandise_ID, x.ProductCode })
          .HasDatabaseName("UQ_Product")
          .IsUnique();

        opt.HasCheckConstraint("CHK_ProductCode", "[ProductCode] <> ''");

        opt.HasCheckConstraint("CHK_Product_Tax", "[Tax] >= 0");

        opt.HasCheckConstraint("CHK_Product_TotalPrice", "[TotalPrice] > 0");
        #endregion
      });
    }
  }
}