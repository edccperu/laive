using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Box (DI_Box)
   /// </summary>
   public class EBox : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdBox { get; set; }
      public string CodigoBox { get; set; }
      public string TipoCarga { get; set; }
      public string GlosaBox { get; set; }
      public Boolean Activo { get; set; }
      public string CodigoAlmacen { get; set; }
      public string Siempredisponible { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdBox"));
         columnSet.Add(new Column("CodigoBox", "codigoBox"));
         columnSet.Add(new Column("GlosaBox", "glosaBox"));
         columnSet.Add(new Column("Activo"));
         columnSet.Add(new Column("Siempredisponible"));
         columnSet.Add(new Column("CodigoAlmacen"));
         return columnSet;
      }

   }
}
