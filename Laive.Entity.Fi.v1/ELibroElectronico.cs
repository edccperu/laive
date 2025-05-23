using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;
namespace Laive.Entity.Fi
{
    public class ELibroElectronico : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string codigoPartnerProveedor { get; set; }
        public string glosaPartner { get; set; }
        public string preImpreso { get; set; }
        public string numBaan { get; set; }
        public decimal importeOriginal { get; set; }
        public decimal importeSoles { get; set; }
        public string codigoPorcDetraccion { get; set; }
        public decimal importeDetraccion { get; set; }
        public string fechaPago { get; set; }
        public string pagoQuintoDia { get; set; }
        public string loteDetraccion { get; set; }
        public string codigoOperacion { get; set; }
        public string glosaOperacion { get; set; }
        public string codigoBienServicio { get; set; }
        public string glosaBienServicio { get; set; }
        public string constanciaSunat { get; set; }
        public string fechaDeposito { get; set; }
        public string asiento { get; set; }
        public int valorReferencia { get; set; }
        public string fechaEmision { get; set; }
        public List<Column> ColumnSet() 
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("numBaan"));
            columnSet.Add(new Column("fechaEmision"));
            columnSet.Add(new Column("preImpreso"));
            columnSet.Add(new Column("moneda"));
            columnSet.Add(new Column("ImporteDeposito", "", false, "N2"));
            return columnSet;
        }
    }
}
