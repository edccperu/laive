using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_FirmantePc (FI_FirmantePc)
   /// </summary>
   public class EFirmantePc : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoFirmante { get; set; }
      public int NuSecuen { get; set; }
      public string IpFirmante { get; set; }
      public string HostNameFirmante { get; set; }
      public string Activo { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("EntityState"));
         columnSet.Add(new Column("NuSecuen"));
         columnSet.Add(new Column("IpFirmante"));
         columnSet.Add(new Column("HostNameFirmante"));
         columnSet.Add(new Column("Activo"));
         return columnSet;
      }
   }
}
