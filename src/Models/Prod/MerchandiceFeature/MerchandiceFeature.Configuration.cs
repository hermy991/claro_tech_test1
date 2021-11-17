using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiceFeatureConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<MerchandiceFeature>(opt => {
        opt.ToTable("MerchandiceFeature", "Prod");
        opt.HasKey(x => x.MerchandiceFeature_ID);
        opt.Property(x => x.MerchandiceFeature_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.Required)
          .HasDefaultValue(false);

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Merchandice)
          .WithMany()
          .HasForeignKey(x => x.Merchandice_ID);
          
        opt.HasOne(x => x.Feature)
          .WithMany()
          .HasForeignKey(x => x.Feature_ID);
        #endregion

        #region Constraints
        opt.HasIndex(x => new { x.Merchandice_ID, x.Feature_ID })
          .HasDatabaseName("UQ_MerchandiceFeature")
          .IsUnique();
        #endregion
      });
    }
  }
}