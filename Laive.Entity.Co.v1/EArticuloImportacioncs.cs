using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Co
{
   /// <summary>
   /// Entidad para la Tabla: CO_ArticuloImportacion (CO_ArticuloImportacion)
   /// </summary>
   public class EArticuloImportacion : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string Periodo { get; set; }
      public string Mes { get; set; }
      public string CodigoArticulo { get; set; }
      public string IdEstadoKardexAuto { get; set; }
      public string IdEstadoKardexDCA { get; set; }
      public string StEstado { get; set; }
      public string DsEstado { get; set; }
      public int TipoArticulo { get; set; }

      public string DsEstadoKardexAuto { get; set; }
      public string DsEstadoKardexDCA { get; set; }
      
      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("Periodo"));
         columnSet.Add(new Column("Mes"));
         columnSet.Add(new Column("CodigoArticulo"));
         columnSet.Add(new Column("IdEstadoKardexAuto"));
         columnSet.Add(new Column("DsEstadoKardexAuto"));
         columnSet.Add(new Column("IdEstadoKardexDCA"));
         columnSet.Add(new Column("DsEstadoKardexDCA"));
         columnSet.Add(new Column("StEstado"));
         columnSet.Add(new Column("DsEstado"));
         columnSet.Add(new Column("TipoArticulo"));
         return columnSet;
      }
   }
}
