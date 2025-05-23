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
    /// Data Object para Consultas a la Tabla: FI_DEPagoComprobante (FI_DEPagoComprobante)
    /// </summary>
    /// <remarks></remarks>
    public class DEPagoComprobante : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidPagCom", SqlDbType.Int, objE.IdPagCom));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEPagoComprobante_qry01", arrPrm);

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

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("FI_DEPagoComprobante_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EDEPagoComprobante>(dr, typeof(EDEPagoComprobante));

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

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEPagoComprobante_qry03", arrPrm);

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

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEPagoComprobante_qry04", arrPrm);

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

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DEPagoComprobante_qry05", arrPrm);

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

            EDEPagoComprobante objE = (EDEPagoComprobante)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_DELotePago_qry05", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }


        private ArrayList BuildParamInterface(EDEPagoComprobante value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidPagCom", SqlDbType.Int, value.IdPagCom));

            return arrPrm;

        }

        #endregion

        public ICollection<T> GetComprobanteDetraForConsiliacion<T>(IEntityBase value) where T : new()
        {

            EDEPagoComprobanteConcilia objE = (EDEPagoComprobanteConcilia)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEPagoComprobante_qry10", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetComprobanteDetraForConsiliacionMonto<T>(IEntityBase value) where T : new()
        {

            EDEPagoComprobanteConcilia objE = (EDEPagoComprobanteConcilia)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEPagoComprobante_qry11", arrPrm);

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
