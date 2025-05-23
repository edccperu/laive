using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;
using System.ComponentModel;


namespace Laive.Core.Entity
{
    public class UserActiveDirectory
    {
        public string idLogon { get; set; }
        public string dsNombres { get; set; }
        public string dsApellidos { get; set; }
        public string stAnulado { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("idLogon"));
            columnSet.Add(new Column("dsNombres"));
            columnSet.Add(new Column("dsApellidos"));
            return columnSet;
        }
    }
}
