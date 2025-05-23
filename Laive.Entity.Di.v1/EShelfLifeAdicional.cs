using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: DI_ShelfLifeAdicional (DI_ShelfLifeAdicional)
	/// </summary>
	public class EShelfLifeAdicional: IEntityBase
	{
		private string _strStAnulado = "";
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public int IdShelfLifeAdicional { get; set; }
		public string CodigoArticulo { get; set; }
      public string CodigoAlmacen { get; set; }
      public string GlosaAlmacen { get; set; }
      public string CodigoGrupo { get; set; }
      public string GlosaGrupo { get; set; }
      public string GlosaArticulo { get; set; }
      public string CodigoPartner { get; set; }
      public string ClavePartner { get; set; }
      public int ShelfLife { get; set; }
		public int DiasAdicional { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public string IdUserTk { get; set; }
		public bool Activo { get; set; }
      public string DsActivo { get; set; }
      public string TipoRegistro { get; set; }
      public string GlosaTipoRegistro { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("IdShelfLifeAdicional", "a.idShelfLifeAdicional"));
         columnSet.Add(new Column("TipoRegistro", "a.tipoRegistro"));
         columnSet.Add(new Column("GlosaTipoRegistro", "f.GlosaTipoShelfLifeAdiconal"));
         columnSet.Add(new Column("CodigoAlmacen", "a.codigoAlmacen"));
         columnSet.Add(new Column("GlosaAlmacen", "d.glosaAlmacen"));
         columnSet.Add(new Column("CodigoArticulo", "a.codigoArticulo"));
         columnSet.Add(new Column("GlosaArticulo", "b.glosaArticulo"));
         columnSet.Add(new Column("CodigoGrupo", "a.codigoGrupo"));
         columnSet.Add(new Column("GlosaGrupo", "e.glosaGrpPartner"));
         columnSet.Add(new Column("CodigoPartner", "a.codigoPartner"));
         columnSet.Add(new Column("ClavePartner", "c.clavePartner"));
         columnSet.Add(new Column("ShelfLife", "a.shelfLife"));
         columnSet.Add(new Column("DiasAdicional", "a.diasAdicional"));
         columnSet.Add(new Column("FechaInicio", "a.fechaInicio",false,"dd/MM/yyyy"));
         columnSet.Add(new Column("FechaFin", "a.fechaFin", false, "dd/MM/yyyy"));
         columnSet.Add(new Column("Activo"));
         columnSet.Add(new Column("DsActivo"));
         return columnSet;
      }
	}
}
