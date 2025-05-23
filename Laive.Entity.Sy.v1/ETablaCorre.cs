using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_TablaCorre (SY_TablaCorre)
    /// </summary>
    public class ETablaCorre : IEntityBase
    {
        
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdUnidadEjec { get; set; }
        public string IdSede { get; set; }
        public string IdPeriodo { get; set; }
        public string IdTabla { get; set; }
        public int NuIni { get; set; }
        public int NuFin { get; set; }
        public int NuIntervalo { get; set; }
        public int NuUltGen { get; set; }
        public string DsFormato { get; set; }
    }
}
