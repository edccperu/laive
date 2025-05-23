using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_PedidoOperacion (DI_PedidoOperacion)
   /// </summary>
   public class EPedidoOperacion : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdRuta { get; set; }
      public string CodigoPartner { get; set; }
      public string Orden { get; set; }
      public int Linea { get; set; }
      public int Sublinea { get; set; }
      public string TipoCarga { get; set; }
      public string CodigoArticulo { get; set; }
      public string GlosaArticulo { get; set; }
      public decimal Paleta { get; set; }
      public decimal Empaque { get; set; }
      public decimal CantidadPedido { get; set; }
      public decimal KilosPedido { get; set; }
      public decimal ImportePedido { get; set; }
      public Boolean Stpo { get; set; }
      public Boolean IsUpdate { get; set; }
      public string StEstado { get; set; }
      public Boolean IsLineaPadre { get; set; }
      public string IdUserTkCarga { get; set; }
      public string UsuarioLock { get; set; }
      public int CantidadOrdenes { get; set; }
      public int EstadoChecked { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdRuta"));
         columnSet.Add(new Column("CodigoPartner"));
         columnSet.Add(new Column("CodigoArticulo"));
         columnSet.Add(new Column("GlosaArticulo"));
         columnSet.Add(new Column("Orden"));
         columnSet.Add(new Column("Linea"));
         columnSet.Add(new Column("Sublinea"));
         columnSet.Add(new Column("Stpo"));
         columnSet.Add(new Column("Paleta", "", false, "N2"));
         columnSet.Add(new Column("Empaque", "", false, "N2"));
         columnSet.Add(new Column("CantidadPedido", "", false, "N2"));
         columnSet.Add(new Column("KilosPedido", "", false, "N4"));
         columnSet.Add(new Column("ImportePedido", "", false, "N2"));
         columnSet.Add(new Column("TipoCarga"));
         columnSet.Add(new Column("UsuarioLock"));
         columnSet.Add(new Column("CantidadOrdenes"));
         columnSet.Add(new Column("EstadoChecked"));

         return columnSet;
      }

      public List<Column> ColumnSetApertura()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdRuta"));
         columnSet.Add(new Column("CodigoPartner"));
         columnSet.Add(new Column("CodigoArticulo"));
         columnSet.Add(new Column("GlosaArticulo"));
         columnSet.Add(new Column("Orden"));
         columnSet.Add(new Column("Linea"));
         columnSet.Add(new Column("Sublinea"));
         columnSet.Add(new Column("Stpo"));
         columnSet.Add(new Column("Paleta", "", false, "N2"));
         columnSet.Add(new Column("Empaque", "", false, "N2"));
         columnSet.Add(new Column("CantidadPedido", "", false, "N2"));
         columnSet.Add(new Column("KilosPedido", "", false, "N4"));
         columnSet.Add(new Column("ImportePedido", "", false, "N2"));
         columnSet.Add(new Column("TipoCarga"));
         columnSet.Add(new Column("UsuarioLock"));

         return columnSet;
      }

   }
}
