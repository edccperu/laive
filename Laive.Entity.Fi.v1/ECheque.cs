using System;
using Laive.Core.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Entity.Fi
{
   
   /// <summary>
   /// Entidad para la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   public class ECheque : IEntityBase 
   {
      public EntityState EntityState { get; set; }
      public string EntityFilter { get; set; }
      public Int64 RowNumber { get; set; }
      public int IdCheque { get; set; }
      public string NumCheque { get; set; }
      public string CodigoPartner { get; set; }
      public string Beneficiario { get; set; }
      public Nullable<DateTime> FechaPago { get; set; }
      //public DateTime FechaPago { get; set; }
      public string TipoTransaccion { get; set; }
      public Nullable<int> NroTransaccion { get; set; }
      public Nullable<int> Ejercicio { get; set; }
      public Nullable<int> NroAsiento { get; set; }
      public Nullable<int> LotePago { get; set; }
      public string Moneda { get; set; }
      public Nullable<decimal> ImporteCheque { get; set; }
      public string Codigo1erFirmante { get; set; }
      public string Nombre1erFirmante { get; set; }
      public string Codigo2doFirmante { get; set; }
      public string Nombre2doFirmante { get; set; }
      public string CodigoPoder { get; set; }
      public string GlosaPoder { get; set; }
      public string CodigoBanco { get; set; }
      public string DsBanco { get; set; }
      public string CodigoMetodoPago { get; set; }
      public string CodigoEstado { get; set; }
      public string GlosaEstado { get; set; }
      public string DsEstadoImportacion { get; set; }
      public string Login { get; set; }

      public string FechaRegistro { get; set; }
      public string GlosaBanco { get; set; }
      public int TotalCheques { get; set; }
      public decimal ImporteTotal { get; set; }
      public DateTime FechaLog { get; set; }

      public string Tipo { get; set; }

      public string glosaTipoSugerencia { get; set; }
      public ICollection<EChequeComprobante> ListComprobantes { get; set; }
      public ICollection<EChequeVoucher> ListVoucher { get; set; }

      public ICollection<EChequeResumen> ListResumen { get; set; }

      

      public List<Column> ColumnSet()
      {
         List<Column> columnSet = new List<Column>();
         columnSet.Add(new Column("CodigoBanco"));
         columnSet.Add(new Column("DsBanco"));
         columnSet.Add(new Column("NumCheque"));
         columnSet.Add(new Column("NroTransaccion"));
         columnSet.Add(new Column("NroAsiento"));
         columnSet.Add(new Column("LotePago"));
         columnSet.Add(new Column("Moneda"));
         columnSet.Add(new Column("ImporteCheque"));
         columnSet.Add(new Column("DsEstadoImportacion"));  
         return columnSet;
      }
   }
}
