using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_TipoCarga (DI_TipoCarga)
	/// </summary>
	public class ETipoCarga: IEntityBase
	{
		
		public EntityState EntityState  { get; set; }
        public string EntityFilter { get; set; }
		public string TipoCarga { get; set; }
		public string GlosaCarga { get; set; }
		public Boolean  Activo { get; set; }
		public string TipoProducto { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("TipoCarga", "tipoCarga"));
            columnSet.Add(new Column("GlosaCarga", "glosaCarga"));
            columnSet.Add(new Column("TipoProducto", "tipoProducto"));
            columnSet.Add(new Column("Activo"));
            return columnSet;
        }
	}
}
