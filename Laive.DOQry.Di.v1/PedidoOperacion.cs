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
    /// Data Object para Consultas a la Tabla: DI_PedidoOperacion (DI_PedidoOperacion)
    /// </summary>
    /// <remarks></remarks>
    public class PedidoOperacion : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = new ArrayList();   

                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, objE.TipoCarga));
                arrPrm.Add(DataHelper.CreateParameter("@pstpo", SqlDbType.Bit, objE.Stpo));
                arrPrm.Add(DataHelper.CreateParameter("@pisUpdate", SqlDbType.Bit, objE.IsUpdate));
                arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char,5, objE.IdUserTkCarga));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoOperacion_qry01", arrPrm);

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

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("DI_PedidoOperacion_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EPedidoOperacion>(dr, typeof(EPedidoOperacion));

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

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoOperacion_qry03", arrPrm);

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

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoOperacion_qry04", arrPrm);

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
            throw new NotImplementedException();
        }

        public bool Exists(IEntityBase value)
        {

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("DI_PedidoOperacion_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(EPedidoOperacion value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));

            return arrPrm;

        }

        #endregion

        public IEntityBase GetTotalesByIdUser(IEntityBase value)
        {
           EPedidoOperacion objE = (EPedidoOperacion)value;

           try
           {

              ArrayList arrPrm = new ArrayList();

              arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char,5, objE.IdUserTkCarga));
              arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));

              DataTable dt = this.ExecuteDatatable("DI_PedidoOperacion_qry10", arrPrm);
              ETotalesPedidoOperacion objETotales = new ETotalesPedidoOperacion();

              foreach (DataRow dr in dt.Rows)
                  objETotales = DataHelper.CopyDataRowToEntity<ETotalesPedidoOperacion>(dr, typeof(ETotalesPedidoOperacion));

              return objETotales;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public ICollection<T> GetApertura<T>(IEntityBase value) where T : new()
        {

           EPedidoOperacion objE = (EPedidoOperacion)value;

           try
           {

              ArrayList arrPrm = new ArrayList();

              arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
              arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
              arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
              arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, objE.TipoCarga));
              arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char, 5, objE.IdUserTkCarga));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoOperacion_qry11", arrPrm);

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
