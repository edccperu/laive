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
   /// Data Object para Consultas a la Tabla: DI_ShelfLifeAdicional (DI_ShelfLifeAdicional)
   /// </summary>
   /// <remarks></remarks>
   public class ShelfLifeAdicional : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_ShelfLifeAdicional_qry01", arrPrm);

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("DI_ShelfLifeAdicional_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EShelfLifeAdicional>(dr, typeof(EShelfLifeAdicional));

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_ShelfLifeAdicional_qry03", arrPrm);

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_ShelfLifeAdicional_qry04", arrPrm);

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_ShelfLifeAdicional_qry06", arrPrm);

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            if (objE.CodigoPartner == null )
            {
               objE.CodigoPartner = "";
            }
            if (objE.CodigoGrupo == null )
            {
               objE.CodigoGrupo = "";
            }

            // ArrayList arrPrm = BuildParamInterface(objE);
            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@ptipoRegistro", SqlDbType.Char, 3, objE.TipoRegistro));
            // arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, objE.CodigoAlmacen));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoGrupo", SqlDbType.Char, 9, objE.CodigoGrupo));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaInicio", SqlDbType.Date, objE.FechaInicio));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaFin", SqlDbType.Date, objE.FechaInicio));
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("DI_ShelfLifeAdicional_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EShelfLifeAdicional value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidShelfLifeAdicional", SqlDbType.Int, value.IdShelfLifeAdicional));

         return arrPrm;

      }

      #endregion

      public int GetShelfLife(IEntityBase value)
      {
         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@ptipoRegistro", SqlDbType.Char, 3, objE.TipoRegistro));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoGrupo", SqlDbType.Char, 9, objE.CodigoGrupo));

            DataTable dt = this.ExecuteDatatable("DI_ShelfLifeAdicional_qry10", arrPrm);
            if(dt.Rows.Count > 0)
               return Convert.ToInt32(dt.Rows[0][0].ToString());
            else
               return 0;
         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }


   }
}
