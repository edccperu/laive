using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Co
{
    /// <summary>
    /// Entidad para la Tabla: CO_KardexDca (CO_KardexDca)
    /// </summary>
    public class EKardexDiferencia 
    {
        public Int64 RowNumber { get; set; }
        public string Periodo { get; set; }
        public string Mes { get; set; }
        public string CodigoArticulo { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string CodigoAlmacen { get; set; }
        public string TipoOperacion { get; set; }
        public string Orden { get; set; }
        public int Secuencia { get; set; }
        public decimal MaucModificado { get; set; }
        public decimal IngresoCantidadMod { get; set; }
        public decimal IngresoUnitarioMod { get; set; }
        public decimal IngresoCostoMod { get; set; }
        public decimal EgresoCantidadMod { get; set; }
        public decimal EgresoUnitarioMod { get; set; }
        public decimal EgresoCostoMod { get; set; }
        public decimal CantidadSaldoModificado { get; set; }
        public decimal CostoSaldoModificado { get; set; }
        public decimal MaucDCA { get; set; }

        public decimal IngresoCantidadDCA { get; set; }
        public decimal IngresoUnitarioDCA { get; set; }
        public decimal IngresoCostoDCA { get; set; }
        public decimal EgresoCantidadDCA { get; set; }
        public decimal EgresoUnitarioDCA { get; set; }
        public decimal EgresoCostoDCA { get; set; }

        public decimal CantidadSaldoDCA { get; set; }
        public decimal CostoSaldoDCA { get; set; }
        
        public decimal DiferenciaCantidadSaldo { get; set; }
        public decimal DiferenciaCostoSaldo { get; set; }     
        
        
        public int CodigoMovimiento { get; set; }
        public string GlosaMovimiento { get; set; }
        public int CodigoTransaccion { get; set; }
        public string GlosaTransaccion { get; set; }
        
        
        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("RowNumber"));
            columnSet.Add(new Column("GlosaTransaccion"));
            columnSet.Add(new Column("GlosaMovimiento"));
            columnSet.Add(new Column("Orden"));
            columnSet.Add(new Column("FechaTransaccion", "", true, "dd/MM/yyyy HH:mm:ss"));
            columnSet.Add(new Column("CodigoAlmacen"));
            columnSet.Add(new Column("TipoOperacion"));
            columnSet.Add(new Column("MaucModificado", "", true, "N4"));
            columnSet.Add(new Column("IngresoCantidadMod", "", true, "N4"));
            columnSet.Add(new Column("IngresoUnitarioMod", "", true, "N4"));
            columnSet.Add(new Column("IngresoCostoMod", "", true, "N4"));
            columnSet.Add(new Column("EgresoCantidadMod", "", true, "N4"));
            columnSet.Add(new Column("EgresoUnitarioMod", "", true, "N4"));
            columnSet.Add(new Column("EgresoCostoMod", "", true, "N4"));
            columnSet.Add(new Column("CantidadSaldoModificado", "", true, "N4"));
            columnSet.Add(new Column("CostoSaldoModificado", "", true, "N4"));
            columnSet.Add(new Column("MaucDCA", "", true, "N4"));
            columnSet.Add(new Column("IngresoCantidadDCA", "", true, "N4"));
            columnSet.Add(new Column("IngresoUnitarioDCA", "", true, "N4"));
            columnSet.Add(new Column("IngresoCostoDCA", "", true, "N4"));
            columnSet.Add(new Column("EgresoCantidadDCA", "", true, "N4"));
            columnSet.Add(new Column("EgresoUnitarioDCA", "", true, "N4"));
            columnSet.Add(new Column("EgresoCostoDCA", "", true, "N4"));
            columnSet.Add(new Column("CantidadSaldoDCA", "", true, "N2"));
            columnSet.Add(new Column("CostoSaldoDCA", "", true, "N4"));
            columnSet.Add(new Column("DiferenciaCantidadSaldo", "", true, "N4"));
            columnSet.Add(new Column("DiferenciaCostoSaldo", "", true, "N2"));

            return columnSet;
        }
    }
}
