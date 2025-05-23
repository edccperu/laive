using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
    /// <summary>
    /// Entidad para la Tabla: DI_CargaUnidadOperacion (DI_CargaUnidadOperacion)
    /// </summary>
   public class ECargaUnidadFactura : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdCargaUnidad { get; set; }
        public string CodigoPartner { get; set; }
        public string TipoTransaccion { get; set; }
        public int NumTransaccion { get; set; }
        public string Orden { get; set; }
        public int Linea { get; set; }
        public string CodigoArticulo { get; set; }
        public string GlosaArticulo { get; set; }
        public string Carpeta { get; set; }
        public decimal KilosNeto { get; set; }
        public decimal KilosBruto { get; set; }
        public decimal ImporteFactura { get; set; }

        public string TransaccionBam { get; set; }

        public string PreImpreso { get; set; }

        public string FechaComprobante { get; set; }

        public decimal KilosNetoEntregado { get; set; }

        public decimal KilosBrutoEntregado { get; set; }

        public decimal ImporteEntregado { get; set; }

       


        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();

            columnSet.Add(new Column("IdCargaUnidad"));
            columnSet.Add(new Column("CodigoPartner"));
            columnSet.Add(new Column("TipoTransaccion"));
            columnSet.Add(new Column("NumTransaccion"));
            columnSet.Add(new Column("TransaccionBam"));
            columnSet.Add(new Column("PreImpreso"));
            columnSet.Add(new Column("FechaComprobante"));
            columnSet.Add(new Column("KilosNeto", "", false, "N2"));
            columnSet.Add(new Column("KilosBruto", "", false, "N2"));
            columnSet.Add(new Column("ImporteFactura", "", false, "N2"));
            columnSet.Add(new Column("KilosNetoEntregado", "", false, "N2"));
            columnSet.Add(new Column("KilosBrutoEntregado", "", false, "N2"));
            columnSet.Add(new Column("ImporteEntregado", "", false, "N2"));
            

            return columnSet;
        }

        public List<Column> ColumnSetSFactura()
        {
           List<Column> columnSet = new List<Column>();

           columnSet.Add(new Column("IdCargaUnidad"));
           columnSet.Add(new Column("CodigoPartner"));
           columnSet.Add(new Column("Orden"));
           columnSet.Add(new Column("Linea"));
           columnSet.Add(new Column("CodigoArticulo"));
           columnSet.Add(new Column("GlosaArticulo"));
           columnSet.Add(new Column("KilosNeto", "", false, "N2"));
           columnSet.Add(new Column("KilosBruto", "", false, "N2"));
           columnSet.Add(new Column("ImporteFactura", "", false, "N2"));

           return columnSet;
        }

        public List<Column> ColumnSetOrdenesWMS()
        {
           List<Column> columnSet = new List<Column>();

           columnSet.Add(new Column("IdCargaUnidad"));
           columnSet.Add(new Column("CodigoPartner"));
           columnSet.Add(new Column("Orden"));
           columnSet.Add(new Column("Carpeta"));
           columnSet.Add(new Column("KilosNeto", "", false, "N2"));
           columnSet.Add(new Column("KilosBruto", "", false, "N2"));
           columnSet.Add(new Column("ImporteFactura", "", false, "N2"));

           return columnSet;
        }
    }
}
