using System;
using Laive.Core.Data;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_PrioridadAtencion (DI_PrioridadAtencion)
   /// </summary>
   public class EPrioridadAtencionSet : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public List<EPrioridadAtencion> EPrioridadAtencionList { get; set; }
   }
}
