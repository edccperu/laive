using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Fi
{
    public class EDELotePago : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }

        public int IdLoteDetraccion { get; set; }
        public int EjercicioLote { get; set; }
        public int NumeroLote { get; set; }
        public string TraBaanBco { get; set; }
        public int NroBaanBco { get; set; }
        public int LoteContable { get; set; }
        public int NroFinalizacion { get; set; }
        public decimal ImporteLote { get; set; }
        public string FechaLote { get; set; }
        public string FechaDeposito { get; set; }
        public string PagoQuintoDia { get; set; }
        public string FormaPago { get; set; }
        public string ConstanciaSunat { get; set; }
        public int NumeroLoteIni { get; set; }
        public int NumeroLoteFin { get; set; }
        public string Registro { get; set; }
        public decimal ImporteDeposito { get; set; }
        public string ArchivoDeposito { get; set; }
        public string OperacionDeposito { get; set; }
        public int CantidadDeposito { get; set; }
        public string ArchivoDescarga { get; set; }
        public string EstadoLote { get; set; }

        public string ArchivoSunat { get; set; }
        public string FechaConstancia { get; set; }
        public int PeriodoLote { get; set; }
        public int mesPagoIni { get; set; }
        public int mesPagoFin { get; set; }
        public string codigoPartnerPagador { get; set; }

        public int contar { get; set; }


        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdLoteDetraccion"));
            columnSet.Add(new Column("EjercicioLote"));
            columnSet.Add(new Column("NumeroLote"));
            columnSet.Add(new Column("ImporteLote", "", false, "N2"));
            columnSet.Add(new Column("FechaLote"));
            columnSet.Add(new Column("PagoQuintoDia"));
            columnSet.Add(new Column("FechaConstancia"));
            columnSet.Add(new Column("ImporteDeposito", "", false, "N2"));
            columnSet.Add(new Column("FormaPago"));
            columnSet.Add(new Column("TraBaanBco"));
            columnSet.Add(new Column("LoteContable"));
            columnSet.Add(new Column("NroFinalizacion"));
            columnSet.Add(new Column("ArchivoDeposito"));
            columnSet.Add(new Column("ConstanciaSunat"));
            columnSet.Add(new Column("OperacionDeposito"));
            columnSet.Add(new Column("CantidadDeposito"));
            columnSet.Add(new Column("ArchivoDescarga"));
            columnSet.Add(new Column("EstadoLote"));
            return columnSet;
        }


    }
}
