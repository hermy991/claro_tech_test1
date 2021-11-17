using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class ProductFeatureConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<ProductFeature>(opt => {
        opt.ToTable("ProductFeature", "Prod");
        opt.HasKey(x => x.ProductFeature_ID);
        opt.Property(x => x.ProductFeature_ID)
          .ValueGeneratedOnAdd();

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Product)
          .WithMany()
          .HasForeignKey(x => x.Product_ID);
          
        opt.HasOne(x => x.Feature)
          .WithMany()
          .HasForeignKey(x => x.Feature_ID);
          
        opt.HasOne(x => x.FeatureDetail)
          .WithMany()
          .HasForeignKey(x => x.FeatureDetail_ID);
        #endregion

        #region Constraints
        opt.HasIndex(x => new { x.Merchandice_ID, x.Feature_ID })
          .HasDatabaseName("UQ_ProductFeature")
          .IsUnique();
        #endregion
      });
    }
  }
}