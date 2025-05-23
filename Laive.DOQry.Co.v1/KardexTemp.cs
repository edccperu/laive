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
    /// Data Object para Consultas a la Tabla: CO_KardexTemp (CO_KardexTemp)
    /// </summary>
    /// <remarks></remarks>
    public class KardexTemp : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pAnio", SqlDbType.Char,4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcCodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));


                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexTemp_qry01", arrPrm);

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

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("CO_KardexTemp_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EKardexAuto>(dr, typeof(EKardexAuto));

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

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexTemp_qry03", arrPrm);

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

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_KardexTemp_qry04", arrPrm);

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

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("CO_KardexTemp_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(EKardexAuto value)
        {

            ArrayList arrPrm = new ArrayList();


            return arrPrm;

        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            throw new NotImplementedException();

        }
        #endregion
       
        public ICollection<T> ImportarKardex<T>(IEntityBase value) where T : new()
        {

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@piAnio", SqlDbType.Char, 4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@piMes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcCodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_ImportarKardex_ope01", arrPrm,3000);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> ImportarKardexDCA<T>(IEntityBase value) where T : new()
        {

           EKardexAuto objE = (EKardexAuto)value;

           try
           {

              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@piAño", SqlDbType.Char, 4, objE.Periodo));
              arrPrm.Add(DataHelper.CreateParameter("@piMes", SqlDbType.Char, 2, objE.Mes));
              arrPrm.Add(DataHelper.CreateParameter("@pcCodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "CO_ImportarKardex_ope02", arrPrm, 3000);

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
