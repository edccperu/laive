using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_Transportista (DI_Transportista)
	/// </summary>
	public class ETransportista: IEntityBase
	{
		public EntityState EntityState  { get; set; }
        public string EntityFilter { get; set; }
		public int IdTransportista { get; set; }
		public string CodigoTransportista { get; set; }
		public string Ruc { get; set; }
		public string RazonSocial { get; set; }
		public string CodigoPartner { get; set; }
		public Boolean Activo { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdTransportista"));
            columnSet.Add(new Column("CodigoTransportista", "codigoTransportista"));
            columnSet.Add(new Column("Ruc", "ruc"));
            columnSet.Add(new Column("RazonSocial", "razonSocial"));
            columnSet.Add(new Column("CodigoPartner", "codigoPartner"));
            columnSet.Add(new Column("Activo"));
            return columnSet;
        }
	}
}
