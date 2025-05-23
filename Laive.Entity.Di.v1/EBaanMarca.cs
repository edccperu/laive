using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanMarca (DI_BaanMarca)
   /// </summary>
   public class EBaanMarca : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoMarca { get; set; }
      public string GlosaMarca { get; set; }
   }
}
