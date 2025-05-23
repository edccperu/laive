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
    public class ChequeResumen : DataObjectBase, IDOQuery
    {
        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            ECheque objE = (ECheque)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry01", arrPrm);

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

            ECheque objE = (ECheque)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("FI_Cheque_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<ECheque>(dr, typeof(ECheque));

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

            ECheque objE = (ECheque)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry03", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }
        //Carga la lista de registros
        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {

            ECheque objE = (ECheque)value;

            try
            {

                //ArrayList arrPrm = BuildParamInterface(objE);

                //ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry04", arrPrm);
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, objE.Login));
                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_Cheque_qry13", arrPrm);
               

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

            ECheque objE = (ECheque)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_Cheque_qry06", arrPrm);

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

            ECheque objE = (ECheque)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_Cheque_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }
      
       

        private ArrayList BuildParamInterface(ECheque value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCheque", SqlDbType.Int, value.IdCheque));

            return arrPrm;

        }
        #endregion
    }
}
