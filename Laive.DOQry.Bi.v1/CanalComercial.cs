using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using System.ServiceModel;
using Laive.Core.Data;
using Laive.Entity.Bi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Bi
{
   
   /// <summary>
   /// Data Object para Consultas a la Tabla: BI_CanalComercial (BI_CanalComercial)
   /// </summary>
   /// <remarks></remarks>
   public class CanalComercial : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_CanalComercial_qry01", arrPrm);

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

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("BI_CanalComercial_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<ECanalComercial>(dr, typeof(ECanalComercial));

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

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_CanalComercial_qry03", arrPrm);

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

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_CanalComercial_qry04", arrPrm);

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

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "BI_CanalComercial_qry06", arrPrm);

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
           ECanalComercial objE = (ECanalComercial)value;
           try
           {
               ArrayList arrPrm = new ArrayList();

               arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
               int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));
               SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));
               DataTable dt = this.ExecuteDatatable("BI_CanalComercial_qry13", arrPrm);
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

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

             ArrayList arrPrm = new ArrayList();

             arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char,9, objE.CodigoPartner));
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("BI_CanalComercial_qry12", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(ECanalComercial value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoCanalComercial", SqlDbType.Char, 3, value.Codigo));

         return arrPrm;

      }

      #endregion


      public ICollection<T> GetListNivel1<T>(IEntityBase value) where T : new()
      {

         ECanalComercial objE = (ECanalComercial)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_CanalComercial_qry10", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }


      public ICollection<T> GetListNivel2<T>(IEntityBase value) where T : new()
      {

         ECanalComercial objE = (ECanalComercial)value;

         try
         {
            ArrayList arrPrm = new ArrayList();
            arrPrm.Add(DataHelper.CreateParameter("@ppadre", SqlDbType.Int, objE.Padre));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_CanalComercial_qry11", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }


   }
}
