using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_ChequeComprobante (FI_ChequeComprobante)
   /// </summary>
   public class EChequeComprobante : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdCheque { get; set; }
      public string Transaccion { get; set; }
      public int NumComprobante { get; set; }
      public int CodigoTipoSugerencia { get; set; }
      public string GlosaTipoSugerencia { get; set; }
      public string Referencia { get; set; }
      public string Moneda { get; set; }
      public decimal Importe { get; set; }
   }
}
