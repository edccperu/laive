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
   /// Data Object para Consultas a la Tabla: DI_AlmacenSerie (DI_AlmacenSerie)
   /// </summary>
   /// <remarks></remarks>
   public class AlmacenSerie : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {


            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, objE.CodigoAlmacen));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_AlmacenSerie_qry01", arrPrm);

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

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("DI_AlmacenSerie_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EAlmacenSerie>(dr, typeof(EAlmacenSerie));

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

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, objE.CodigoAlmacen));
            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_AlmacenSerie_qry03", arrPrm);

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

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_AlmacenSerie_qry04", arrPrm);

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

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_AlmacenSerie_qry06", arrPrm);

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

         EAlmacenSerie objE = (EAlmacenSerie)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("DI_AlmacenSerie_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EAlmacenSerie value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoSerie", SqlDbType.Char, 3, value.CodigoSerie));

         return arrPrm;

      }

      #endregion

   }
}
