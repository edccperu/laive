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
    /// Data Object para Consultas a la Tabla: CO_KardexDca (CO_KardexDca)
    /// </summary>
    /// <remarks></remarks>
    public class KardexDca : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EKardexDca objE = (EKardexDca)value;

            try
            {

                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pAnio", SqlDbType.Char, 4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcCodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));


                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexDca_qry01", arrPrm);

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

            EKardexDca objE = (EKardexDca)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("CO_KardexDca_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EKardexDca>(dr, typeof(EKardexDca));

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

            EKardexDca objE = (EKardexDca)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexDca_qry03", arrPrm);

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

            EKardexDca objE = (EKardexDca)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexDca_qry04", arrPrm);

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

            EKardexDca objE = (EKardexDca)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("CO_KardexDca_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(EKardexDca value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, value.Periodo));
            arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, value.Mes));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaTransaccion", SqlDbType.DateTime, value.FechaTransaccion));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 3, value.CodigoAlmacen));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoOperacion", SqlDbType.Char, 1, value.TipoOperacion));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@psecuencia", SqlDbType.Int, value.Secuencia));

            return arrPrm;

        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            throw new NotImplementedException();

        }
        #endregion

    }
}
