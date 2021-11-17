using System;

namespace ClaroTechTest1.Models.Base {
  public class BaseColumn {
    public bool? Active {get; set;}
    public string Description {get; set;}
    public int Version {get; set;}
    public int CreatedBy_ID {get; set;}
    public DateTime CreatedDate {get; set;}
    public int? ModifiedBy_ID {get; set;}
    public DateTime? ModifiedDate {get; set;}

  }
}