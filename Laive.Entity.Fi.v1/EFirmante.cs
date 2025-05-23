using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Fi
{
	/// <summary>
	/// Entidad para la Tabla: FI_Firmante (FI_Firmante)
	/// </summary>
	public class EFirmante: IEntityBase
	{

		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public string CodigoFirmante { get; set; }
		public string NombreFirmante { get; set; }
      public byte[] Firma { get; set; }
		public string Login { get; set; }
		public bool Activo { get; set; }
      public bool FirmaManual { get; set; }
		public int IdTipoFirmante { get; set; }
      public string DsTipoFirmante { get; set; }
      public string CodigoPoder { get; set; }
      public ICollection<EPoderFirmante> ListaPoder { get; set; }
      public List<EFirmantePc> EFirmantePcList { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoFirmante", "a.codigoFirmante"));
         columnSet.Add(new Column("NombreFirmante", "a.nombreFirmante"));
         columnSet.Add(new Column("Login", "a.login"));
         columnSet.Add(new Column("FirmaManual", "a.firmaManual"));
         columnSet.Add(new Column("IdTipoFirmante"));
         columnSet.Add(new Column("DsTipoFirmante", "b.glosaTipoFirmante"));
         columnSet.Add(new Column("Activo", "a.activo"));
         return columnSet;
      }
	}
}
