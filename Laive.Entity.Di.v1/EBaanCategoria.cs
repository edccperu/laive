using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanCategoria (DI_BaanCategoria)
   /// </summary>
   public class EBaanCategoria : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoCategoria { get; set; }
      public string GlosaCategoria { get; set; }
   }
}
