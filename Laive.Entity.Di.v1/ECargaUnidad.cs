using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_CargaUnidad (DI_CargaUnidad)
   /// </summary>
   public class ECargaUnidad : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }

      public int IdCargaUnidad { get; set; }
      public int NewIdCargaUnidad { get; set; }
      public DateTime FechaPrograma { get; set; }
      public string Estado { get; set; }
      public int IdTransportista { get; set; }
      public string DsTransportista { get; set; }
      public int IdUnidad { get; set; }
      public int IdTurno_Seco { get; set; }
      public int IdTurno_Frio { get; set; }
      public string SiempreDisponible_Frio { get; set; }
      public int IdRuta { get; set; }
      public int IdBox_Seco { get; set; }
      public int IdBox_Frio { get; set; }
      public string SiempreDisponible_Seco { get; set; }
      public decimal KilosAsignados { get; set; }
      public decimal PorUnidad { get; set; }
      public decimal FleteVenta { get; set; }
      public decimal FletePromedio { get; set; }
      public decimal KilosFrio { get; set; }
      public decimal KilosSeco { get; set; }
      public string Placa { get; set; }
      public string TipoCarga { get; set; }
      public string NombreChofer { get; set; }
      public decimal CargaUtil { get; set; }
      public string DsTurno_Seco { get; set; }
      public string DsTurno_Frio { get; set; }
      public string DsBox_Seco { get; set; }
      public string DsBox_Frio { get; set; }
      public string IdUserTkCarga { get; set; }
      public DateTime FechaInicio { get; set; }
      public DateTime FechaCierre { get; set; }
      public DateTime FechaXml { get; set; }
      public DateTime FechaExpide { get; set; }
      public DateTime FechaFactura { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdRuta"));
         columnSet.Add(new Column("IdCargaUnidad"));
         columnSet.Add(new Column("IdTransportista"));
         columnSet.Add(new Column("IdUnidad"));
         columnSet.Add(new Column("Placa"));
         columnSet.Add(new Column("TipoCarga"));
         columnSet.Add(new Column("DsTransportista"));
         columnSet.Add(new Column("NombreChofer"));
         columnSet.Add(new Column("CargaUtil", "", false, "N0"));
         columnSet.Add(new Column("KilosAsignados", "", false, "N2"));
         columnSet.Add(new Column("PorUnidad", "", false, "N1"));
         columnSet.Add(new Column("IdTurno_Frio"));
         columnSet.Add(new Column("IdTurno_Seco"));
         columnSet.Add(new Column("IdBox_Frio"));
         columnSet.Add(new Column("IdBox_Seco"));
         columnSet.Add(new Column("FleteVenta", "", false, "N1"));
         columnSet.Add(new Column("FletePromedio", "", false, "N2"));
         columnSet.Add(new Column("KilosFrio", "", false, "N2"));
         columnSet.Add(new Column("KilosSeco", "", false, "N2"));
         columnSet.Add(new Column("DsTurno_Frio"));
         columnSet.Add(new Column("DsBox_Frio"));
         columnSet.Add(new Column("DsTurno_Seco"));
         columnSet.Add(new Column("DsBox_Seco"));
         columnSet.Add(new Column("Estado"));
         columnSet.Add(new Column("FechaInicio"));
         columnSet.Add(new Column("FechaCierre"));
         columnSet.Add(new Column("SiempreDisponible_Frio"));
         columnSet.Add(new Column("SiempreDisponible_Seco"));

         return columnSet;
      }

      public List<Column> ColumnSetCerrado()
      {
          List<Column> columnSet = new List<Column>();
          columnSet.Add(new Column("IdRuta"));
          columnSet.Add(new Column("IdCargaUnidad"));
          columnSet.Add(new Column("IdTransportista"));
          columnSet.Add(new Column("IdUnidad"));
          columnSet.Add(new Column("Placa"));
          columnSet.Add(new Column("TipoCarga"));
          columnSet.Add(new Column("DsTransportista"));
          columnSet.Add(new Column("NombreChofer"));
          columnSet.Add(new Column("CargaUtil", "", false, "N0"));
          columnSet.Add(new Column("KilosAsignados", "", false, "N2"));
          columnSet.Add(new Column("PorUnidad", "", false, "N1"));
          columnSet.Add(new Column("IdTurno_Frio"));
          columnSet.Add(new Column("IdTurno_Seco"));
          columnSet.Add(new Column("IdBox_Frio"));
          columnSet.Add(new Column("IdBox_Seco"));
          columnSet.Add(new Column("FleteVenta", "", false, "N1"));
          columnSet.Add(new Column("FletePromedio", "", false, "N2"));
          columnSet.Add(new Column("KilosFrio", "", false, "N2"));
          columnSet.Add(new Column("KilosSeco", "", false, "N2"));
          columnSet.Add(new Column("Estado"));
          columnSet.Add(new Column("DsTurno_Frio"));
          columnSet.Add(new Column("DsBox_Frio"));
          columnSet.Add(new Column("DsTurno_Seco"));
          columnSet.Add(new Column("DsBox_Seco"));
          columnSet.Add(new Column("Estado"));
          columnSet.Add(new Column("FechaInicio", "", false, "dd/MM/yyyy HH:mm:ss"));
          columnSet.Add(new Column("FechaCierre", "", false, "dd/MM/yyyy HH:mm:ss"));
          columnSet.Add(new Column("FechaXml", "", false, "dd/MM/yyyy HH:mm:ss"));
          columnSet.Add(new Column("FechaExpide", "", false, "dd/MM/yyyy HH:mm:ss"));
          columnSet.Add(new Column("FechaFactura", "", false, "dd/MM/yyyy HH:mm:ss"));
          columnSet.Add(new Column("SiempreDisponible_Frio"));
          columnSet.Add(new Column("SiempreDisponible_Seco"));

          return columnSet;
      }
   }
}
