using System;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanPartner (DI_BaanPartner)
   /// </summary>
   public class EBaanPartner : IEntityBase
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoPartner { get; set; }
      public string GlosaPartner { get; set; }
      public string CodigoCanal { get; set; }
      public string ClavePartner { get; set; }
      public string ClavePartner1 { get; set; }
      public string PartnerPadre { get; set; }
      public string Dpto { get; set; }
      public int IdRuta { get; set; }
      public string GlosaRuta { get; set; }

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoPartner", "a.codigoPartner"));
         columnSet.Add(new Column("ClavePartner1", "a.glosaPartner"));
         columnSet.Add(new Column("Dpto","a.dpto"));
         columnSet.Add(new Column("ClavePartner1", "a.clavePartner1"));
         columnSet.Add(new Column("IdRuta", "b.idRuta"));
         columnSet.Add(new Column("GlosaRuta", "c.glosaRuta"));
         return columnSet;
      }
   }
}
