using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiseFeatureConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<MerchandiseFeature>(opt => {
        opt.ToTable("MerchandiseFeature", "Prod");
        opt.HasKey(x => x.MerchandiseFeature_ID);
        opt.Property(x => x.MerchandiseFeature_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.Required)
          .HasDefaultValue(false);

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Merchandise)
          .WithMany()
          .HasForeignKey(x => x.Merchandise_ID);
          
        opt.HasOne(x => x.Feature)
          .WithMany()
          .HasForeignKey(x => x.Feature_ID);
        #endregion

        #region Constraints
        opt.HasIndex(x => new { x.Merchandise_ID, x.Feature_ID })
          .HasDatabaseName("UQ_MerchandiseFeature")
          .IsUnique();
        #endregion
      });
    }
  }
}