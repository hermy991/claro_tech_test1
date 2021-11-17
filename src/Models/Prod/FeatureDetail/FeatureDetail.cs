using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class FeatureDetail : BaseColumn {
    public int FeatureDetail_ID {get; set;}
    public int Feature_ID { get; set; }
    public string FeatureDetailDisplay {get; set;}

    #region Navigations
    public Feature Feature { get; set; }
    #endregion
  }
}