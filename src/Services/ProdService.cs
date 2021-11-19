using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Z.EntityFramework.Plus;

using ClaroTechTest1.Models;
using ClaroTechTest1.Models.Prod;
using ClaroTechTest1.Internal;

namespace ClaroTechTest1.Services {
  public interface IProdService {
    Return CreateFeature(XorDbContext _db, Dictionary<string, object> Feature);
    Return CreateMerchandise(XorDbContext _db, Dictionary<string, object> Merchandise);
    Return SetFeatureDetails(XorDbContext _db, int Feature_ID, FeatureDetail[] FeatureDetails);
    Return SetFeatures(XorDbContext _db, int Merchandise_ID, int[] FeatureSelections);
  }

  public class ProdService : IProdService {
    public ProdService(XorDbContext db){
      this.__db = db;
    }
    private XorDbContext __db;
    public Return CreateFeature(XorDbContext _db, Dictionary<string, object> feature){
      _db = _db ?? __db;
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
          message = "Característica actualizada exitosamente";
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
          message = "Característica registrada exitosamente";
        }
        _db.SaveChanges();
        return new Return(message).SetData(fx);
      } catch (Exception ex) {
        return new Return(new { Message = $"Error registrando Característica", ExMessage = ex.Message });
      }
    }
    
    public Return CreateMerchandise(XorDbContext _db, Dictionary<string, object> merchandise){
      _db = _db ?? __db;
      var message = "";
      try{
        int? Merchandise_ID = merchandise.ContainsKey("Merchandise_ID") ? Convert.ToInt32(merchandise["Merchandise_ID"]) : null;
        var fx = (from f in _db.Merchandises
                    where f.Merchandise_ID == Merchandise_ID
                    select f
                    ).FirstOrDefault();
        if (fx != null) {
          if (merchandise.ContainsKey("MerchandiseDisplay")) fx.MerchandiseDisplay = (string)merchandise["MerchandiseDisplay"];
          if (merchandise.ContainsKey("Active")) fx.Active = (Boolean)merchandise["Active"];
          fx.ModifiedBy_ID = 1;
          message = "Mercancía actualizada exitosamente";
        }
        else {
          fx = new Merchandise {
            MerchandiseCode =  Regex.Replace(((string)merchandise["MerchandiseCode"]).ToUpper(), "[^0-1A-Z]", ""),
            MerchandiseDisplay = (string)merchandise["MerchandiseDisplay"],
            Active = (Boolean)merchandise["Active"],
            CreatedBy_ID = 1
          };
          _db.Merchandises.Add(fx);
          message = "Mercancía registrada exitosamente";
        }
        _db.SaveChanges();
        return new Return(message).SetData(fx);
      } catch (Exception ex) {
        return new Return(new { Message = $"Error registrando mercancía", ExMessage = ex.Message });
      }
    }
    
    public Return SetFeatureDetails(XorDbContext _db, int Feature_ID, FeatureDetail[] FeatureDetails){
      _db = _db ?? __db;
      try{
        string[] featureDetailDisplays = FeatureDetails.Select(x => x.FeatureDetailDisplay).ToArray();

        var existingFeatureDetails = _db.FeatureDetails.Where(x => x.Feature_ID == Feature_ID)
                          .Select(x => x.FeatureDetailDisplay.ToUpper().Trim())
                          .ToArray();
        /**
        * Desactivamos todas las puertas activas */
        _db.FeatureDetails
            .Where(x=> x.Feature_ID == Feature_ID
                      && x.Active == true
                    )
            .Update(x=> new FeatureDetail() { Active = false, ModifiedBy_ID = 1 });
        /**
        * Activamos y actualizamos todas las puertas por el parametro Doors que se encuentran guardatas*/

        for (int i = 0; i < FeatureDetails.Length; i++)
        {
          FeatureDetail dt = _db.FeatureDetails.FirstOrDefault(x =>
            x.Feature_ID == Feature_ID && x.FeatureDetailDisplay == FeatureDetails[i].FeatureDetailDisplay);
          if (dt != null)
          {
            dt.FeatureDetailDisplay = FeatureDetails[i].FeatureDetailDisplay;
            dt.Active = true;
          }
        }
        /**
        * Insertaremos todas las puertas por el parametro Doors que no se encuentren guardatas*/

        FeatureDetail[] doorsToInsert = FeatureDetails.Where(x=> !existingFeatureDetails.Contains(x.FeatureDetailDisplay.ToUpper().Trim())).ToArray();

        for(int i=0; i<doorsToInsert.Length; i++){
          var temp = new FeatureDetail(){
            Feature_ID = Feature_ID,
            FeatureDetailDisplay = doorsToInsert[i].FeatureDetailDisplay, 
            CreatedBy_ID = 1,
            Active = true,
          };
          _db.FeatureDetails.Add(temp);
        }
          
        _db.SaveChanges();
        String message = "Valores caracteristica registradas exitosamente";
        return new Return(message).SetData(doorsToInsert);
      }
      catch (Exception ex){
        return new Return( new { Message = $"Error registrando caracteristica valores", ExMessage = ex.Message });
      }
    }

    public Return SetFeatures(XorDbContext _db, int Merchandise_ID, int[] FeatureSelections){
      _db = _db ?? __db;
      var message = "";
      try{
        var existingFeatures = _db.MerchandiseFeatures.Where(x => x.Merchandise_ID == Merchandise_ID)
                          .Select(x => x.Feature_ID)
                          .ToArray();

        _db.MerchandiseFeatures.Where(x=> x.Merchandise_ID == Merchandise_ID && x.Active == true)
            .Update(x=>new MerchandiseFeature() { Active = false, ModifiedBy_ID = 1 });

        _db.MerchandiseFeatures.Where(x=> x.Merchandise_ID == Merchandise_ID && x.Active == false && FeatureSelections.Contains(x.Feature_ID))
            .Update(x=>new MerchandiseFeature() { Active = true, ModifiedBy_ID = 1 });

        Feature[] featuresToInsert = _db.Features.Where(x=> FeatureSelections.Contains(x.Feature_ID)
                                                           && !existingFeatures.Contains(x.Feature_ID) 
                                                           && x.Active == true).ToArray();

        for(int i=0; i<featuresToInsert.Length; i++){
          var temp = new MerchandiseFeature(){
            Merchandise_ID = Merchandise_ID,
            Feature_ID = featuresToInsert[i].Feature_ID,
            CreatedBy_ID = 1,
            Active = true,
          };
          _db.MerchandiseFeatures.Add(temp);
        }

        _db.SaveChanges();
        message = "Caracteristicas registrada exitosamente";
        return new Return(message).SetData(featuresToInsert);
      }
      catch (Exception ex){
        return new Return( new { Message = $"Error registrando caracteristicas", ExMessage = ex.Message });
      }
    }
  }
}