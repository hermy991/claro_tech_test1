using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiceConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Merchandice>(opt => {
        opt.ToTable("Merchandice", "Prod");
        opt.HasKey(x => x.Merchandice_ID);
        opt.Property(x => x.Merchandice_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.MerchandiceCode)
          .HasMaxLength(20);
        opt.Property(x => x.MerchandiceDisplay)
          .HasMaxLength(100);
        
        BaseColumnConfiguration.Configure(opt);

        #region Constrantints
        opt.HasIndex(x => new { x.MerchandiceCode })
          .HasDatabaseName("UQ_MerchandiceCode")
          .IsUnique();

        opt.HasIndex(x => new { x.MerchandiceDisplay })
          .HasDatabaseName("UQ_MerchandiceDisplay")
          .IsUnique();

        opt.HasCheckConstraint("CHK_MerchandiceCode", "[MerchandiceCode] <> ''");
        
        opt.HasCheckConstraint("CHK_MerchandiceDisplay", "[MerchandiceDisplay] <> ''");
        #endregion
      });
    }
  }
}