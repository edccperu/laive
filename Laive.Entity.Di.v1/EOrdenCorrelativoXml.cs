using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_OrdenCorrelativoXml (DI_OrdenCorrelativoXml)
   /// </summary>
   public class EOrdenCorrelativoXml : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string Orden { get; set; }
      public int CodAscii { get; set; }
      public DateTime FechaPrograma { get; set; }
      public int CorrelativoFile { get; set; }
   }
}
