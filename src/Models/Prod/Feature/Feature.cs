using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class Feature : BaseColumn {
    public int Feature_ID {get; set;}
    public string FeatureDisplay {get; set;}
  }
}