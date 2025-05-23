using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_MenuPageUsuario (SY_MenuPageUsuario)
    /// </summary>
    public class EMenuPageRol : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdMenuPage { get; set; }
        public int IdRol { get; set; }
        public int StateCheck { get; set; }
        private string StAnulado { get; set; }
    }
}
