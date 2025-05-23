using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_ChequeVoucher (FI_ChequeVoucher)
   /// </summary>
   public class EChequeVoucher : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdCheque { get; set; }
      public string CuentaContable { get; set; }
      public string GlosaCuentaContable { get; set; }
      public string CargoAbono { get; set; }
      public string Moneda { get; set; }
      public Nullable<decimal> ImporteSoles { get; set; }
   }
}
