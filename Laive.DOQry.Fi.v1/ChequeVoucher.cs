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
   /// Data Object para Consultas a la Tabla: FI_ChequeVoucher (FI_ChequeVoucher)
   /// </summary>
   /// <remarks></remarks>
   public class ChequeVoucher : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));
            arrPrm.Add(DataHelper.CreateParameter("@pcuentaContable", SqlDbType.Char, 12, objE.CuentaContable));
            arrPrm.Add(DataHelper.CreateParameter("@pcargoAbono", SqlDbType.Char, 1, objE.CargoAbono));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_ChequeVoucher_qry01", arrPrm);

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

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("FI_ChequeVoucher_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EChequeVoucher>(dr, typeof(EChequeVoucher));

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

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_ChequeVoucher_qry03", arrPrm);

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

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, objE.IdCheque));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_ChequeVoucher_qry04", arrPrm);

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

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_ChequeVoucher_qry06", arrPrm);

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

         EChequeVoucher objE = (EChequeVoucher)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("FI_ChequeVoucher_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EChequeVoucher value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, value.IdCheque));
         arrPrm.Add(DataHelper.CreateParameter("@pcuentaContable", SqlDbType.Char, 12, value.CuentaContable));
         arrPrm.Add(DataHelper.CreateParameter("@pcargoAbono", SqlDbType.Char, 1, value.CargoAbono));

         return arrPrm;

      }

      #endregion

   }
}
