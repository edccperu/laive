using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Co
{
    /// <summary>
    /// Entidad para la Tabla: CO_KardexTemp (CO_KardexTemp)
    /// </summary>
    public class EKardexAuto : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public Int64 RowNumber { get; set; }
        public string Periodo { get; set; }
        public string Mes { get; set; }
        public string CodigoArticulo { get; set; }
        public int TypoArticulo { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string CodigoAlmacen { get; set; }
        public string TipoOperacion { get; set; }
        public string Orden { get; set; }
        public int Secuencia { get; set; }
        public int Posicion { get; set; }
        public decimal Mauc { get; set; }
        public decimal CantidadIngreso { get; set; }
        public decimal UnitarioIngreso { get; set; }
        public decimal CostoIngreso { get; set; }
        public decimal CantidadEgreso { get; set; }
        public decimal UnitarioEgreso { get; set; }
        public decimal CostoEgreso { get; set; }
        public decimal CantidadSaldo { get; set; }
        public decimal CostoSaldo { get; set; }
        public decimal Mauc_OK { get; set; }
        public decimal CantidadIngreso_OK { get; set; }
        public decimal UnitarioIngreso_OK { get; set; }
        public decimal CostoIngreso_OK { get; set; }
        public decimal CantidadEgreso_OK { get; set; }
        public decimal UnitarioEgreso_OK { get; set; }
        public decimal CostoEgreso_OK { get; set; }
        public decimal CantidadSaldo_OK { get; set; }
        public decimal CostoSaldo_OK { get; set; }
        public int CodigoMovimiento { get; set; }
        public string GlosaMovimiento { get; set; }
        public int CodigoTransaccion { get; set; }
        public string GlosaTransaccion { get; set; }
        public string CodigoFamilia { get; set; }
        public string State { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Unitario { get; set; }
        public decimal Costo { get; set; }
        public decimal Cantidad_OK { get; set; }
        public decimal Unitario_OK { get; set; }
        public decimal Costo_OK { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("RowNumber"));
            columnSet.Add(new Column("GlosaTransaccion"));
            columnSet.Add(new Column("GlosaMovimiento"));
            columnSet.Add(new Column("Orden"));
            columnSet.Add(new Column("FechaTransaccion", "", true, "dd/mm/yyyy hh:mm:ss"));
            columnSet.Add(new Column("CodigoAlmacen"));
            columnSet.Add(new Column("TipoOperacion"));
            columnSet.Add(new Column("Mauc", "", true, "N4"));
            columnSet.Add(new Column("CantidadIngreso", "", true, "N4"));
            columnSet.Add(new Column("UnitarioIngreso", "", true, "N4"));
            columnSet.Add(new Column("CostoIngreso", "", true, "N2"));
            columnSet.Add(new Column("CantidadEgreso", "", true, "N4"));
            columnSet.Add(new Column("UnitarioEgreso", "", true, "N4"));
            columnSet.Add(new Column("CostoEgreso", "", true, "N2"));
            columnSet.Add(new Column("CantidadSaldo", "", false, "N4"));
            columnSet.Add(new Column("CostoSaldo", "", false, "N2"));
            columnSet.Add(new Column("TypoArticulo"));
            columnSet.Add(new Column("CodigoMovimiento"));
            return columnSet;
        }

        public List<Column> ColumnSetCalculado()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("RowNumber"));
            columnSet.Add(new Column("GlosaTransaccion"));
            columnSet.Add(new Column("GlosaMovimiento"));
            columnSet.Add(new Column("Orden"));
            columnSet.Add(new Column("FechaTransaccion", "", true, "dd/mm/yyyy hh:mm:ss"));
            columnSet.Add(new Column("CodigoAlmacen"));
            columnSet.Add(new Column("TipoOperacion"));
            columnSet.Add(new Column("Mauc_OK", "", true, "N4"));
            columnSet.Add(new Column("CantidadIngreso_OK", "", true, "N4"));
            columnSet.Add(new Column("UnitarioIngreso_OK", "", true, "N4"));
            columnSet.Add(new Column("CostoIngreso_OK", "", true, "N2"));
            columnSet.Add(new Column("CantidadEgreso_OK", "", true, "N4"));
            columnSet.Add(new Column("UnitarioEgreso_OK", "", true, "N4"));
            columnSet.Add(new Column("CostoEgreso_OK", "", true, "N2"));
            columnSet.Add(new Column("CantidadSaldo_OK", "", false, "N4"));
            columnSet.Add(new Column("CostoSaldo_OK", "", false, "N2"));
            columnSet.Add(new Column("State"));
            return columnSet;
        }

    }
}
