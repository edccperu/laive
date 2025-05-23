using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanSubMarca (DI_BaanSubMarca)
   /// </summary>
   public class EBaanSubMarca : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoSubMarca { get; set; }
      public string GlosaSubMarca { get; set; }
   }
}
