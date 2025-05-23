using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using SamNet.Core.Data;
using SamNet.Entity.Mg;
using System.Collections.Generic;
using SamNet.Core.Common;

namespace SamNet.DOQry.Mg
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: MG_BienServicio (MG_BienServicio)
    /// </summary>
    /// <remarks></remarks>
    public class BienServicio : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value)
        {

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "MG_BienServicio_qry01", arrPrm);

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

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("MG_BienServicio_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EBienServicio>(dr, typeof(EBienServicio));

                return objE;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetByParentKey<T>(IEntityBase value)
        {

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "MG_BienServicio_qry03", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetList<T>(IEntityBase value)
        {

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "MG_BienServicio_qry04", arrPrm);

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

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "MG_BienServicio_qry06", arrPrm);

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

            EBienServicio objE = (EBienServicio)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("MG_BienServicio_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(EBienServicio value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidBien", SqlDbType.Char, 13, value.IdBien));

            return arrPrm;

        }

        #endregion

    }
}
