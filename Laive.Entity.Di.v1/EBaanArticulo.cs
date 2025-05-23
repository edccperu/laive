using System;
using Laive.Core.Data;

namespace Laive.Entity.Di
{
   /// <summary>
   /// Entidad para la Tabla: DI_BaanArticulo (DI_BaanArticulo)
   /// </summary>
   public class EBaanArticulo : IEntityBase
   {
      private string _strStAnulado = "";
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public string CodigoArticulo { get; set; }
      public string GlosaArticulo { get; set; }
      public string UnidadStock { get; set; }
      public string DobleUnidad { get; set; }
      public string UnidadVenta { get; set; }
      public string TipoProducto { get; set; }
      public string CodigoAlmacen { get; set; }
      public decimal Paleta { get; set; }
      public string CodigoLineaDespacho { get; set; }
      public string GlosaLineaDespacho { get; set; }
      public string UndEmpaque { get; set; }
      public decimal UndEmpaquePeso { get; set; }
      public int UndEmpaqueCapacidad { get; set; }
      public decimal FactorConverWms { get; set; }
      public int Shelflife { get; set; }
   }
}
