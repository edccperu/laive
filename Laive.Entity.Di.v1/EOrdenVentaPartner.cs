using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_OrdenVenta (DI_OrdenVenta)
	/// </summary>
   public class EOrdenVentaPartner : IEntityBase
	{
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
      public DateTime FechaPrograma { get; set; }
      public int TipoAsignacion { get; set; }
      public string CodigoArticulo { get; set; }
      public string TipoProducto { get; set; }
      public string CodigoCanal { get; set; }
      public string GlosaCanal { get; set; }
		public string CodigoPartner { get; set; }
      public string ClavePartner { get; set; }
		public string Departamento { get; set; }
      public int IdRuta { get; set; }
      public string Orden { get; set; }
      public int Linea { get; set; }
      public int SubLinea { get; set; }
      public string UnidadPedido { get; set; }
      public decimal CantidadPedido { get; set; }
      public decimal KilosNeto { get; set; }
      public int ShelfLife { get; set; }
      public int DiasAdicional { get; set; }
      public int ShelfLifeFinal { get; set; }
      public decimal KilosBruto { get; set; }
      public decimal ImportePedido { get; set; }
      public DateTime FechaOrden { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("GlosaCanal"));
         columnSet.Add(new Column("CodigoPartner"));
         columnSet.Add(new Column("ClavePartner"));
         columnSet.Add(new Column("Departamento"));
         columnSet.Add(new Column("IdRuta"));
         columnSet.Add(new Column("Orden"));
         columnSet.Add(new Column("Linea"));
         columnSet.Add(new Column("SubLinea"));
         columnSet.Add(new Column("UnidadPedido"));
         columnSet.Add(new Column("CantidadPedido", "", true, "N2"));
         columnSet.Add(new Column("KilosNeto", "", true, "N2"));
         columnSet.Add(new Column("ShelfLife"));
         columnSet.Add(new Column("DiasAdicional"));
         columnSet.Add(new Column("ShelfLifeFinal"));
         columnSet.Add(new Column("KilosBruto", "", true, "N2"));
         columnSet.Add(new Column("ImportePedido", "", true, "N2"));
         columnSet.Add(new Column("FechaOrden", "", true, "dd/MM/yyyy"));
         return columnSet;
      }

	}
}
