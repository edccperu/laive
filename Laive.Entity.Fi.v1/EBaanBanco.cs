using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;


namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_BaanBanco (FI_BaanBanco)
   /// </summary>
   public class EBaanBanco : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoBanco { get; set; }
      public string GlosaBanco { get; set; }
      public string NroCuenta { get; set; }
      public string Divisa { get; set; }
      public string TipoTransaccion { get; set; }
      public int UltimoNumCheque { get; set; }
   }
}
