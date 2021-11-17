using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class FeatureConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Feature>(opt => {
        opt.ToTable("Feature", "Prod");
        opt.HasKey(x => x.Feature_ID);
        opt.Property(x => x.Feature_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.FeatureDisplay)
          .HasMaxLength(100);
        
        BaseColumnConfiguration.Configure(opt);

        opt.HasIndex(x => new { x.FeatureDisplay })
          .HasDatabaseName("UQ_FeatureDisplay")
          .IsUnique();
        opt.HasCheckConstraint("CHK_FeatureDisplay", "[FeatureDisplay] <> ''");
      });
    }
  }
}