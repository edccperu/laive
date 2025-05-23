using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    /// <summary>
    /// Entidad para la Tabla: FI_DEPagoComprobante (FI_DEPagoComprobante)
    /// </summary>
    public class EDEPagoComprobanteConcilia : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdPagCom { get; set; }
        public int IdLoteDetraccion { get; set; }
        public string NroDocIdentidad { get; set; }
        public string PreImpreso { get; set; }
        public decimal ImpDeposito { get; set; }
        public string Conciliado { get; set; }
        public string ConstanciaSunat { get; set; }
        public string PeriodoTributario { get; set; }

    }

}
