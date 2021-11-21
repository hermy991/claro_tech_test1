using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ClaroTechTest1.Models;
using ClaroTechTest1.Models.Prod;
using ClaroTechTest1.Services;
using ClaroTechTest1.Internal;

namespace ClaroTechTest1.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ProdController : ControllerBase {
    private string ControllerName = "Prod";
    public ProdController(XorDbContext db, IGeneralService gs, IProdService ps){
      this._db = db;
      this._gs = gs;
      this._ps = ps;
    }
    public XorDbContext _db { get; set; }
    public IGeneralService _gs { get; set; }
    public IProdService _ps { get; set; }

    //api/v1/prod/entities/Product
    [Route("entities/{entity}")]
    public IActionResult getEntity(string entity, Dictionary<string, object> filter){
      var r = this._gs.GetEntity(ControllerName, entity, filter);
      return Ok(r);
    }

    //api/v1/prod/functions/getProducts
    [Route("functions/getProducts")]
    public IActionResult getProducts([FromBody] dynamic json){
      var filter = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      var r = this._ps.GetProducts(this._db, filter);
      return Ok(r);
    }

    //api/v1/prod/functions/getFeatureDetails
    [Route("functions/getFeatureDetails")]
    public IActionResult getFeatureDetails([FromBody] dynamic json){
      var filter = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      filter["Feature_ID"] = ((JArray)filter["Feature_ID"]).ToObject<int[]>();
      var r = this._gs.GetEntity(ControllerName, "FeatureDetail", filter);
      return Ok(r);
    }

    //api/v1/prod/functions/getProductFeatures
    [Route("functions/getProductFeatures")]
    public IActionResult getProductFeatures([FromBody] dynamic json){
      var filter = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      var r = this._ps.GetProductFeatures(this._db, filter);
      return Ok(r);
    }

    //api/v1/prod/process/saveFeature
    [Route("process/saveFeature")]
    public IActionResult saveFeature([FromBody] dynamic json){
      var feature = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      feature["FeatureDetails"] = ((JArray)feature["FeatureDetails"])
          .Select(jv => 
              new FeatureDetail { 
                FeatureDetail_ID = jv.Value<int>("FeatureDetail_ID"), 
                FeatureDetailDisplay = jv.Value<string>("FeatureDetailDisplay"), 
                Active = true }).ToArray();
      Return r = new Return();
      using (var transaction = this._db.Database.BeginTransaction()){
        
        var cfr = this._ps.CreateFeature(this._db, feature);
        if(cfr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(cfr);
        }
        feature["Feature_ID"] = cfr.Data.Feature_ID;
        var dr = this._ps.SetFeatureDetails(this._db, feature["Feature_ID"], feature["FeatureDetails"]);
        if(dr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(dr);
        }
        transaction.Commit();
        return Ok(r.SetSuccess("Característica registrada.").SetData(cfr));
      }
    }

    //api/v1/prod/process/saveMerchandise
    [Route("process/saveMerchandise")]
    public IActionResult saveMerchandise([FromBody] dynamic json){
      var merchandise = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      merchandise["FeatureSelections"] = ((JArray)merchandise["FeatureSelections"]).ToObject<int[]>();
      Return r = new Return();
      using (var transaction = this._db.Database.BeginTransaction()){
        
        var cfr = this._ps.CreateMerchandise(this._db, merchandise);
        if(cfr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(cfr);
        }
        merchandise["Merchandise_ID"] = cfr.Data.Merchandise_ID;
        var sbr = this._ps.SetFeatures(this._db, merchandise["Merchandise_ID"], merchandise["FeatureSelections"]);
        if(sbr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(sbr);
        }
        transaction.Commit();
        return Ok(r.SetSuccess("Característica registrada.").SetData(cfr));
      }
    }

    //api/v1/prod/process/saveProduct
    [Route("process/saveProduct")]
    public IActionResult saveProduct([FromBody] dynamic json){
      var product = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      product["ProductFeatures"] = ((JArray)product["ProductFeatures"])
          .Select(jv => 
              new ProductFeature { 
                Merchandise_ID = jv.Value<int>("Merchandise_ID"), 
                Feature_ID = jv.Value<int>("Feature_ID"), 
                FeatureDetail_ID = jv.Value<int>("FeatureDetail_ID"), 
                Active = true }).ToArray();
      Return r = new Return();
      using (var transaction = this._db.Database.BeginTransaction()){
        
        var cfr = this._ps.CreateProduct(this._db, product);
        if(cfr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(cfr);
        }
        product["Product_ID"] = cfr.Data.Product_ID;
        var sbr = this._ps.SetProductFeatures(this._db, product["Product_ID"], product["ProductFeatures"]);
        if(sbr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(sbr);
        }
        transaction.Commit();
        return Ok(r.SetSuccess("Producto registrada.").SetData(cfr));
      }
    }


  }
}