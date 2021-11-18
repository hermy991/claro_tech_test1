using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiseConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Merchandise>(opt => {
        opt.ToTable("Merchandise", "Prod");
        opt.HasKey(x => x.Merchandise_ID);
        opt.Property(x => x.Merchandise_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.MerchandiseCode)
          .HasMaxLength(20);
        opt.Property(x => x.MerchandiseDisplay)
          .HasMaxLength(100);
        
        BaseColumnConfiguration.Configure(opt);

        #region Constrantints
        opt.HasIndex(x => new { x.MerchandiseCode })
          .HasDatabaseName("UQ_MerchandiseCode")
          .IsUnique();

        opt.HasIndex(x => new { x.MerchandiseDisplay })
          .HasDatabaseName("UQ_MerchandiseDisplay")
          .IsUnique();

        opt.HasCheckConstraint("CHK_MerchandiseCode", "[MerchandiseCode] <> ''");
        
        opt.HasCheckConstraint("CHK_MerchandiseDisplay", "[MerchandiseDisplay] <> ''");
        #endregion
      });
    }
  }
}