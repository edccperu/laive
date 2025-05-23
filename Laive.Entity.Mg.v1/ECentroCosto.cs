using System;
using Laive.Core.Data;

namespace Laive.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_CentroCosto (MG_CentroCosto)
    /// </summary>
    public class ECentroCosto : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdUnidadEjec { get; set; }
        public string IdSede { get; set; }
        public string IdPeriodo { get; set; }
        public string IdCCosto { get; set; }
        public string IdParent { get; set; }
        public string DsCCosto { get; set; }
        public string DsSigla { get; set; }
        public string IdSiaf { get; set; }
        public string DsDireccion { get; set; }
        public string DsTelefono { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
    }
}
