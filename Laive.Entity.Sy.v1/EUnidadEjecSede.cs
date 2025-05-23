using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_UnidadEjecSede (SY_UnidadEjecSede)
    /// </summary>
    public class EUnidadEjecSede : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdUnidadEjec { get; set; }
        public string IdSede { get; set; }
        public string DsSede { get; set; }
        public string IdVersion { get; set; }
        public string IdJerarquia { get; set; }
        public string IdCodext { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
    }
}
