using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
   /// Entidad para la Tabla: ETotalesPedidoOperacion (ETotalesPedidoOperacion)
	/// </summary>
   public class ETotalesPedidoOperacion : IEntityBase
	{
		public EntityState EntityState  { get; set; }
      public string EntityFilter { get; set; }
		public decimal PesoFrios { get; set; }
		public decimal ImporteFrios { get; set; }
      public decimal PesoSecos { get; set; }
      public decimal ImporteSecos { get; set; }
      public decimal TotalPeso { get; set; }
      public decimal TotalImporte { get; set; }
      public decimal FriosPaleta { get; set; }
      public decimal FriosEmpaque { get; set; }
      public decimal FriosUnidad { get; set; }
      public decimal FriosPesoBruto { get; set; }
      public decimal FriosImporte { get; set; }
      public decimal FriosKilosDiferentePartner { get; set; }
      public decimal SecosPaleta { get; set; }
      public decimal SecosEmpaque { get; set; }
      public decimal SecosUnidad { get; set; }
      public decimal SecosPesoBruto { get; set; }
      public decimal SecosImporte { get; set; }
      public decimal SecosKilosDiferentePartner { get; set; }

	}
}
