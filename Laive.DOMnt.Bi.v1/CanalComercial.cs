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
    public class CanalComercial: DataObjectBase,IDOUpdate
    {
        public object[] Insert(IEntityBase value)
        {
            ECanalComercial objE = (ECanalComercial)value;
            //----------- Generacion de Codigos ------------------
            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
         {
             int intRes = this.ExecuteNonQuery("BI_CanalComercial_mn01", arrPrm);

            return new object[] { objE.IdCanalModerno };

         }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {
            ECanalComercial objE = (ECanalComercial)value;

            try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("BI_CanalComercial_mn02", arrPrm);

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

            ECanalComercial objE = (ECanalComercial)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@idCanalModerno", SqlDbType.Int, objE.IdCanalModerno));

                int intRes = this.ExecuteNonQuery("BI_CanalComercial_mn02", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(ECanalComercial value)
        {
            ArrayList arrPrm = new ArrayList();
            arrPrm.Add(DataHelper.CreateParameter("@id", SqlDbType.Int, value.Id));
            arrPrm.Add(DataHelper.CreateParameter("@idCanalModerno", SqlDbType.Int, value.IdCanalModerno));
            arrPrm.Add(DataHelper.CreateParameter("@codigoPartner", SqlDbType.Char, 9, value.CodigoPartner));

            return arrPrm;
        }
    }
}
