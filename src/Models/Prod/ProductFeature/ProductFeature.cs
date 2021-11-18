using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class ProductFeature : BaseColumn {
    public int ProductFeature_ID {get; set;}
    public int Product_ID { get; set; }
    public int Merchandise_ID { get; set; }
    public int Feature_ID { get; set; }
    public int FeatureDetail_ID { get; set; }

    #region Navigations
    public Product Product { get; set; }
    public Merchandise Merchandise { get; set; }
    public Feature Feature { get; set; }
    public FeatureDetail FeatureDetail { get; set; }
    #endregion
  }
}