using System;
using SamNet.Core.Data;
using System.Collections.Generic;

namespace SamNet.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_CentroCosto (MG_CentroCosto)
    /// </summary>
    public class EUsuarioCCostoSet : IEntityBase
    {
        public EntityState EntityState
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public string EntityFilter { 
            get { throw new NotImplementedException(); } 
            set { throw new NotImplementedException(); } 
        }

        public List<EUsuarioCCosto> listUsuarioCCosto { get; set; }

    }
}
