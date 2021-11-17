using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Inv {
  public class InventoryStatus : BaseColumn {
    public int InventoryStatus_ID {get; set;}
    public string InventoryStatusDisplay {get; set;}
  }
}