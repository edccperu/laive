using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Co
{
    /// <summary>
    /// Entidad para la Tabla: CO_KardexDca (CO_KardexDca)
    /// </summary>
    public class EKardexDca : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public Int64 RowNumber { get; set; }
        public string Periodo { get; set; }
        public string Mes { get; set; }
        public string CodigoArticulo { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string CodigoAlmacen { get; set; }
        public string TipoOperacion { get; set; }
        public string Orden { get; set; }
        public int Secuencia { get; set; }
        public string Estado { get; set; }
        public decimal Mauc { get; set; }
        public decimal CantidadStock { get; set; }
        public decimal CantidadAlmacen { get; set; }
        public decimal Unitario { get; set; }
        public decimal Costo { get; set; }
        public decimal CantidadSaldoStock { get; set; }
        public decimal CantidadSaldoAlmacen { get; set; }
        public decimal CostoSaldo { get; set; }
        public string GrupoContable { get; set; }
        public int EstadoContabilizado { get; set; }
        public string UnidadTransaccion { get; set; }
        public decimal ImporteIngresoEgreso { get; set; }
        public string TipoReporte { get; set; }
        public string Departamento { get; set; }
        public int Devolucion { get; set; }
        public int CodigoMovimiento { get; set; }
        public string GlosaMovimiento { get; set; }
        public string CodigoComponenteCosto { get; set; }
        public string CodigoFamilia { get; set; }
        public string CodigoMotivo { get; set; }
        public int CodigoTransaccion { get; set; }
        public string GlosaTransaccion { get; set; }
        public decimal CantidadIngreso { get; set; }
        public decimal UnitarioIngreso { get; set; }
        public decimal CostoIngreso { get; set; }
        public decimal CantidadEgreso { get; set; }
        public decimal UnitarioEgreso { get; set; }
        public decimal CostoEgreso { get; set; }
        public decimal CantidadSaldo { get; set; }
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
            columnSet.Add(new Column("Mauc", "", true, "N4"));
            columnSet.Add(new Column("CantidadIngreso", "", true, "N4"));
            columnSet.Add(new Column("UnitarioIngreso", "", true, "N4"));
            columnSet.Add(new Column("CostoIngreso", "", true, "N2"));
            columnSet.Add(new Column("CantidadEgreso", "", true, "N4"));
            columnSet.Add(new Column("UnitarioEgreso", "", true, "N4"));
            columnSet.Add(new Column("CostoEgreso", "", true, "N2"));
            columnSet.Add(new Column("CantidadSaldo", "", false, "N4"));
            columnSet.Add(new Column("CostoSaldo", "", false, "N2"));
            return columnSet;
        }
    }
}
