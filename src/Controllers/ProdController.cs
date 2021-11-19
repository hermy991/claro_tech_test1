using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using ClaroTechTest1.Models;
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

    //api/v1/prod/entities/Product
    [Route("process/saveFeature")]
    public IActionResult saveFeature([FromBody] dynamic json){
      var feature = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
      Return r = new Return();
      using (var transaction = this._db.Database.BeginTransaction()){
        
        var cfr = this._ps.CreateFeature(feature);
        if(cfr?.Error?.Message != null){
          transaction.Rollback();
          return Ok(cfr);
        }
        transaction.Commit();
        return Ok(r.SetSuccess("Caracteristica registrada.").SetData(cfr));
      }
    }
  }
}