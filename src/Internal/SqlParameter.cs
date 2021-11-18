using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ClaroTechTest1.Internal {
  public class Sql {
    DbContext _db {get; set;}
    public Sql(DbContext db){
      _db = db;
    }
    public string QueryFormat(string query, Dictionary<string, string> ps){
      var psx = new Dictionary<string, object>();
      foreach(string key in ps.Keys){
        psx[key] = ps[key];
      }
      return QueryFormat(query, psx);
    }
    public string QueryFormat(string query, params Dictionary<string, object>[] ps){
      var tps = new Dictionary<string, object>();
      for(int i = 0; i<ps.Length; i++){
        tps = tps.Concat(ps[i]).ToDictionary(k => k.Key, v => v.Value);
      }
      return QueryFormat(query, tps);
    }
    public string QueryFormat(string query, Dictionary<string, object> ps){
      var tempQuery = query;
      foreach(var k in ps.Keys){
        string tempv;
        if(ps[k] == null)
          tempv = "(NULL)";
        else if(ps[k] is int)
          tempv = ps[k]+"";
        else if(ps[k] is bool)
          tempv = (bool)ps[k]? "'1'" : "'0'";
        else if (ps[k] is DateTime)
          tempv = "(STR_TO_DATE('"+((DateTime)ps[k]).ToString("yyyy-MM-dd HH:mm:ss")+"','%Y-%m-%d %H:%i:%S'))";
        else if (ps[k] is string && new Regex("[0-9]{4}-[0-1][0-9]-[0-3][0-9] [0-2][0-9]:[0-5][0-9]:[0-5][0-9]").IsMatch(ps[k]+""))
          tempv = "(STR_TO_DATE('"+ ps[k] +"','%Y-%m-%d %H:%i:%S'))";
        /// LENTITUD UTILIZANDO LIKE POR ESTA RAZON SE COMENTO ESTA PARTE
        /// using datetime LIKE '2009-10-20%' => 2931ms
        /// using datetime >= '2009-10-20 00:00:00' AND datetime <= '2009-10-20 23:59:59' => 168ms
        // else if (ps[k] is string && new Regex("[0-9]{4}-[0-1][0-9]-[0-3][0-9]").IsMatch(ps[k]+""))
        //   tempv = "'"+ps[k]+"%'";
        else if (ps[k] is JsonElement && ((JsonElement) ps[k]).ValueKind == JsonValueKind.True)
          tempv = "TRUE";
        else if (ps[k] is JsonElement && ((JsonElement) ps[k]).ValueKind == JsonValueKind.False)
          tempv = "FALSE";
        else
          tempv = $"'{Regex.Replace(ps[k]+"", "'", "''")}'";
        var tempk = Regex.Replace(k, "[@:]", "");
        tempQuery = Regex.Replace(tempQuery, $":{tempk}|@{tempk}", tempv);
      }
      string[] tempQueryArr = tempQuery.Split("'");
      tempQuery = "";
      for (int i = 0; i < tempQueryArr.Length; i++)
      {
        if (i % 2 == 0)
        {
          tempQuery += Regex.Replace(tempQueryArr[i], @"(?<!:):[\w]+|(?<!@)@[\w]+", "NULL");
        }
        else
        {
          tempQuery += "'" + tempQueryArr[i] + "'";
        }
      }
      //tempQuery = Regex.Replace(tempQuery, @"(?<!:):[\w]+|(?<!@)@[\w]+", "NULL");
      return tempQuery;
    }
    public string MakeWhere(Dictionary<string, object> filter, bool useWhere = true){
      if(filter.Count == 0){
        return "";
      }
      var whereClause = new List<string>();
      filter = filter ?? new Dictionary<string, object>();
      var keys = new List<string>(filter.Keys);
      foreach(var key in keys){
        if(filter[key] is string){
          filter[key] = Regex.Replace(filter[key].ToString(), "'", "''");
        }
      }
      if(filter.Count > 0){
        foreach(string key in filter.Keys){
          string temp = ":" + key;
          temp = QueryFormat(temp, new Dictionary<string, object>{{key, filter[key]}});
          whereClause.Add($"{key} = {temp}");
        }
      }
      return ( useWhere ? "\n WHERE " : "\n AND " ) + string.Join(" AND ", whereClause);
    }
    public List<Dictionary<string, object>> OneQuery(string query, Dictionary<string, object> ps = null){
      ps = ps??new Dictionary<string, object>();
      List<SqlParameter> tempps = new List<SqlParameter>();
      foreach(var k in ps.Keys)
        tempps.Add(new SqlParameter(k, ps[k]));
      return OneQuery(query, tempps.ToArray());
    }
    public List<Dictionary<string, object>> OneQuery(string query, params SqlParameter[] ps){
      var table = new List<Dictionary<string, object>>();
      //query = query.Replace(":", "@");
      using (var cmd = _db.Database.GetDbConnection().CreateCommand()){
        cmd.CommandText = query;
        foreach(var p in ps){
          var qp = cmd.CreateParameter();
          qp.ParameterName = "@"+p.Name.Replace("@", "");
          qp.Value = p.Value;
          cmd.Parameters.Add(qp);
        }
        _db.Database.OpenConnection();
        using (var reader = cmd.ExecuteReader())
        {
          while(reader.Read()){
            Dictionary<string, object> row = new Dictionary<string, object>();
            for(var c = 0; c < reader.FieldCount; c++){
              if(reader.IsDBNull(c))
                row.Add(reader.GetName(c), null);
              else 
                row.Add(reader.GetName(c), reader.GetValue(c));
            }
            table.Add(row);
          }
        }
      }
      return table;
    }
    public List<List<Dictionary<string, object>>> MultipleQuery(string query, Dictionary<string, object> ps = null){
      ps = ps??new Dictionary<string, object>();
      List<SqlParameter> tempps = new List<SqlParameter>();
      foreach(var k in ps.Keys)
        tempps.Add(new SqlParameter(k, ps[k]));
      return MultipleQuery(query, tempps.ToArray());
    }
    public List<List<Dictionary<string, object>>> MultipleQuery(string query, params SqlParameter[] ps){
      var tables = new List<List<Dictionary<string, object>>>();
      query = query.Replace(":", "@");
      using (var cmd = _db.Database.GetDbConnection().CreateCommand()){
        cmd.CommandText = query;
        foreach(var p in ps){
          var qp = cmd.CreateParameter();
          qp.ParameterName = p.Name;
          qp.Value = p.Value;
          cmd.Parameters.Add(qp);
        }
        _db.Database.OpenConnection();
        using (var reader = cmd.ExecuteReader()) {
          do{
            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();
            while(reader.Read()){
              Dictionary<string, object> row = new Dictionary<string, object>();
              for(var c = 0; c < reader.FieldCount; c++){
                row.Add(reader.GetName(c), reader.GetValue(c));
              }
              table.Add(row);
            }
            tables.Add(table);
          }while(reader.NextResult());
        }
      }
      return tables;
    }

  }
}