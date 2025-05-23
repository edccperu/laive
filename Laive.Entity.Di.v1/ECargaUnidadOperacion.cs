using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
    /// <summary>
    /// Entidad para la Tabla: DI_CargaUnidadOperacion (DI_CargaUnidadOperacion)
    /// </summary>
    public class ECargaUnidadOperacion : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdRuta { get; set; }
        public int IdCargaUnidad { get; set; }
        public string Orden { get; set; }
        public int Linea { get; set; }
        public int Sublinea { get; set; }
        public string CodigoPartner { get; set; }
        public string CodigoArticulo { get; set; }
        public string GlosaArticulo { get; set; }
        public string TipoCarga { get; set; }
        public decimal Paleta { get; set; }
        public decimal Empaque { get; set; }
        public decimal CantidadPedido { get; set; }
        public decimal KilosPedido { get; set; }
        public decimal ImportePedido { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();

            columnSet.Add(new Column("IdRuta"));
            columnSet.Add(new Column("CodigoPartner"));
            columnSet.Add(new Column("CodigoArticulo"));
            columnSet.Add(new Column("GlosaArticulo"));
            columnSet.Add(new Column("Orden"));
            columnSet.Add(new Column("Linea"));
            columnSet.Add(new Column("Sublinea"));
            columnSet.Add(new Column("Paleta", "", false, "N2"));
            columnSet.Add(new Column("Empaque", "", false, "N2"));
            columnSet.Add(new Column("CantidadPedido", "", false, "N2"));
            columnSet.Add(new Column("KilosPedido", "", false, "N4"));
            columnSet.Add(new Column("ImportePedido", "", false, "N2"));
            columnSet.Add(new Column("IdCargaUnidad"));

            return columnSet;
        }
    }
}
