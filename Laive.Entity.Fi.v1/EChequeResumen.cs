using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    public class EChequeResumen: IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public Int64 RowNumber { get; set; }
        public int IdCheque { get; set; }
        public string NumCheque { get; set; }
        public string CodigoPartner { get; set; }
        public string Beneficiario { get; set; }
        public Nullable<DateTime> FechaPago { get; set; }
        //public DateTime FechaPago { get; set; }
        public string TipoTransaccion { get; set; }
        public Nullable<int> NroTransaccion { get; set; }
        public Nullable<int> Ejercicio { get; set; }
        public Nullable<int> NroAsiento { get; set; }
        public Nullable<int> LotePago { get; set; }
        public string Moneda { get; set; }
        public Nullable<decimal> ImporteCheque { get; set; }
        public string Codigo1erFirmante { get; set; }
        public string Nombre1erFirmante { get; set; }
        public string Codigo2doFirmante { get; set; }
        public string Nombre2doFirmante { get; set; }
        public string CodigoPoder { get; set; }
        public string GlosaPoder { get; set; }
        public string CodigoBanco { get; set; }
        public string DsBanco { get; set; }
        public string CodigoMetodoPago { get; set; }
        public string CodigoEstado { get; set; }
        public string GlosaEstado { get; set; }
        public string DsEstadoImportacion { get; set; }
        public string Login { get; set; }
        public string FechaRegistro { get; set; }
        public string GlosaBanco { get; set; }
        public int TotalCheques { get; set; }
        public decimal ImporteTotal { get; set; }

        
        public ICollection<EChequeComprobante> ListComprobantes { get; set; }
        public ICollection<EChequeVoucher> ListVoucher { get; set; }
    }
}
