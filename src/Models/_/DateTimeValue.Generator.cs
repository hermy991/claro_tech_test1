using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClaroTechTest1.Models.Base {
  internal class DateTimeValueGenerator : ValueGenerator<DateTime> {
    public override bool GeneratesTemporaryValues => false;

    public override DateTime Next(EntityEntry entry)
    {
      if (entry is null)
      {
        throw new ArgumentNullException(nameof(entry));
      }

      return DateTime.Now;
    }
  }
}