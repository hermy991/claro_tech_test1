using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Inv {
  public class WarehouseConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Warehouse>(opt => {
        opt.ToTable("Warehouse", "Inv");
        opt.HasKey(x => x.Warehouse_ID);
        opt.Property(x => x.Warehouse_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.WarehouseDisplay)
          .HasMaxLength(100);

        BaseColumnConfiguration.Configure(opt);

        #region Constraints
        opt.HasIndex(x => new {x.WarehouseDisplay })
          .HasDatabaseName("UQ_Warehouse")
          .IsUnique();
        opt.HasCheckConstraint("CHK_WarehouseDisplay", "[WarehouseDisplay] <> ''");
        #endregion
      });
    }
  }
}