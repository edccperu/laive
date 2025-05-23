using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_AlmacenSerie (DI_AlmacenSerie)
	/// </summary>
	public class EAlmacenSerie: IEntityBase
	{
		private string _strStAnulado = "";
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public string CodigoAlmacen { get; set; }
		public string CodigoSerie { get; set; }
		public string PrimeraOrden { get; set; }
		public string UltimaOrden { get; set; }
		public bool Activo { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("EntityState"));
         columnSet.Add(new Column("CodigoSerie", "codigoSerie"));
         columnSet.Add(new Column("PrimeraOrden", "primeraOrden"));
         columnSet.Add(new Column("UltimaOrden", "ultimaOrden"));
         columnSet.Add(new Column("Activo", "activo"));
         return columnSet;
      }
	}
}
