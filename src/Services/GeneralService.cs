using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ClaroTechTest1.Models;
using ClaroTechTest1.Internal;

namespace ClaroTechTest1.Services {
  public interface IGeneralService {
    Return GetEntity(string schema, string table, Dictionary<string, object> filter = null);
  }

  public class GeneralService : IGeneralService {
    public GeneralService(XorDbContext db){
      this._db = db;
    }
    private XorDbContext _db;
    public Return GetEntity(string schema, string table, Dictionary<string, object> filter = null){
      var sql = new Sql(_db);
      var file = "DynamicEntity";
      var query = File.ReadAllText($"src/Queries/{file}/{file}.sql");
      string entity = $"{schema}.{table}";
      query = query.Replace(":Entity", Regex.Replace(entity, @"[^\w.]", ""));
      query += sql.MakeWhere(filter);
      var entityData = sql.OneQuery(query);

      return new Return($"Entidad '{entity}' data").SetData(entityData);
    }
  }
}