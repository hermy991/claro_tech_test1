using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Inv {
  public class InventoryStatusConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<InventoryStatus>(opt => {
        opt.ToTable("InventoryStatus", "Inv");
        opt.HasKey(x => x.InventoryStatus_ID);
        opt.Property(x => x.InventoryStatus_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.InventoryStatusDisplay)
          .HasMaxLength(100);

        BaseColumnConfiguration.Configure(opt);

        #region Constraints
        opt.HasIndex(x => new {x.InventoryStatusDisplay })
          .HasDatabaseName("UQ_InventoryStatus")
          .IsUnique();
          
        opt.HasCheckConstraint("CHK_InventoryStatusDisplay", "[InventoryStatusDisplay] <> ''");
        #endregion
        
        #region Data
        opt.HasData(
          new InventoryStatus { InventoryStatus_ID = 1, InventoryStatusDisplay = "Pendiente", CreatedBy_ID = 1 },
          new InventoryStatus { InventoryStatus_ID = 2, InventoryStatusDisplay = "Procesado", CreatedBy_ID = 1 },
          new InventoryStatus { InventoryStatus_ID = 3, InventoryStatusDisplay = "Cancelado", CreatedBy_ID = 1 }
        );
        #endregion
      });
    }
  }
}