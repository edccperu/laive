using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
	/// <summary>
	/// Entidad para la Tabla: FI_AlcancePoder (FI_AlcancePoder)
	/// </summary>
	public class EAlcancePoder: IEntityBase
	{
		private string _strStAnulado = "";
		public EntityState EntityState  { get; set; }
		public string EntityFilter { get; set; }
		public string CodigoPoder { get; set; }
		public string GlosaPoder { get; set; }
		public bool Activo { get; set; }
	}
}
