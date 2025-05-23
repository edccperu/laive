using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanGrpPartner (DI_BaanGrpPartner)
   /// </summary>
   public class EBaanGrpPartner : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoGrpPartner { get; set; }
      public string GlosaGrpPartner { get; set; }
   }
}
