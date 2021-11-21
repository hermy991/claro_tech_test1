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
    Return GetProducts(XorDbContext _db, Dictionary<string, object> Filter);
    Return GetProductFeatures(XorDbContext _db, Dictionary<string, object> Filter);
    Return CreateFeature(XorDbContext _db, Dictionary<string, object> Feature);
    Return CreateMerchandise(XorDbContext _db, Dictionary<string, object> Merchandise);
    Return SetFeatureDetails(XorDbContext _db, int Feature_ID, FeatureDetail[] FeatureDetails);
    Return SetFeatures(XorDbContext _db, int Merchandise_ID, int[] FeatureSelections);
    Return CreateProduct(XorDbContext _db, Dictionary<string, object> Product);
    Return SetProductFeatures(XorDbContext _db, int Product_ID, ProductFeature[] ProductFeatures);
  }

  public class ProdService : IProdService {
    public ProdService(XorDbContext db){
      this.__db = db;
    }
    private XorDbContext __db;
    public Return GetProducts(XorDbContext _db, Dictionary<string, object> Filter){
      _db = _db ?? __db;
      var message = $"Decoded";
      var products = (from p in _db.Products
                      join m in _db.Merchandises on p.Merchandise_ID equals m.Merchandise_ID
                      select new {
                          p.Product_ID,
                          p.Merchandise_ID,
                          m.MerchandiseCode,
                          p.ProductCode,
                          p.ProductDisplay,
                          p.ProductShort,
                          p.Tax,
                          p.TotalPrice,
                          p.Active
                        }
                     ).ToArray();
      return new Return(message).SetData(products);
    }
    public Return GetProductFeatures(XorDbContext _db, Dictionary<string, object> Filter){
      _db = _db ?? __db;
      // Filter["Product_ID"] = Filter["Product_ID"] == null ? (int?)(long?)Filter["Product_ID"]: Filter["Product_ID"];
      var message = $"Decoded";
      var products = (from f in _db.Features
                      join mf in _db.MerchandiseFeatures on new { f.Feature_ID,  Active = (bool?)true } 
                                                     equals new { mf.Feature_ID, mf.Active }
                      /*LEFT JOIN */
                      join pf in _db.ProductFeatures on new { f.Feature_ID, Product_ID = (int?)(long?)Filter["Product_ID"], Active = (bool?)true } equals new { pf.Feature_ID, Product_ID = (int?)pf.Product_ID, pf.Active }
                        into g_pf from pf in g_pf.DefaultIfEmpty()
                      where f.Active == true &&
                        mf.Merchandise_ID == (int?)(long?)Filter["Merchandise_ID"]
                      // select new { f, mf, pf }
                      select new {
                          f.Feature_ID,
                          FeatureCode = f.FeatureCode,
                          FeatureDisplay = f.FeatureDisplay,
                          Merchandise_ID = mf.Merchandise_ID,
                          FeatureDetail_ID = (int?)pf.FeatureDetail_ID
                          }
                     ).ToArray();
      // products.FirstOrDefault().
      return new Return(message).SetData(products);
    }
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

    public Return CreateProduct(XorDbContext _db, Dictionary<string, object> product){
      _db = _db ?? __db;
      var message = "";
      try{
        int? Product_ID = product.ContainsKey("Product_ID") ? Convert.ToInt32(product["Product_ID"]) : null;
        var px = (from f in _db.Products
                    where f.Product_ID == Product_ID
                    select f
                    ).FirstOrDefault();
        if (px != null) {
          if (product.ContainsKey("ProductDisplay")) px.ProductDisplay = (string)product["ProductDisplay"];
          if (product.ContainsKey("ProductShort")) px.ProductShort = (string)product["ProductShort"];
          if (product.ContainsKey("Tax")) px.Tax = decimal.Parse(product["Tax"]+"");
          if (product.ContainsKey("TotalPrice")) px.TotalPrice = decimal.Parse(product["TotalPrice"]+"");
          if (product.ContainsKey("Active")) px.Active = (Boolean)product["Active"];
          px.ModifiedBy_ID = 1;
          message = "Producto actualizado exitosamente";
        }
        else {
          px = new Product {
            Merchandise_ID = (int)(long)product["Merchandise_ID"],
            ProductCode =  Regex.Replace(((string)product["ProductCode"]).ToUpper(), "[^0-1A-Z]", ""),
            ProductDisplay = (string)product["ProductDisplay"],
            ProductShort = (string)product["ProductShort"],
            Tax = decimal.Parse(product["Tax"]+""),
            TotalPrice = decimal.Parse(product["TotalPrice"]+""),
            Active = (Boolean)product["Active"],
            CreatedBy_ID = 1
          };
          _db.Products.Add(px);
          message = "Producto registrada exitosamente";
        }
        _db.SaveChanges();
        return new Return(message).SetData(px);
      } catch (Exception ex) {
        return new Return(new { Message = $"Error registrando producto", ExMessage = ex.Message });
      }
    }
    
    public Return SetProductFeatures(XorDbContext _db, int Product_ID, ProductFeature[] ProductFeatures){
      _db = _db ?? __db;
      try{
        int[] productFeatures = ProductFeatures.Select(x => x.FeatureDetail_ID).ToArray();

        var existingProductFeatures = _db.ProductFeatures.Where(x => x.Product_ID == Product_ID)
                          .Select(x => x.FeatureDetail_ID)
                          .ToArray();
        /**
        * Desactivamos todas las puertas activas */
        _db.ProductFeatures
            .Where(x=> x.Product_ID == Product_ID
                      && x.Active == true
                    )
            .Update(x=> new ProductFeature() { Active = false, ModifiedBy_ID = 1 });
        /**
        * Activamos y actualizamos todas las puertas por el parametro Doors que se encuentran guardatas*/

        for (int i = 0; i < ProductFeatures.Length; i++)
        {
          ProductFeature dt = _db.ProductFeatures.FirstOrDefault(x =>
            x.Product_ID == Product_ID && x.FeatureDetail_ID == ProductFeatures[i].FeatureDetail_ID);
          if (dt != null)
          {
            // dt.FeatureDetail_ID = ProductFeatures[i].FeatureDetail_ID;
            dt.Active = true;
          }
        }
        /**
        * Insertaremos todas las puertas por el parametro Doors que no se encuentren guardatas*/

        ProductFeature[] productFeaturesToInsert = ProductFeatures.Where(x=> !existingProductFeatures.Contains( x.FeatureDetail_ID ) ).ToArray();

        for(int i=0; i<productFeaturesToInsert.Length; i++){
          var temp = new ProductFeature(){
            Product_ID = Product_ID,
            Merchandise_ID = productFeaturesToInsert[i].Merchandise_ID,
            Feature_ID = productFeaturesToInsert[i].Feature_ID,
            FeatureDetail_ID = productFeaturesToInsert[i].FeatureDetail_ID, 
            CreatedBy_ID = 1,
            Active = true,
          };
          _db.ProductFeatures.Add(temp);
        }
        _db.SaveChanges();
        String message = "Valores caracteristica registradas exitosamente";
        return new Return(message).SetData(productFeaturesToInsert);
      }
      catch (Exception ex){
        return new Return( new { Message = $"Error registrando caracteristica valores", ExMessage = ex.Message });
      }
    }
  }
}