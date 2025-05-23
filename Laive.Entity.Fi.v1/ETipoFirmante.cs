using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
	/// <summary>
	/// Entidad para la Tabla: FI_TipoFirmante (FI_TipoFirmante)
	/// </summary>
	public class ETipoFirmante: IEntityBase
	{
		private string _strStAnulado = "";
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public int IdTipoFirmante { get; set; }
		public string GlosaTipoFirmante { get; set; }
      public bool Activo { get; set; }
	}
}
