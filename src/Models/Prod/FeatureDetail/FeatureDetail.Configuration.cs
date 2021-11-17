using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class FeatureDetailConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<FeatureDetail>(opt => {
        opt.ToTable("FeatureDetail", "Prod");
        opt.HasKey(x => x.FeatureDetail_ID);
        opt.Property(x => x.FeatureDetail_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.FeatureDetailDisplay)
          .HasMaxLength(100);

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Feature)
          .WithMany()
          .HasForeignKey(x => x.Feature_ID);
        #endregion

        #region Constraints
        opt.HasIndex(x => new { x.Feature_ID, x.FeatureDetailDisplay })
          .HasDatabaseName("UQ_FeatureDetail")
          .IsUnique();
        opt.HasCheckConstraint("CHK_FeatureDetailDisplay", "[FeatureDetailDisplay] <> ''");
        #endregion
      });
    }
  }
}