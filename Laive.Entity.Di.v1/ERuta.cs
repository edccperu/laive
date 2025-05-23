using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Ruta (DI_Ruta)
   /// </summary>
   public class ERuta : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdRuta { get; set; }
      public string GlosaRuta { get; set; }
      public Boolean Activo { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdRuta","idRuta"));
         columnSet.Add(new Column("GlosaRuta","glosaRuta"));
         columnSet.Add(new Column("Activo"));
         return columnSet;
      }
   }
}
