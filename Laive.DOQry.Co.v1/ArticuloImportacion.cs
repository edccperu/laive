using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Co;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Co
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: CO_ArticuloImportacion (CO_ArticuloImportacion)
   /// </summary>
   /// <remarks></remarks>
   public class ArticuloImportacion : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EArticuloImportacion objE = (EArticuloImportacion)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            //arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, objE.Periodo));
            //arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, objE.Mes));
            //arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_ArticuloImportacion_qry01", arrPrm);

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

         EArticuloImportacion objE = (EArticuloImportacion)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("CO_ArticuloImportacion_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EArticuloImportacion>(dr, typeof(EArticuloImportacion));

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

         EArticuloImportacion objE = (EArticuloImportacion)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_ArticuloImportacion_qry03", arrPrm);

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

         EArticuloImportacion objE = (EArticuloImportacion)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_ArticuloImportacion_qry04", arrPrm);

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

         EArticuloImportacion objE = (EArticuloImportacion)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("CO_ArticuloImportacion_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EArticuloImportacion value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, value.Periodo));
         arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, value.Mes));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));

         return arrPrm;

      }
      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         throw new NotImplementedException();

      }
      #endregion

   }
}
