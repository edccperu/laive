using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_Periodo (SY_Periodo)
    /// </summary>
    public class EPeriodo : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdUnidadEjec { get; set; }
        public string IdSede { get; set; }
        public string IdPeriodo { get; set; }
        public DateTime FePerIni { get; set; }
        public DateTime FePerFin { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
    }
}
