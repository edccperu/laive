using System;
using Laive.Core.Data;

namespace Laive.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_CentroCosto (MG_CentroCosto)
    /// </summary>
   public class EContadorMenu : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdDOM { get; set; }
        public int NumRegistros { get; set; }
        public string IdUserTk { get; set; }
    }
}
