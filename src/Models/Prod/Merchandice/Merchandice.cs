using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class Merchandise : BaseColumn {
    public int Merchandise_ID {get; set;}
    public string MerchandiseCode {get; set;}
    public string MerchandiseDisplay {get; set;}
  }
}