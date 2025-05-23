using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Fi
{
    public class EDetraccionPagadosPartner : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string preImpreso { get; set; }
        public string numBaan { get; set; }
        public string moneda { get; set; }
        public decimal importeOriginal { get; set; }
        public decimal importeSoles { get; set; }
        public string codigoPorcDetraccion { get; set; }
        public decimal importeDetraccion { get; set; }
        public string fechaPago { get; set; }
        public string loteDetraccion { get; set; }
        public string pagoQuintoDia { get; set; }
        public string constanciaSunat { get; set; }
        public string codigoOperacion { get; set; }
        public string codigoBienServicio { get; set; }
        public int EjercicioLote { get; set; }
        public int PeriodoLote { get; set; }
        public int mesPagoIni { get; set; }
        public int mesPagoFin { get; set; }
        public string codigoPartnerPagador { get; set; }
        public string codigoPartnerProveedor { get; set; }
        public string glosaPartner { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("preImpreso"));
            columnSet.Add(new Column("numBaan"));
            columnSet.Add(new Column("codigoPartnerProveedor"));
            columnSet.Add(new Column("glosaPartner"));
            columnSet.Add(new Column("moneda"));
            columnSet.Add(new Column("importeOriginal", "", false, "N2"));
            columnSet.Add(new Column("importeSoles", "", false, "N2"));
            columnSet.Add(new Column("codigoPorcDetraccion"));
            columnSet.Add(new Column("importeDetraccion", "", false, "N2"));
            columnSet.Add(new Column("fechaPago"));
            columnSet.Add(new Column("loteDetraccion"));
            columnSet.Add(new Column("pagoQuintoDia"));
            columnSet.Add(new Column("constanciaSunat"));
            columnSet.Add(new Column("codigoOperacion"));
            columnSet.Add(new Column("codigoBienServicio"));
            return columnSet;
        }

   

    }

    
}
