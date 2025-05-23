using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanPresentacion (DI_BaanPresentacion)
   /// </summary>
   public class EBaanPresentacion : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoPresentacion { get; set; }
      public string GlosaPresentacion { get; set; }
   }
}
