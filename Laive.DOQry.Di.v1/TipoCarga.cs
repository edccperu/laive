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
    /// Data Object para Consultas a la Tabla: DI_TipoCarga (DI_TipoCarga)
    /// </summary>
    /// <remarks></remarks>
    public class TipoCarga : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            ETipoCarga objE = (ETipoCarga)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.TipoCarga));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_TipoCarga_qry01", arrPrm);

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

            ETipoCarga objE = (ETipoCarga)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("DI_TipoCarga_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<ETipoCarga>(dr, typeof(ETipoCarga));

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

            ETipoCarga objE = (ETipoCarga)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_TipoCarga_qry03", arrPrm);

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

            ETipoCarga objE = (ETipoCarga)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_TipoCarga_qry04", arrPrm);

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

            ETipoCarga objE = (ETipoCarga)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("DI_TipoCarga_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(ETipoCarga value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, value.TipoCarga));

            return arrPrm;

        }
        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            throw new NotImplementedException();

        }
        #endregion

    }
}
