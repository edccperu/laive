using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_TipoResultadoAsignacion (DI_TipoResultadoAsignacion)
   /// </summary>
   public class ETipoResultadoAsignacion : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int CodigoResultado { get; set; }
      public string GlosaResultado { get; set; }
   }
}
