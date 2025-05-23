using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_PrioridadAtencion (DI_PrioridadAtencion)
   /// </summary>
   public class EPrioridadAtencion : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoPartner { get; set; }
      public int IdRuta { get; set; }
      public string Orden { get; set; }
      public int Linea { get; set; }
      public int Sublinea { get; set; }
      public int TipoAsignacion { get; set; }
      public DateTime FechaPrograma { get; set; }
      public DateTime FechaVencimiento { get; set; }
      public int Prioridad { get; set; }
      public string CodigoArticulo { get; set; }
      public int Consistencia { get; set; }
      public decimal CantidadPedido { get; set; }
      public decimal KilosNeto { get; set; }
      public decimal KilosBruto { get; set; }
      public decimal ImportePedido { get; set; }
      public string UnidadMedida { get; set; }
      public string StAnulado { get; set; }
      public string GlosaArticulo { get; set; }
      public string GlosaCanal { get; set; }
      public string GlosaPartner { get; set; }
      public string Dpto { get; set; }
      public string StEstado { get; set; }


      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoArticulo"));
         columnSet.Add(new Column("GlosaArticulo"));
         columnSet.Add(new Column("GlosaCanal"));
         columnSet.Add(new Column("CodigoPartner"));
         columnSet.Add(new Column("GlosaPartner"));
         columnSet.Add(new Column("Dpto"));
         columnSet.Add(new Column("IdRuta"));
         columnSet.Add(new Column("Orden"));
         columnSet.Add(new Column("Linea"));
         columnSet.Add(new Column("Sublinea"));
         columnSet.Add(new Column("Consistencia"));
         columnSet.Add(new Column("UnidadMedida"));
         columnSet.Add(new Column("CantidadPedido", "", true, "N2"));
         columnSet.Add(new Column("KilosNeto", "", true, "N2"));
         columnSet.Add(new Column("FechaVencimiento", "", true, "dd/MM/yyyy"));
         columnSet.Add(new Column("StEstado"));
         return columnSet;
      }
   }
}
