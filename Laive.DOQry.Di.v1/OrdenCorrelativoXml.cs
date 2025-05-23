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
   /// Data Object para Consultas a la Tabla: DI_OrdenCorrelativoXml (DI_OrdenCorrelativoXml)
   /// </summary>
   /// <remarks></remarks>
   public class OrdenCorrelativoXml : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EOrdenCorrelativoXml objE = (EOrdenCorrelativoXml)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            
            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenCorrelativoXml_qry01", arrPrm);

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

         EOrdenCorrelativoXml objE = (EOrdenCorrelativoXml)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("DI_OrdenCorrelativoXml_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EOrdenCorrelativoXml>(dr, typeof(EOrdenCorrelativoXml));

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

         EOrdenCorrelativoXml objE = (EOrdenCorrelativoXml)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenCorrelativoXml_qry03", arrPrm);

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

         EOrdenCorrelativoXml objE = (EOrdenCorrelativoXml)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenCorrelativoXml_qry04", arrPrm);

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

         EOrdenCorrelativoXml objE = (EOrdenCorrelativoXml)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("DI_OrdenCorrelativoXml_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         throw new NotImplementedException();

      }
      private ArrayList BuildParamInterface(EOrdenCorrelativoXml value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
         arrPrm.Add(DataHelper.CreateParameter("@pcodAscii", SqlDbType.Int, value.CodAscii));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, value.FechaPrograma));
         arrPrm.Add(DataHelper.CreateParameter("@pcorrelativoFile", SqlDbType.Int, value.CorrelativoFile));

         return arrPrm;

      }

      #endregion

   }
}
