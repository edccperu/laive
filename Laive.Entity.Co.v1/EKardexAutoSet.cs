using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Co
{
    /// <summary>
    /// Entidad para la Tabla: CO_KardexTemp (CO_KardexTemp)
    /// </summary>
    public class EKardexAutoSet : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public ICollection<EKardexAuto> listKardex { get; set; }

    }
}
