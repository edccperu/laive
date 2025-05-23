using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Plantilla (DI_Plantilla)
   /// </summary>
   public class EPlantilla : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int CodigoPlantilla { get; set; }
      public string GlosaPlantilla { get; set; }
      public int NumeroCamiones { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoPlantilla"));
         columnSet.Add(new Column("GlosaPlantilla"));
         columnSet.Add(new Column("NumeroCamiones"));
         return columnSet;
      }

   }
}
