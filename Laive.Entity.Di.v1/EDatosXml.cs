using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_CargaUnidadOperacion (DI_CargaUnidadOperacion)
   /// </summary>
   public class EDatosXml : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string Orden { get; set; }
      public int Linea { get; set; }
      public string Sporden { get; set; }
      public string CodigoPartner { get; set; }
      public string ClavePartner { get; set; }
      public string Turno { get; set; }
      public string Locacion { get; set; }
      public string Entidad { get; set; }
	   public int IdBox { get; set; }
      public string CodigoBox { get; set; }
      public string CodigoGrupo { get; set; }
      public string CodigoArticulo { get; set; }
      public string GlosaArticulo { get; set; }
      public string UnidadPedido { get; set; }
      public Decimal cantidadPedido { get; set; }
      public int NumberFile { get; set; }

   }
}
