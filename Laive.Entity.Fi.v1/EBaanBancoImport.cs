using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
   /// <summary>
   /// Entidad para la Tabla: FI_BaanBanco (FI_BaanBanco)
   /// </summary>
   public class EBaanBancoImport : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string IdBanco { get; set; }
      public int ChequeInicial { get; set; }
      public int ChequeFinal { get; set; }
      public int IdGrid { get; set; }
      public string Login { get; set; }
      public int Ejercicio { get; set; }
   }
}
