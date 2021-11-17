using System;
using Microsoft.EntityFrameworkCore;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Inv {
  public class InventoryConfiguration {
    public static void Configure(ModelBuilder mb){
      mb.Entity<Inventory>(opt => {
        opt.ToTable("Inventory", "Inv");
        opt.HasKey(x => x.Inventory_ID);
        opt.Property(x => x.Inventory_ID)
          .ValueGeneratedOnAdd();
        opt.Property(x => x.Direction)
          .HasMaxLength(1);

        BaseColumnConfiguration.Configure(opt);

        #region Relationships
        opt.HasOne(x => x.Warehouse)
          .WithMany()
          .HasForeignKey(x => x.Warehouse_ID);
        #endregion

        #region Constraints
        opt.HasCheckConstraint("CHK_Inventory_Direction", "[Direction] IN ( 'E', 'S' )");
        #endregion
      });
    }
  }
}