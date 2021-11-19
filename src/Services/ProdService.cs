using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

using ClaroTechTest1.Models;
using ClaroTechTest1.Models.Prod;
using ClaroTechTest1.Internal;

namespace ClaroTechTest1.Services {
  public interface IProdService {
    Return CreateFeature(Dictionary<string, object> feature);
  }

  public class ProdService : IProdService {
    public ProdService(XorDbContext db){
      this._db = db;
    }
    private XorDbContext _db;
    public Return CreateFeature(Dictionary<string, object> feature){
      var message = "";
      try{
        int? feature_ID = feature.ContainsKey("Feature_ID") ? Convert.ToInt32(feature["Feature_ID"]) : null;
        var fx = (from f in _db.Features
                    where f.Feature_ID == feature_ID
                    select f
                    ).FirstOrDefault();
        if (fx != null) {
          if (feature.ContainsKey("FeatureDisplay")) fx.FeatureDisplay = (string)feature["FeatureDisplay"];
          if (feature.ContainsKey("Active")) fx.Active = (Boolean)feature["Active"];
          fx.ModifiedBy_ID = 1;
          message = "Caracteristica actualizada exitosamente";
        }
        else {
          var lastFeatureCode = _db.Features.Any() ? _db.Features.Max( x => x.FeatureCode) : 0;
          fx = new Feature {
            FeatureCode = lastFeatureCode + 1,
            FeatureDisplay = (string)feature["FeatureDisplay"],
            Active = (Boolean)feature["Active"],
            CreatedBy_ID = 1
          };
          _db.Features.Add(fx);
          message = "Caracteristica registrada exitosamente";
        }
        _db.SaveChanges();
        return new Return(message).SetData(fx);
      } catch (Exception ex) {
        return new Return(new { Message = $"Error registrando caracteristica", ExMessage = ex.Message });
      }
    }
  }
}