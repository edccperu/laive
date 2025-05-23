using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Entity.Sy
{
   /// <summary>
   /// Entidad para la Tabla: SY_ParametroSistema (SY_ParametroSistema)
   /// </summary>
   public class EParametroSistema : IEntityBase
   {
       public EntityState EntityState { get; set; }
       public string EntityFilter { get; set; }
       public int IdParametroSistema { get; set; }
       public string DsNombre { get; set; }
       public string DsModulo { get; set; }
       public string DsDescripcion { get; set; }
       public string TipoValor { get; set; }
       public Nullable<decimal> NuValorNumerico { get; set; }
       public Nullable<DateTime> NuValorFecha { get; set; }
       public string NuValorCadena { get; set; }
       public string Anulado { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdParametroSistema"));
         columnSet.Add(new Column("DsNombre"));
         columnSet.Add(new Column("DsModulo"));
         columnSet.Add(new Column("DsDescripcion"));
         columnSet.Add(new Column("NuValorNumerico"));
         columnSet.Add(new Column("NuValorFecha"));
         columnSet.Add(new Column("NuValorCadena"));
         columnSet.Add(new Column("Anulado"));
         return columnSet;
      }
   }
}
