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
   /// Data Object para Consultas a la Tabla: DI_OrdenVenta (DI_OrdenVenta)
   /// </summary>
   /// <remarks></remarks>
   public class OrdenVenta : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry01", arrPrm);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("DI_OrdenVenta_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EOrdenVenta>(dr, typeof(EOrdenVenta));

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry03", arrPrm);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry04", arrPrm);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_OrdenVenta_qry06", arrPrm);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("DI_OrdenVenta_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EOrdenVenta value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, value.FechaPrograma));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
         arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
         arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
         arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
         arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));

         return arrPrm;

      }

      #endregion

      #region IOrdenVenta in BO

      public ICollection<T> GetOrdenVentaArticulos<T>(IEntityBase value) where T : new()
      {

         EOrdenVentaArticulo objE = (EOrdenVentaArticulo)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar,-1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry10", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetOrdenVentaPartners<T>(IEntityBase value) where T : new()
      {

         EOrdenVentaPartner objE = (EOrdenVentaPartner)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char,9, objE.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar,-1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry11", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetOrdenVentaStock<T>(IEntityBase value) where T : new()
      {

         EOrdenVentaStock objE = (EOrdenVentaStock)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoProducto", SqlDbType.Char, 3, objE.TipoProducto));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_OrdenVenta_qry12", arrPrm,4000);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public int CantidadOrdenXArticuloNoEliminados(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();
            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
            DataTable dt = this.ExecuteDatatable("DI_OrdenVenta_qry13", arrPrm);
            
            if (dt.Rows.Count > 0)
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

      public int CantidadOrdenXPartnerNoEliminados(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

            DataTable dt = this.ExecuteDatatable("DI_OrdenVenta_qry14", arrPrm);
            if (dt.Rows.Count > 0)
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

      #endregion

   }
}
