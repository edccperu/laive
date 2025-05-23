using System;
using Laive.Core.Data;
using System.Collections.Generic;

namespace Laive.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_CentroCosto (MG_CentroCosto)
    /// </summary>
    public class ECentroCostoSet : IEntityBase
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

        public List<ECentroCosto> listCCosto { get; set; }

    }
}
