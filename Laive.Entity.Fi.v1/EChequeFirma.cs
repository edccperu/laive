using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Entity.Fi
{
   
   /// <summary>
   /// Entidad para la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   public class EChequeFirma : IEntityBase 
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
   
      public int IdCheque { get; set; }
      public byte[] Firma1erFirmante { get; set; }
      public byte[] Firma2doFirmante { get; set; }
     
   }
}
