using System;
using Laive.Core.Data;
using Laive.Core.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using Laive.Core.Common;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_Usuario (SY_Usuario)
    /// </summary>
    public class EUsuario : IEntityBase
    {
        public EUsuario(){
           EntityState = Core.Data.EntityState.Unchanged;
        }
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        [DisplayName("Codigo")]
        public string IdUser { get; set; }
        [DisplayName("Login")]
        public string IdLogon { get; set; }
        [DisplayName("Password")]
        public string IdPassword { get; set; }
        [DisplayName("Apellidos y Nombres")]
        public string DsNombres { get; set; }
        [DisplayName("El acceso Expira?")]
        public bool StNoExpira { get; set; }
        [DisplayName("Fecha Fin de Acceso")]
        public Nullable<DateTime> FeExpira { get; set; }
        [DisplayName("Grupo")]
        public string IdGrupo { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
        public EMenuPageUsuario[] ListNodeTV { get; set; }

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdUser"));
            columnSet.Add(new Column("IdLogon"));
            columnSet.Add(new Column("DsNombres"));
            columnSet.Add(new Column("EntityState"));
            return columnSet;
        }

        public List<Column> ColumnSetAddUsuario()
        {
           List<Column> columnSet = new List<Column>();
           columnSet.Add(new Column("IdUser"));
           columnSet.Add(new Column("IdLogon"));
           columnSet.Add(new Column("DsNombres"));
           columnSet.Add(new Column("EntityState"));
           return columnSet;
        }

    }
}
