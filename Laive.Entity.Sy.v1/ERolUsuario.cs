using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
   /// <summary>
   /// Entidad para la Tabla: SY_RolUsuario (SY_RolUsuario)
   /// </summary>
   public class ERolUsuario : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdRol { get; set; }
      public string IdUser { get; set; }
   }
}
