using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_Unidad (DI_Unidad)
   /// </summary>
   public class EUnidad : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdTransportista { get; set; }
      public string DsTransportista { get; set; }
      public int IdUnidad { get; set; }
      public int IdOperador { get; set; }
      public int IdChofer { get; set; }
      public string Placa { get; set; }   
      public string ClaveChofer { get; set; }
      public string NombreChofer { get; set; }
      public decimal CargaUtil { get; set; }
      public decimal Capacidad { get; set; }
      public decimal CostoFrios { get; set; }
      public decimal CostoSecos { get; set; }
      public string Comunicacion { get; set; }
      public string HoraCarga { get; set; }
      public decimal Paleta { get; set; }
      public string MarcaUnidad { get; set; }
      public string ModeloUnidad { get; set; }
      public Boolean Activo { get; set; }
      public string TipoCarga { get; set; }
      public string GlosaCarga { get; set; }
      public DateTime FechaDespacho { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdTransportista"));
         columnSet.Add(new Column("IdUnidad"));
         columnSet.Add(new Column("Placa", "a.placa"));
         columnSet.Add(new Column("DsTransportista", "b.razonSocial"));
         columnSet.Add(new Column("IdChofer"));
         columnSet.Add(new Column("NombreChofer", "c.nombreChofer"));
         columnSet.Add(new Column("CargaUtil", "", false, "N0"));
         columnSet.Add(new Column("Capacidad", "", false, "N0"));
         columnSet.Add(new Column("CostoFrios", "", false, "N2"));
         columnSet.Add(new Column("CostoSecos", "", false, "N2"));
         columnSet.Add(new Column("Comunicacion"));
         columnSet.Add(new Column("HoraCarga"));
         columnSet.Add(new Column("Paleta", "", false, "N0"));
         columnSet.Add(new Column("MarcaUnidad", "a.marcaUnidad"));
         columnSet.Add(new Column("ModeloUnidad", "a.modeloUnidad"));
         columnSet.Add(new Column("TipoCarga"));
         columnSet.Add(new Column("GlosaCarga", "d.glosaCarga"));
         columnSet.Add(new Column("Activo"));
         return columnSet;
      }

      public List<Column> ColumnSetUnidadDisponible()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdTransportista"));
         columnSet.Add(new Column("IdUnidad"));
         columnSet.Add(new Column("Placa"));
         columnSet.Add(new Column("TipoCarga"));
         columnSet.Add(new Column("DsTransportista"));
         columnSet.Add(new Column("NombreChofer"));
         columnSet.Add(new Column("CargaUtil", "", false, "N0"));
         columnSet.Add(new Column("CostoFrios", "", false, "N2"));
         columnSet.Add(new Column("CostoSecos", "", false, "N2"));
         return columnSet;
      }
   }
}
