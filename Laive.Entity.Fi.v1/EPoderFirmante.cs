using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
	/// <summary>
	/// Entidad para la Tabla: FI_PoderFirmante (FI_PoderFirmante)
	/// </summary>
	public class EPoderFirmante: IEntityBase
	{
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public string CodigoPoder { get; set; }
		public string CodigoFirmante { get; set; }
		public bool FirmanteFijo { get; set; }
		public bool Activo { get; set; }
	}
}
