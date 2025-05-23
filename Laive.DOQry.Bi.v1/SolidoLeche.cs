using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Core.Common;
using Laive.Entity.Bi;
using System.Collections.Generic;

namespace Laive.DOQry.Bi
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: BI_SolidoLeche (BI_SolidoLeche)
   /// </summary>
   /// <remarks></remarks>
   public class SolidoLeche : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar,-1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_SolidoLeche_qry01", arrPrm);

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

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("BI_SolidoLeche_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<ESolidoLeche>(dr, typeof(ESolidoLeche));

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

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_SolidoLeche_qry03", arrPrm);

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

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_SolidoLeche_qry04", arrPrm);

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

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "BI_SolidoLeche_qry06", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

       public bool ExistsDB(IEntityBase value)
      {
          ESolidoLeche objE = (ESolidoLeche)value;
           try
           {
               ArrayList arrPrm = new ArrayList();
               arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
               int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));
               SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

               DataTable dt = this.ExecuteDatatable("BI_SolidoLeche_qry06", arrPrm);

               return objPrm[intIdx].Value.ToString() == "1" ? true : false;
           }
           catch (Exception ex)
           {

               ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
               throw objEx;

           }

      }

      public bool Exists(IEntityBase value)
      {

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {
            
            ArrayList arrPrm = new ArrayList();
            
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char,9, objE.CodigoArticulo));
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("BI_SolidoLeche_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;
                                                                                                                                                                                                                                                                                                                                
         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(ESolidoLeche value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoSolidoLeche", SqlDbType.Int, value.CodigoSolidoLeche));

         return arrPrm;

      }

      #endregion

   }
}
