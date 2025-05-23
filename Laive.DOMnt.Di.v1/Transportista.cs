using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;

namespace Laive.DOMnt.Di
{
    public class Transportista : DataObjectBase, IDOUpdate
    {

        public object[] Insert(IEntityBase value)
        {
            ETransportista objE = (ETransportista)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@presult", SqlDbType.Int, objE.Ruc));
                int intRes = this.ExecuteNonQuery("DI_Transportista_mnt01", arrPrm);
                return new object[] { objE.IdTransportista };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;
            }
        }

        public int Update(IEntityBase value) 
        {
            ETransportista objE = (ETransportista)value;
            try 
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@presult", SqlDbType.Int, 1));
                int intRes = this.ExecuteNonQuery("DI_Transportista_mnt01", arrPrm);
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
            ETransportista objE = (ETransportista)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@presult", SqlDbType.Int, objE.Ruc));
                int intRes = this.ExecuteNonQuery("DI_Transportista_mnt01", arrPrm);
                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }
    }
}
