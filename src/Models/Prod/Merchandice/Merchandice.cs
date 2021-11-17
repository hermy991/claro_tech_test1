using System;

using ClaroTechTest1.Models.Base;

namespace ClaroTechTest1.Models.Prod {
  public class Merchandice : BaseColumn {
    public int Merchandice_ID {get; set;}
    public string MerchandiceCode {get; set;}
    public string MerchandiceDisplay {get; set;}
  }
}