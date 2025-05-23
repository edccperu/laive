using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_Grupo (SY_Grupo)
    /// </summary>
    public class EGrupo : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdGrupo { get; set; }
        public string DsGrupo { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
    }
}
