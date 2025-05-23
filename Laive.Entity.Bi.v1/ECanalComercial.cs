using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Bi
{
   /// <summary>
   /// Entidad para la Tabla: BI_CanalComercial (BI_CanalComercial)
   /// </summary>
   public class ECanalComercial : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdCanalModerno { get; set; }
      public int IdCanalModernoPadre { get; set; }
      public string Codigo { get; set; }
      public string Glosa { get; set; }
      public int Padre { get; set; }
      public int Nivel { get; set; }
      public string CodigoNivel1 { get; set; }
      public string GlosaNivel1 { get; set; }
      public string CodigoNivel2 { get; set; }
      public string GlosaNivel2 { get; set; }
      public string CodigoPartner { get; set; }
      public int Id { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdCanalModerno", "a.idCanalModerno"));
         columnSet.Add(new Column("IdCanalModernoPadre", "c.idCanalModerno"));
         columnSet.Add(new Column("CodigoNivel1", "c.codigo"));
         columnSet.Add(new Column("GlosaNivel1", "c.glosa"));
         columnSet.Add(new Column("CodigoNivel2", "b.codigo"));
         columnSet.Add(new Column("GlosaNivel2", "b.glosa"));
         columnSet.Add(new Column("CodigoPartner", "a.codigoPartner"));
         columnSet.Add(new Column("Id", "a.Id"));
         return columnSet;
      }



   }
}
