using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_ChequeLog (FI_ChequeLog)
   /// </summary>
   public class EChequeLog : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdHistorial { get; set; }
      public int IdCheque { get; set; }
      public string CodigoEstadoAnt { get; set; }
      public string CodigoEstado { get; set; }
      public string GlosaEstado { get; set; }
      public DateTime FechaRegistro { get; set; }
      public string Observacion { get; set; }
      public string Login { get; set; }
      public string NombreFirmante { get; set; }

      public DateTime FechaLog { get; set; }
   }
}
