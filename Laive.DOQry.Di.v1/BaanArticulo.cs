using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Di
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: DI_BaanArticulo (DI_BaanArticulo)
   /// </summary>
   /// <remarks></remarks>
   public class BaanArticulo : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_BaanArticulo_qry01", arrPrm);

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

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("DI_BaanArticulo_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EBaanArticulo>(dr, typeof(EBaanArticulo));

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

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_BaanArticulo_qry03", arrPrm);

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

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_BaanArticulo_qry04", arrPrm);

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

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_BaanArticulo_qry06", arrPrm);

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

         EBaanArticulo objE = (EBaanArticulo)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("DI_BaanArticulo_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EBaanArticulo value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));

         return arrPrm;

      }

      #endregion

   }
}
