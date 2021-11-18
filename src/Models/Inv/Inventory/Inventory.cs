using System;

using ClaroTechTest1.Models.Base;
using ClaroTechTest1.Models.Prod;

namespace ClaroTechTest1.Models.Inv {
  public class Inventory : BaseColumn {
    public int Inventory_ID { get; set; }
    public int Warehouse_ID { get; set; }
    public string Direction { get; set; }
    public int InventorySequence { get; set; }
    public int? Document_ID { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? DeliverDate { get; set; }
    public int Product_ID { get; set; }
    public decimal Quantity { get; set; }
    public decimal TaxPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
    public int InventoryStatus_ID { get; set; }

    #region Navigations
    public Warehouse Warehouse { get; set; }
    public Product Product { get; set; }
    public InventoryStatus InventoryStatus { get; set; }
    #endregion
  }
}