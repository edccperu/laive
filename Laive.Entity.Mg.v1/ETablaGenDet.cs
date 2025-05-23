using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_TablaGenDet (MG_TablaGenDet)
    /// </summary>
    public class ETablaGenDet : IEntityBase
    {
        
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdTabla { get; set; }
        public string IdCodigo { get; set; }
        public string DsDescrip { get; set; }
        public string DsAbrev { get; set; }
        public string IdCodAlter { get; set; }
        public decimal MtValor { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
        public string StAnulado { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdCodigo"));
            columnSet.Add(new Column("DsDescrip"));
            columnSet.Add(new Column("DsAbrev"));
            columnSet.Add(new Column("IdCodAlter"));
            columnSet.Add(new Column("MtValor"));
            columnSet.Add(new Column("StAnulado"));

            return columnSet;
        }


    }
}
