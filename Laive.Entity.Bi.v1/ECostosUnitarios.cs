using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;


namespace Laive.Entity.Bi
{
    public class ECostosUnitarios : IEntityBase
    {
        private string _strStAnulado = "";
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo_Articulo { get; set; }
        public double Costo_Unitario { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("Año"));
            columnSet.Add(new Column("Mes"));
            columnSet.Add(new Column("Fecha", "", true, "dd/MM/yyyy"));
            columnSet.Add(new Column("Codigo_Articulo"));
            columnSet.Add(new Column("Costo_Unitario", "", false, "N2"));
            return columnSet;
        }

    }
}
