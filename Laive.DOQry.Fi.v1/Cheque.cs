using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Fi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Fi
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   /// <remarks></remarks>
   public class Cheque : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar,-1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry01", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public IEntityBase GetByKey(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("FI_Cheque_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<ECheque>(dr, typeof(ECheque));

            return objE;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry03", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetList<T>(IEntityBase value) where T : new()
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry04", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_Cheque_qry06", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public bool Exists(IEntityBase value)
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("FI_Cheque_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

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

         return arrPrm;

      }

      #endregion

      #region BO ICheque 

      public ICollection<T> GetChequeInconsistente<T>(IEntityBase value) where T : new()
      {

         ECheque objE = (ECheque)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry07", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }


      public IEntityBase GetFirmasFirmante(IEntityBase value)
      {

         EChequeFirma objE = (EChequeFirma)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));

            DataTable dt = this.ExecuteDatatable("FI_Cheque_qry15", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EChequeFirma>(dr, typeof(EChequeFirma));

            return objE;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }



      #endregion

      public ICollection<T> GetChequeEnvioEmail<T>(IEntityBase value) where T : new()
      {
          ECheque objE = (ECheque)value;
          try
          {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));
              arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_mnt20", arrPrm);

              return dt;
          }
          catch (Exception ex)
          {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
          }
      }

     //metodo

      public ICollection<T> GetConsultaChequeFirma<T>(IEntityBase value) where T : new()
      {
          EChequeResumen objE = (EChequeResumen)value;
          try
          {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
              arrPrm.Add(DataHelper.CreateParameter("@fechaRegistro", SqlDbType.VarChar, 30, objE.FechaRegistro));
              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry14", arrPrm);

              return dt;
          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }


      public ICollection<T> GetChequeXFirmar<T>(IEntityBase value) where T : new()
      {

          ECheque objE = (ECheque)value;
         
          try
          {

              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));
              arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry10", arrPrm);

              return dt;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public ICollection<T> GetChequeFirmado<T>(IEntityBase value, string Login) where T : new()
      {

          ECheque objE = (ECheque)value;



          try
          {

              ArrayList arrPrm = new ArrayList();


              arrPrm.Add(DataHelper.CreateParameter("@pcLogin", SqlDbType.VarChar, 30, Login));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry11", arrPrm);

              return dt;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public ICollection<T> GetImprimirCheque<T>(IEntityBase value) where T : new()
      {

          ECheque objE = (ECheque)value;

          try
          {

              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry12", arrPrm);

              return dt;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }


      public int VerificarCheque(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt06", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int RechazarCheque(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt07", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int RegresarCheque(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt08", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int AsignarCheque(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt09", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int FirmarCheque(string pIdCheque,string login)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));
          arrPrm.Add(DataHelper.CreateParameter("@pcLogin", SqlDbType.VarChar, -1, login));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt10", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int ImprimirCheque(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt11", arrPrm);

              return intRes;

          }
          catch (Exception ex)
          {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

          }
      }

      public int RegresarChequeFirmado(string pIdCheque)
      {

          ArrayList arrPrm = new ArrayList();

          arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.VarChar, -1, pIdCheque));

          try
          {
              int intRes = this.ExecuteNonQuery("FI_Cheque_mnt12", arrPrm);

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
