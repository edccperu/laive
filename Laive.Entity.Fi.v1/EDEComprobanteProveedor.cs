using System;
using Laive.Core.Data;


namespace Laive.Entity.Fi
{
    /// <summary>
    /// Entidad para la Tabla: FI_DEComprobanteProveedor (FI_DEComprobanteProveedor)
    /// </summary>

    public class EDEComprobanteProveedor : IEntityBase
    {
        private string _strStAnulado = "";
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdComPrv { get; set; }
        public string TraBaan { get; set; }
        public int NroBaan { get; set; }
        public int LinBaan { get; set; }
        public DateTime FchEmision { get; set; }
        public string PreImpreso { get; set; }
        public string Moneda { get; set; }
        public decimal ImporteOriginal { get; set; }
        public decimal ImporteSoles { get; set; }
        public Nullable<decimal> ImporteDetraccion { get; set; }
        public DateTime FchVencimiento { get; set; }
        public DateTime FchRecepcion { get; set; }
        public string CodigoOperacion { get; set; }
        public string CodigoPorcDetraccion { get; set; }
        public string CodigoBienServicio { get; set; }
        public string CodigoPartnerPadre { get; set; }
        public string CodigoPartnerPagador { get; set; }
        public string CodigoPartnerProveedor { get; set; }
        public Nullable<int> Ejercicio { get; set; }
        public Nullable<int> Periodo { get; set; }
        public Nullable<int> Lote { get; set; }
        public string Referencia { get; set; }


    }
}
