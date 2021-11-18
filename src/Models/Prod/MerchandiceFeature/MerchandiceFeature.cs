using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class MerchandiseFeature : BaseColumn {
    public int MerchandiseFeature_ID {get; set;}
    public int Merchandise_ID { get; set; }
    public int Feature_ID { get; set; }
    public bool Required {get; set; }

    #region Navigations
    public Merchandise Merchandise { get; set; }
    public Feature Feature { get; set; }
    #endregion
  }
}