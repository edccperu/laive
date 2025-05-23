using System;
using SamNet.Core.Data;

namespace SamNet.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_UsuarioCCosto (MG_UsuarioCCosto)
    /// </summary>
    public class EUsuarioCCosto : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdUnidadEjec { get; set; }
        public string IdSede { get; set; }
        public string IdPeriodo { get; set; }
        public string IdUser { get; set; }
        public string IdCCosto { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
    }
}
