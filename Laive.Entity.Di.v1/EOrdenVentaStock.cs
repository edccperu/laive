using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_OrdenVenta (DI_OrdenVenta)
	/// </summary>
   public class EOrdenVentaStock : IEntityBase
	{
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
      public string CodigoArticulo { get; set; }
      public string TipoProducto { get; set; }
      public string FechaProduccion { get; set; }
      public string FechaVencimiento { get; set; }
      public int DiasVencimiento { get; set; }
		public int Shelflife { get; set; }
      public string Consistencia { get; set; }
      public string UnidadVenta { get; set; }
      public decimal Stock { get; set; }
      public decimal CantidadUndVenta { get; set; }
      public decimal Kilos { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoArticulo"));
         columnSet.Add(new Column("FechaProduccion"));
         columnSet.Add(new Column("FechaVencimiento"));
         columnSet.Add(new Column("DiasVencimiento"));
         columnSet.Add(new Column("Shelflife"));
         columnSet.Add(new Column("Consistencia"));
         columnSet.Add(new Column("UnidadVenta"));
         columnSet.Add(new Column("Stock", "", true, "N2"));
         columnSet.Add(new Column("CantidadUndVenta", "", true, "N2"));
         columnSet.Add(new Column("Kilos", "", true, "N2"));
         return columnSet;
      }

	}
}
