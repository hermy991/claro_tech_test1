using System;

using ClaroTechTest1.Models.Base;
using ClaroTechTest1.Models.Prod;

namespace ClaroTechTest1.Models.Inv {
  public class Inventory : BaseColumn {
    public int Inventory_ID {get; set;}
    public int Warehouse_ID { get; set; }
    public string Direction {get; set; }
    public int InventorySequence { get; set; }
    public int? Document_ID { get; set; }
    public DateTime ApplicationDate {get; set;}
    public DateTime? DeliverDate {get; set;}
    public int Product_ID { get; set; }
    public int Feature1_ID { get; set; }
    public int Feature2_ID { get; set; }
    public int Feature3_ID { get; set; }
    public int Feature4_ID { get; set; }
    public int Feature5_ID { get; set; }
    public int Feature6_ID { get; set; }
    public int Feature7_ID { get; set; }
    public int Feature8_ID { get; set; }
    public int Feature9_ID { get; set; }
    public int Feature10_ID { get; set; }
    public int Feature11_ID { get; set; }
    public int Feature12_ID { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }

    public int InventoryStatus_ID { get; set; }

    #region Navigations
    public Warehouse Warehouse { get; set; }
    public Merchandice Product { get; set; }
    public Feature Feature1 { get; set; }
    public Feature Feature2 { get; set; }
    public Feature Feature3 { get; set; }
    public Feature Feature4 { get; set; }
    public Feature Feature5 { get; set; }
    public Feature Feature6 { get; set; }
    public Feature Feature7 { get; set; }
    public Feature Feature8 { get; set; }
    public Feature Feature9 { get; set; }
    public Feature Feature10 { get; set; }
    public Feature Feature11 { get; set; }
    public Feature Feature12 { get; set; }
    public InventoryStatus InventoryStatus { get; set; }
    #endregion
  }
}