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
   /// Data Object para Consultas a la Tabla: FI_BaanBanco (FI_BaanBanco)
   /// </summary>
   /// <remarks></remarks>
   public class BaanBanco : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoBanco", SqlDbType.Char, 3, objE.CodigoBanco));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_BaanBanco_qry01", arrPrm);

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

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("FI_BaanBanco_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EBaanBanco>(dr, typeof(EBaanBanco));

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

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_BaanBanco_qry03", arrPrm);

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

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_BaanBanco_qry04", arrPrm);

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

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_BaanBanco_qry06", arrPrm);

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

         EBaanBanco objE = (EBaanBanco)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("FI_BaanBanco_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EBaanBanco value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoBanco", SqlDbType.Char, 3, value.CodigoBanco));

         return arrPrm;

      }

      #endregion

   }
}
