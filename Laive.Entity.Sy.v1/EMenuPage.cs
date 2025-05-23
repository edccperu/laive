using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
    /// <summary>
    /// Entidad para la Tabla: SY_MenuPage (SY_MenuPage)
    /// </summary>
    public class EMenuPage : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdMenuPage { get; set; }
        public string DsMenuPage { get; set; }
        public string DsController { get; set; }
        public string DsAction { get; set; }
        public string DsArea { get; set; }
        public string DsParameter { get; set; }
        public string DsIconPath { get; set; }
        public string DsDOM { get; set; }
        public string ColorDOM { get; set; }
        public string IdPadre { get; set; }
        public int NuOrden { get; set; }
        public int NuNivel { get; set; }
        public string IdRaiz { get; set; }
        public string StEsMenu { get; set; }
        public int StateCheck { get; set; }
        public string StAnulado { get; set; }
    }
}
