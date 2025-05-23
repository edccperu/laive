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
using System.Collections.Generic;

namespace Laive.DOMnt.Di
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: DI_CargaUnidad (DI_CargaUnidad)
    /// </summary>
    /// <remarks></remarks>
    public class CargaUnidad : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            ECargaUnidad objE = (ECargaUnidad)value;
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt01", arrPrm);

                return new object[] { objE.IdCargaUnidad };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            ECargaUnidad objE = (ECargaUnidad)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt02", arrPrm);

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

            ECargaUnidad objE = (ECargaUnidad)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));

                int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt03", arrPrm);

                return intRes;

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
            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, value.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@pestado", SqlDbType.Char, 1, value.Estado));
            arrPrm.Add(DataHelper.CreateParameter("@pidTransportista", SqlDbType.Int, value.IdTransportista));
            arrPrm.Add(DataHelper.CreateParameter("@pidUnidad", SqlDbType.Int, value.IdUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@pidTurno_Seco", SqlDbType.Int, value.IdTurno_Seco));
            arrPrm.Add(DataHelper.CreateParameter("@pidTurno_Frio", SqlDbType.Int, value.IdTurno_Frio));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@pidBox_Seco", SqlDbType.Int, value.IdBox_Seco));
            arrPrm.Add(DataHelper.CreateParameter("@pidBox_Frio", SqlDbType.Int, value.IdBox_Frio));
            arrPrm.Add(DataHelper.CreateParameter("@pkilosAsignados", SqlDbType.Decimal, value.KilosAsignados));
            arrPrm.Add(DataHelper.CreateParameter("@pporUnidad", SqlDbType.Decimal, value.PorUnidad));

            return arrPrm;

        }

        public int UpdateAddCamion(string idTrans, string idUnidad, DateTime fechaPrograma, int idRuta,decimal mtFrio,decimal mtSeco)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidTrans", SqlDbType.VarChar, -1, idTrans));
            arrPrm.Add(DataHelper.CreateParameter("@pidUnidad", SqlDbType.VarChar, -1, idUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, fechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, idRuta));
            arrPrm.Add(DataHelper.CreateParameter("@pmtFrio", SqlDbType.Decimal, mtFrio));
            arrPrm.Add(DataHelper.CreateParameter("@pmtSeco", SqlDbType.Decimal, mtSeco));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt04", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public int UpdateTurnoBox(IEntityBase value)
        {
            ECargaUnidad objE = (ECargaUnidad)value;

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@pidTurno_Seco", SqlDbType.Int, objE.IdTurno_Seco));
            arrPrm.Add(DataHelper.CreateParameter("@pidTurno_Frio", SqlDbType.Int, objE.IdTurno_Frio));
            arrPrm.Add(DataHelper.CreateParameter("@pidBox_Seco", SqlDbType.Int, objE.IdBox_Seco));
            arrPrm.Add(DataHelper.CreateParameter("@pidBox_Frio", SqlDbType.Int, objE.IdBox_Frio));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt05", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public int UpdateFactura(IEntityBase value)
        {
            ECargaUnidad objE = (ECargaUnidad)value;

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));

            try
            {
                int intRes = this.ExecuteNonQueryTimeOut("DI_ImportarBaan_ope03", arrPrm,14800);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }


        public ICollection<EDatosXml> GenerateXML(DateTime value) 
        {
           try
           {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.Date, value));
              ICollection<EDatosXml> dt = this.ExecuteGetList<EDatosXml>(typeof(EDatosXml), "DI_GenerarDatosXml", arrPrm);
              return dt;

           }
           catch (Exception ex)
           {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public ICollection<T> ReGenerateXML<T>(DateTime fecha,int correlativo) where T : new()
        {

           try
           {

              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.Date, fecha));
              arrPrm.Add(DataHelper.CreateParameter("@pcorrelativoFile", SqlDbType.Int, correlativo));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_ReGenerarDatosXml", arrPrm);

              return dt;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public int CambiarPartnerToCamion(int idCargaUnidad, string idPartner, int newIdCargaUnidad)
        {

           ArrayList arrPrm = new ArrayList();

           arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
           arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, idPartner));
           arrPrm.Add(DataHelper.CreateParameter("@pnewIdCargaUnidad", SqlDbType.Int, newIdCargaUnidad));

           try
           {
              int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt06", arrPrm);

              return intRes;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public int CambiarCamion(int idCargaUnidad, int newIdCargaUnidad)
        {

           ArrayList arrPrm = new ArrayList();

           arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
           arrPrm.Add(DataHelper.CreateParameter("@pnewIdCargaUnidad", SqlDbType.Int, newIdCargaUnidad));

           try
           {
              int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt07", arrPrm);

              return intRes;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }

        public int ExpedirCamion(string idCargaUnidad)
        {

           ArrayList arrPrm = new ArrayList();

           arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.VarChar,-1, idCargaUnidad));

           try
           {
              int intRes = this.ExecuteNonQuery("DI_CargaUnidad_mnt08", arrPrm);

              return intRes;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }
        }


        #endregion

    }
}
