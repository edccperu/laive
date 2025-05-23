using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    public class EConstaciaSunat: IEntityBase
    {
        public EntityState EntityState { get; set; }

        public string EntityFilter { get; set; }

        public string NumeroOperacion { get; set; }

        public DateTime FechaConstancia { get; set; }

        public string NombreArchivo { get; set; }


        public int Lote { get; set; }

        public int ejercicio { get; set; }
        public string Ruc { get; set; }

        public string RazonAdquiriente { get; set; }

        public int NumeroDeposito { get; set; }

        public decimal Importe { get; set; }

        public string NumeroConstancia { get; set; }

        public string TipoProveedor { get; set; }

        public string RucProveedor { get; set; }

        public string CodigoOperador { get; set; }

        public string GlosaOperacion { get; set; }

        public string CodigoBien { get; set; }

        public string GlosaBienServicio { get; set; }

        public decimal ImporteDeposito { get; set; }

        public string PeriodoTributario { get; set; }

        public string TipoComprobante { get; set; }

        public string NumeroComprobante { get; set; }

        public string RazonSocialProveedor { get; set; }

        public string ArchivoSunat { get; set; }
        public string EstadoLote { get; set; }


    }
}
