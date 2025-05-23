using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    /// <summary>
    /// Entidad para la Tabla: FI_DEPagoComprobante (FI_DEPagoComprobante)
    /// </summary>
    public class EDEPagoComprobante : IEntityBase
    {
        private string _strStAnulado = "";
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdPagCom { get; set; }
        public string TraBaanPago { get; set; }
        public int NroBaanPago { get; set; }
        public int LinBaanPago { get; set; }
        public string MonPago { get; set; }
        public decimal ImpComprobanteOriginal { get; set; }
        public decimal ImpComprobanteSoles { get; set; }
        public decimal PorDetraccion { get; set; }
        public decimal ImpDetraccion { get; set; }
        public Nullable<int> IdLoteDetraccion { get; set; }
        public int IdComPrv { get; set; }
        public string CodigoPartnerPagador { get; set; }
        public Nullable<int> LotePago { get; set; }
        public Nullable<DateTime> FechaPago { get; set; }
        public Nullable<int> LoteContable { get; set; }
        public Nullable<int> NroFinalizacion { get; set; }
        public Nullable<int> Ejercicio { get; set; }
        public Nullable<int> Periodo { get; set; }
        public string Usuario { get; set; }
    }

}
