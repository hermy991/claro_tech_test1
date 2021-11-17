using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class Product : BaseColumn {
    public int Product_ID {get; set;}
    public int Merchandice_ID { get; set; }
    public string ProductCode { get; set; }
    public decimal Tax { get; set; }
    public decimal TotalPrice { get; set; }

    #region Navigations
    public Merchandice Merchandice { get; set; }
    #endregion
  }
}