using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Bi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Bi
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: DS_Costo_SMV (DS_Costo_SMV)
    /// </summary>
    /// <remarks></remarks>
    public class CostosUnitarios : DataObjectBase, IDOQuery
    {
        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pAnio", SqlDbType.Int, objE.Año));
                arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Int, objE.Mes));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "BI_Ds_Costo_SMV_qry01", arrPrm);

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("DS_Costo_SMV_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<ECostosUnitarios>(dr, typeof(ECostosUnitarios));

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DS_Costo_SMV_qry03", arrPrm);

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DS_Costo_SMV_qry04", arrPrm);

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("DS_Costo_SMV_qry05", arrPrm);

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

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

        private ArrayList BuildParamInterface(ECostosUnitarios value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pAño", SqlDbType.Int, value.Año));
            arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Int, value.Mes));
            arrPrm.Add(DataHelper.CreateParameter("@pCodigo_Articulo", SqlDbType.Char, 9, value.Codigo_Articulo));

            return arrPrm;

        }

        #endregion


    }
}
