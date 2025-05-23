using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Bi;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;

namespace Laive.DOMnt.Bi
{
    public class CostosUnitarios : DataObjectBase, IDOUpdate
    {
        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            ECostosUnitarios objE = (ECostosUnitarios)value;

            //----------- Generacion de Codigos ------------------
      

            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("BI_Ds_Costo_SMV_mnt02", arrPrm);

                return new object[] { objE.Año };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("DS_Costo_SMV_mnt02", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Delete(IEntityBase value)
        {

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pAnio", SqlDbType.Int, objE.Año));
                arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Int, objE.Mes));


                int intRes = this.ExecuteNonQuery("BI_Ds_Costo_SMV_mnt01", arrPrm);

                return intRes;

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

            arrPrm.Add(DataHelper.CreateParameter("@pAnio", SqlDbType.Int, value.Año));
            arrPrm.Add(DataHelper.CreateParameter("@pMes", SqlDbType.Int, value.Mes));
            arrPrm.Add(DataHelper.CreateParameter("@pFecha", SqlDbType.DateTime, value.Fecha));
            arrPrm.Add(DataHelper.CreateParameter("@pCodigo_Articulo", SqlDbType.Char, 9, value.Codigo_Articulo));
            arrPrm.Add(DataHelper.CreateParameter("@pCosto_Unitario", SqlDbType.Float, value.Costo_Unitario));

            return arrPrm;

        }

        #endregion


    }
}
