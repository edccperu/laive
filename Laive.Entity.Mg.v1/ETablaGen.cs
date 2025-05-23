using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;
using System.ComponentModel;

namespace Laive.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_TablaGen (MG_TablaGen)
    /// </summary>
    public class ETablaGen : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        [DisplayName("Codigo")]
        public string IdTabla { get; set; }
        [DisplayName("Descripción")]
        public string DsTabla { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
        public ICollection<ETablaGenDet> TablaGenDet { get; set; }

        public string[] PrimaryKey = new string[] { "IdTabla" };
        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdTabla"));
            columnSet.Add(new Column("DsTabla"));
            return columnSet;
        }
    }
}
