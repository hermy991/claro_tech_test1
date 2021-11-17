using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiceFeature : BaseColumn {
    public int MerchandiceFeature_ID {get; set;}
    public int Merchandice_ID { get; set; }
    public int Feature_ID { get; set; }
    public bool Required {get; set; }

    #region Navigations
    public Merchandice Merchandice { get; set; }
    public Feature Feature { get; set; }
    #endregion
  }
}