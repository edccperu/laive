using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Bi
{
   /// <summary>
   /// Entidad para la Tabla: BI_SolidoLeche (BI_SolidoLeche)
   /// </summary>
   public class ESolidoLeche : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int CodigoSolidoLeche { get; set; }
      public string CodigoArticulo { get; set; }
      public string GlosaArticulo { get; set; }
      public int CodigoArea { get; set; }
      public string GlosaArea { get; set; }
      public DateTime FechaIngreso { get; set; }
      public Nullable<DateTime> FechaCaduca { get; set; }
      public decimal Slng { get; set; }
      public decimal Slg { get; set; }
      public decimal Ssd { get; set; }
      public decimal Slt { get; set; }
      public decimal SltDiluido { get; set; }
      public decimal FactorRendimiento { get; set; }
      public string Estado { get; set; }
      public string IdUserCreacion { get; set; }
      public DateTime FechaCreacion { get; set; }
      public string IdUserModifica { get; set; }
      public Nullable<DateTime> FechaModifica { get; set; }
      public string IsCaducate { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoSolidoLeche", "a.codigoSolidoLeche"));
         columnSet.Add(new Column("CodigoArticulo", "a.codigoArticulo"));
         columnSet.Add(new Column("GlosaArticulo", "a.glosaArticulo"));
         columnSet.Add(new Column("CodigoArea", "a.codigoArea"));
         columnSet.Add(new Column("GlosaArea", "b.GlosaArea"));
         columnSet.Add(new Column("FechaIngreso", "a.fechaIngreso",false,"dd/MM/yyyy"));
         columnSet.Add(new Column("FechaCaduca", "a.fechaCaduca", false, "dd/MM/yyyy"));
         columnSet.Add(new Column("Slng", "", false, "N4"));
         columnSet.Add(new Column("Slg", "", false, "N4"));
         columnSet.Add(new Column("Ssd", "", false, "N4"));
         columnSet.Add(new Column("Slt", "", false, "N4"));
         columnSet.Add(new Column("SltDiluido", "", false, "N4"));
         columnSet.Add(new Column("FactorRendimiento", "", false, "N8"));
         columnSet.Add(new Column("Estado", "a.estado"));
         return columnSet;
      }

   }
}
