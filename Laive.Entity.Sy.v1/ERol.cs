using System;
using Laive.Core.Data;

namespace Laive.Entity.Sy
{
   /// <summary>
   /// Entidad para la Tabla: SY_Rol (SY_Rol)
   /// </summary>
   public class ERol : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public int IdRol { get; set; }
      public string DsNombreRol { get; set; }
      public string DsDescripcionRol { get; set; }
      public string StAnulado { get; set; }
      public string IdUserTk { get; set; }
      public string IdPc { get; set; }
      public DateTime FeRegistro { get; set; }
      public EMenuPageRol[] ListNodeTV { get; set; }
      public ERolUsuario[] ListRolUsuario { get; set; }
   }
}
