using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
    /// <summary>
    /// Entidad para la Tabla: DI_OrdenVenta (DI_OrdenVenta)
    /// </summary>
    public class EOrdenVenta : IEntityBase
    {
        private string _strStAnulado = "";
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int TipoAsignacion { get; set; }
        public DateTime FechaPrograma { get; set; }
        public string CodigoPartner { get; set; }
        public string GlosaPartner { get; set; }
        public int IdRuta { get; set; }
        public string Orden { get; set; }
        public int Linea { get; set; }
        public int Sublinea { get; set; }
        public string TipoCarga { get; set; }
        public string CodigoArticulo { get; set; }
        public string GlosaArticulo { get; set; }
        public string CodigoGrupo { get; set; }
        public string Dpto { get; set; }
        public string CodigoAlmacen { get; set; }
        public string GlosaCanal { get; set; }
        public int Consistencia { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Paleta { get; set; }
        public decimal Empaque { get; set; }
        public string UnidadPedido { get; set; }
        public decimal CantidadPedido { get; set; }
        public decimal KilosNeto { get; set; }
        public decimal KilosBruto { get; set; }
        public decimal ImportePedido { get; set; }
        public bool Stpo { get; set; }
        public string StEstado { get; set; }
        public string IdUserTkCarga { get; set; }
        public string IdUserProceso { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("CodigoArticulo"));
            columnSet.Add(new Column("GlosaArticulo"));
            columnSet.Add(new Column("GlosaCanal"));
            columnSet.Add(new Column("CodigoPartner"));
            columnSet.Add(new Column("GlosaPartner"));
            columnSet.Add(new Column("Dpto"));
            columnSet.Add(new Column("IdRuta"));
            columnSet.Add(new Column("Orden"));
            columnSet.Add(new Column("Linea"));
            columnSet.Add(new Column("Sublinea"));
            columnSet.Add(new Column("Consistencia"));
            columnSet.Add(new Column("KilosNeto", "", true, "N2"));
            columnSet.Add(new Column("FechaVencimiento", "", true, "dd/MM/yyyy"));
            columnSet.Add(new Column("StEstado"));
            return columnSet;
        }
    }
}
