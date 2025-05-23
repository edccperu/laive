using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;

namespace Laive.DORpt.Di
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: DI_CargaUnidad (DI_CargaUnidad)
    /// </summary>
    /// <remarks></remarks>
    public class CargaUnidad : DataObjectBase
    {

        #region IDOQuery Members

        public DataTable GetRptConsolidado(string value)
        {
            
            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.VarChar, -1, value));

                DataTable dt = this.ExecuteDatatable("DI_CargaUnidad_rpt01", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public DataTable GetRptDetalle(string value)
        {

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.VarChar, -1, value));

                DataTable dt = this.ExecuteDatatable("DI_CargaUnidad_rpt02", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public DataTable GetRptPackingListConsolidado(string value)
        {

           try
           {

              ArrayList arrPrm = new ArrayList();

              arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.VarChar, -1, value));

              DataTable dt = this.ExecuteDatatable("DI_CargaUnidad_rpt03", arrPrm);

              return dt;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public DataTable GetRptPackingListDetallado(string value)
        {

           try
           {

              ArrayList arrPrm = new ArrayList();

              arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.VarChar, -1, value));

              DataTable dt = this.ExecuteDatatable("DI_CargaUnidad_rpt04", arrPrm);

              return dt;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        private ArrayList BuildParamInterface(ECargaUnidad value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, value.IdCargaUnidad));

            return arrPrm;

        }

        #endregion

    }
}
