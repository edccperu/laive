using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
    /// <summary>
    /// Entidad para la Tabla: DI_OrdenVenta (DI_OrdenVenta)
    /// </summary>
    public class EOrdenVentaArticulo : IEntityBase
    {
        private string _strStAnulado = "";
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public DateTime FechaPrograma { get; set; }
        public string TipoProducto { get; set; }
        public int TipoAsignacion { get; set; }
        public string CodigoArticulo { get; set; }
        public string GlosaArticulo { get; set; }
        public string UnidadPedido { get; set; }
        public decimal CantidadPedido { get; set; }
        public decimal KilosNeto { get; set; }

        public decimal FactorUndVta2Base { get; set; }
        public int UndEmpaqueCapacidad { get; set; }
        public decimal UndEmpaquePeso { get; set; }

        public string Estado { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("CodigoArticulo"));
            columnSet.Add(new Column("GlosaArticulo"));
            columnSet.Add(new Column("UnidadPedido"));
            columnSet.Add(new Column("CantidadPedido", "", true, "N2"));
            columnSet.Add(new Column("KilosNeto", "", true, "N2"));
            columnSet.Add(new Column("TipoProducto"));
            columnSet.Add(new Column("FactorUndVta2Base"));
            columnSet.Add(new Column("UndEmpaqueCapacidad"));
            columnSet.Add(new Column("UndEmpaquePeso"));
            columnSet.Add(new Column("Estado"));
            return columnSet;
        }

    }
}
