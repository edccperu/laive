using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using DIDORpt = Laive.DORpt.Di;

namespace Laive.BORpt.Di
{
    /// <summary>
    /// Business Object para Consultas a la Tabla: DI_CargaUnidad (DI_CargaUnidad)
    /// </summary>
    public class CargaUnidad : BusinessObjectBase
    {

        #region IBOQuery Members

        public DataTable GetRptConsolidado(string value)
        {

            DIDORpt.CargaUnidad objData = new DIDORpt.CargaUnidad();

            try
            {

                DataTable dt = objData.GetRptConsolidado(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }


        public DataTable GetRptDetalle(string value)
        {

            DIDORpt.CargaUnidad objData = new DIDORpt.CargaUnidad();

            try
            {

                DataTable dt = objData.GetRptDetalle(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }


        public DataTable GetRptPackingListConsolidado(string value)
        {

           DIDORpt.CargaUnidad objData = new DIDORpt.CargaUnidad();

           try
           {

              DataTable dt = objData.GetRptPackingListConsolidado(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }

        public DataTable GetRptPackingListDetallado(string value)
        {

           DIDORpt.CargaUnidad objData = new DIDORpt.CargaUnidad();

           try
           {

              DataTable dt = objData.GetRptPackingListDetallado(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }

        #endregion

    }
}
