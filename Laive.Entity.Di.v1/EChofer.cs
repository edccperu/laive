using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_Chofer (DI_Chofer)
	/// </summary>
	public class EChofer: IEntityBase
	{
		public EntityState EntityState  { get; set; }
        public string EntityFilter { get; set; }
		public int IdChofer { get; set; }
		public string ClaveChofer { get; set; }
		public string NombreChofer { get; set; }
		public string LicenciaChofer { get; set; }
		public string Comunicacion { get; set; }
		public Boolean Activo { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdChofer"));
            columnSet.Add(new Column("ClaveChofer", "claveChofer"));
            columnSet.Add(new Column("NombreChofer", "nombreChofer"));
            columnSet.Add(new Column("LicenciaChofer", "licenciaChofer"));
            columnSet.Add(new Column("Comunicacion", "comunicacion"));
            columnSet.Add(new Column("Activo"));
            return columnSet;
        }
	}
}
