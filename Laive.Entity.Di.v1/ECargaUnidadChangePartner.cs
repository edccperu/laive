using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
    /// <summary>
    /// Entidad para la Tabla: DI_CargaUnidad (DI_CargaUnidad)
    /// </summary>
   public class ECargaUnidadChangePartner : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }

        public int IdCargaUnidad { get; set; }
        public int NewIdCargaUnidad { get; set; }
        public string CodigoPartner { get; set; }
    }
}
