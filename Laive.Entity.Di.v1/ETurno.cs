using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Turno (DI_Turno)
   /// </summary>
   public class ETurno : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdTurno { get; set; }
      public string CodigoTurno { get; set; }
      public string GlosaTurno { get; set; }
      public Boolean Activo { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdTurno"));
         columnSet.Add(new Column("CodigoTurno", "codigoTurno"));
         columnSet.Add(new Column("GlosaTurno", "glosaTurno"));
         columnSet.Add(new Column("Activo"));
         return columnSet;
      }


   }
}
