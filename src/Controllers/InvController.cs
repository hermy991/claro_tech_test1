using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ClaroTechTest1.Services;

namespace ClaroTechTest1.Controllers {
  [ApiController]
  [Route("api/v1/[controller]")]
  public class InvController : ControllerBase {
    private string ControllerName = "Inv";
    public InvController(IGeneralService ds){
      this._gs = ds;
    }
    public IGeneralService _gs { get; set; }

    //api/v1/inv/entities/Product
    [Route("entities/{entity}")]
    public IActionResult getEntity(string entity, Dictionary<string, object> filter){
      var r = this._gs.GetEntity(ControllerName, entity, filter);
      return Ok(r);
    }
  }
}