using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaroTechTest1.Models.Base {
  public class BaseColumnConfiguration {
    public static void Configure(dynamic opt){
      DateTime now = DateTime.Now;
      ((PropertyBuilder)opt.Property("Active"))
        .HasDefaultValue(true);
      ((PropertyBuilder)opt.Property("Description"))
        .HasDefaultValue("")
        .HasMaxLength(1000);
      ((PropertyBuilder)opt.Property("Version"))
        .HasDefaultValue(0)
        .ValueGeneratedOnAddOrUpdate();
      ((PropertyBuilder)opt.Property("CreatedDate"))
        .HasDefaultValueSql("(GETDATE())");
        // .HasValueGenerator(typeof(DateTimeValueGenerator))
        // .ValueGeneratedOnAdd();
      ((PropertyBuilder)opt.Property("ModifiedDate"))
        .HasValueGenerator(typeof(DateTimeValueGenerator))
        .ValueGeneratedOnUpdate();
    }
    
  }
}