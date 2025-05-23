using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Almacen (DI_Almacen)
   /// </summary>
   public class EAlmacen : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoAlmacen { get; set; }
      public string CodigoAlmacenSerie { get; set; }
      public string GlosaAlmacen { get; set; }
      public string PrimeraOrden { get; set; }
      public string UltimaOrden { get; set; }
      public string IdOrdenDesde { get; set; }
      public string IdOrdenHasta { get; set; }
      public DateTime FechaPrograma { get; set; }
      public string Locacion { get; set; }
      public string Entidad { get; set; }
      public Boolean Activo { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoAlmacen", "codigoAlmacen"));
         columnSet.Add(new Column("GlosaAlmacen", "glosaAlmacen"));
         columnSet.Add(new Column("PrimeraOrden", "primeraOrden"));
         columnSet.Add(new Column("UltimaOrden", "ultimaOrden"));
         columnSet.Add(new Column("Activo", "razonSocial"));
         return columnSet;
      }

      public List<Column> ColumnSetBandeja()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoAlmacen", "codigoAlmacen"));
         columnSet.Add(new Column("GlosaAlmacen", "glosaAlmacen"));
         columnSet.Add(new Column("Locacion", "locacion"));
         columnSet.Add(new Column("Entidad", "entidad"));
         columnSet.Add(new Column("Activo", "activo"));
         return columnSet;
      }
   }
}
