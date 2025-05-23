using System;
using Laive.Core.Data;

namespace Laive.Entity.Bi
{
   /// <summary>
   /// Entidad para la Tabla: BI_Area (BI_Area)
   /// </summary>
   public class EArea : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int CodigoArea { get; set; }
      public string GlosaArea { get; set; }
   }
}
