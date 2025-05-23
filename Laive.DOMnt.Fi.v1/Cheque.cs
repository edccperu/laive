using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Fi;

namespace Laive.DOMnt.Fi
{
   /// <summary>
   /// Data Object para Mantenimiento a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   /// <remarks></remarks>
   public class Cheque : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt01", arrPrm);

            return new object[] { objE.IdCheque };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt02", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Delete(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));

            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(ECheque value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, value.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pnumCheque", SqlDbType.Char, 15, value.NumCheque ));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
         arrPrm.Add(DataHelper.CreateParameter("@pbeneficiario", SqlDbType.VarChar, 200, value.Beneficiario));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaPago", SqlDbType.DateTime, (value.FechaPago.HasValue ? (object)value.FechaPago : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@ptipoTransaccion", SqlDbType.Char, 3, value.TipoTransaccion ));
         arrPrm.Add(DataHelper.CreateParameter("@pnroTransaccion", SqlDbType.Int, (value.NroTransaccion.HasValue ? (object)value.NroTransaccion : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pejercicio", SqlDbType.Int, (value.Ejercicio.HasValue ? (object)value.Ejercicio : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pnroAsiento", SqlDbType.Int, (value.NroAsiento.HasValue ? (object)value.NroAsiento : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@plotePago", SqlDbType.Int, (value.LotePago.HasValue ? (object)value.LotePago : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pmoneda", SqlDbType.Char, 3, value.Moneda));
         arrPrm.Add(DataHelper.CreateParameter("@pimporteCheque", SqlDbType.Decimal, (value.ImporteCheque.HasValue ? (object)value.ImporteCheque : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigo1erFirmante", SqlDbType.Char, 3, value.Codigo1erFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigo2doFirmante", SqlDbType.Char, 3, value.Codigo2doFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPoder", SqlDbType.Char, 3, value.CodigoPoder));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoBanco", SqlDbType.Char, 3, value.CodigoBanco));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoMetodoPago", SqlDbType.Char, 3, value.CodigoMetodoPago));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoEstado", SqlDbType.Char, 3, value.CodigoEstado));

         return arrPrm;

      }

      #endregion

      public int ImportChequeBaan(IEntityBase value)
      {

         EBaanBancoImport objE = (EBaanBancoImport)value;

        
         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pejercicio", SqlDbType.Int, objE.Ejercicio));
         arrPrm.Add(DataHelper.CreateParameter("@pidBanco", SqlDbType.Char,3, objE.IdBanco));
         arrPrm.Add(DataHelper.CreateParameter("@pchequeInicial", SqlDbType.Int, objE.ChequeInicial));
         arrPrm.Add(DataHelper.CreateParameter("@pchequeFinal", SqlDbType.Int, objE.ChequeFinal));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar,30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@pmessage", SqlDbType.Char, 1, ParameterDirection.InputOutput,"0"));

         try
         {
             int intRes = this.ExecuteNonQuery("FI_Cheque_mnt05_200", arrPrm);

            return Convert.ToInt32(((System.Data.SqlClient.SqlParameter)(arrPrm[5])).Value);

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;    

         }

      }

      public int ImportChequeInconsistente(IEntityBase value)
      {

         ECheque objE = (ECheque)value;


         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoBanco", SqlDbType.Char, 3, objE.CodigoBanco));
         arrPrm.Add(DataHelper.CreateParameter("@pnumCheque", SqlDbType.Char,15, objE.NumCheque));
         
         try
         {
            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt18", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }


      public int AsignarFirmante(IEntityBase value)
      {

         ECheque objE = (ECheque)value;
         
         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigo1erFirmante", SqlDbType.Char, 3, objE.Codigo1erFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigo2doFirmante", SqlDbType.Char, 3, objE.Codigo2doFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoEstado", SqlDbType.Char, 3, objE.CodigoEstado));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@fechalog", SqlDbType.DateTime, 8, objE.FechaLog));
         try
         {
             int intRes = this.ExecuteNonQuery("FI_Cheque_mnt21", arrPrm);
            return intRes;
         }
         catch (Exception ex)
         {
            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;
         }

      }

      public int CambiarEstado(IEntityBase value)
      {

         EChequeLog objE = (EChequeLog)value;

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pobservacion", SqlDbType.VarChar, 500, objE.Observacion));
         arrPrm.Add(DataHelper.CreateParameter("@pnewEstado", SqlDbType.Char, 3, objE.CodigoEstado));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@fechalog", SqlDbType.DateTime, 8, objE.FechaLog));


         try
         {
            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt14", arrPrm);
            return intRes;
         }
         catch (Exception ex)
         {
            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;
         }

      }
      public int FirmarCheque(IEntityBase value)
      {

         EChequeLog objE = (EChequeLog)value;

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pobservacion", SqlDbType.VarChar, 500, objE.Observacion));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@fechalog", SqlDbType.DateTime, 8, objE.FechaLog));

         try
         {
            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt15", arrPrm);
            return intRes;
         }
         catch (Exception ex)
         {
            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;
         }

      }

      public int RechazarCheque(IEntityBase value)
      {

         EChequeLog objE = (EChequeLog)value;

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pobservacion", SqlDbType.VarChar, 500, objE.Observacion));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@fechalog", SqlDbType.DateTime, 8, objE.FechaLog));

         try
         {
             int intRes = this.ExecuteNonQuery("FI_Cheque_mnt19", arrPrm);
            return intRes;
         }
         catch (Exception ex)
         {
            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;
         }

      }

      public int RevertirChequeFirmado(IEntityBase value)
      {

         EChequeLog objE = (EChequeLog)value;

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pobservacion", SqlDbType.VarChar, 500, objE.Observacion));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
         arrPrm.Add(DataHelper.CreateParameter("@fechalog", SqlDbType.DateTime, 8, objE.FechaLog));

         try
         {
            int intRes = this.ExecuteNonQuery("FI_Cheque_mnt17", arrPrm);
            return intRes;
         }
         catch (Exception ex)
         {
            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;
         }

      }

      public int ImportarDetraccionCabArchivo(IEntityBase value)
      {

          EConstaciaSunat objE = (EConstaciaSunat)value;
          ArrayList arrPrm = new ArrayList();
          arrPrm.Add(DataHelper.CreateParameter("@pnumeroOperacion", SqlDbType.VarChar, 10, objE.NumeroOperacion));
          arrPrm.Add(DataHelper.CreateParameter("@pfechaConstancia", SqlDbType.DateTime, objE.FechaConstancia));
          arrPrm.Add(DataHelper.CreateParameter("@pnombreArchivo", SqlDbType.VarChar, 22, objE.NombreArchivo));
          arrPrm.Add(DataHelper.CreateParameter("@pejercicio", SqlDbType.Int, objE.ejercicio));
          arrPrm.Add(DataHelper.CreateParameter("@plote", SqlDbType.Int, objE.Lote));
          arrPrm.Add(DataHelper.CreateParameter("@pruc", SqlDbType.VarChar, 20, objE.Ruc));
          arrPrm.Add(DataHelper.CreateParameter("@prazsocAdquiriente", SqlDbType.VarChar, 100, objE.RazonAdquiriente));
          arrPrm.Add(DataHelper.CreateParameter("@pnumeroDeposito", SqlDbType.Int, objE.NumeroDeposito));
          arrPrm.Add(DataHelper.CreateParameter("@pimporte", SqlDbType.Decimal, objE.Importe));
          arrPrm.Add(DataHelper.CreateParameter("@parchivoSunat", SqlDbType.VarChar, 100, objE.ArchivoSunat));
          arrPrm.Add(DataHelper.CreateParameter("@pestadoLote", SqlDbType.Char, 1, objE.EstadoLote));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_DetraCab_mnt22", arrPrm);
              return intRes;

          }
          catch (Exception ex)
          {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
          }

      }

       public int ImportarDetraccionDetArchivo(IEntityBase value)
      {
          EConstaciaSunat objE = (EConstaciaSunat)value;
          ArrayList arrPrm = new ArrayList();
          arrPrm.Add(DataHelper.CreateParameter("@pnumeroOperacion", SqlDbType.VarChar, 10, objE.NumeroOperacion));
          arrPrm.Add(DataHelper.CreateParameter("@pnumeroConstancia", SqlDbType.VarChar, 20, objE.NumeroConstancia));
          arrPrm.Add(DataHelper.CreateParameter("@ptipoProveedor", SqlDbType.VarChar, 50, objE.TipoProveedor));
          arrPrm.Add(DataHelper.CreateParameter("@prucProveedor", SqlDbType.VarChar, 20, objE.RucProveedor));
          arrPrm.Add(DataHelper.CreateParameter("@prazonSocialProveedor", SqlDbType.VarChar, 100, objE.RazonSocialProveedor));
          arrPrm.Add(DataHelper.CreateParameter("@pcodigoOperacion", SqlDbType.Char, 2, objE.CodigoOperador));
          arrPrm.Add(DataHelper.CreateParameter("@pglosaOperacion", SqlDbType.VarChar, 50, objE.GlosaOperacion));
          arrPrm.Add(DataHelper.CreateParameter("@pcodigoBienServicio", SqlDbType.Char, 3, objE.CodigoBien));
          arrPrm.Add(DataHelper.CreateParameter("@pglosaBienServicio", SqlDbType.VarChar, 50, objE.GlosaBienServicio));
          arrPrm.Add(DataHelper.CreateParameter("@pimporteDeposito", SqlDbType.Decimal, objE.ImporteDeposito));
          arrPrm.Add(DataHelper.CreateParameter("@pperiodoTributario", SqlDbType.Char,6, objE.PeriodoTributario));
          arrPrm.Add(DataHelper.CreateParameter("@ptipoComprobante", SqlDbType.VarChar,20, objE.TipoComprobante));
          arrPrm.Add(DataHelper.CreateParameter("@pnumeroComprobante", SqlDbType.VarChar,20, objE.NumeroComprobante));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_DetraDet_mnt23", arrPrm);
              return intRes;

          }
          catch (Exception ex)
          {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
          }
      }
   }
}
