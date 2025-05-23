using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Mg;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Mg
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: MG_TablaGen (MG_TablaGen)
    /// </summary>
    /// <remarks></remarks>
    public class TablaGen : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pFilter", SqlDbType.VarChar,-1, objE.EntityFilter));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T),"MG_TablaGen_qry01", arrPrm);

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("MG_TablaGen_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<ETablaGen>(dr, typeof(ETablaGen));

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T),"MG_TablaGen_qry03", arrPrm);

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T),"MG_TablaGen_qry04", arrPrm);

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "MG_TablaGen_qry06", arrPrm);

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("MG_TablaGen_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(ETablaGen value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidTabla", SqlDbType.Char, 3, value.IdTabla));

            return arrPrm;

        }

        #endregion

    }
}
