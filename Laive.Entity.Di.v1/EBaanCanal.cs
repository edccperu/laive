using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanCanal (DI_BaanCanal)
   /// </summary>
   public class EBaanCanal : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoCanal { get; set; }
      public string GlosaCanal { get; set; }
   }
}
