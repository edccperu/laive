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
using DIDOMnt = Laive.DOMnt.Di;

namespace Laive.DOMnt.Di
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: DI_CargaUnidadOperacion (DI_CargaUnidadOperacion)
    /// </summary>
    /// <remarks></remarks>
    public class CargaUnidadOperacion : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            ECargaUnidadOperacion objE = (ECargaUnidadOperacion)value;
            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt01", arrPrm);

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

            ECargaUnidadOperacion objE = (ECargaUnidadOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt02", arrPrm);

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

            ECargaUnidadOperacion objE = (ECargaUnidadOperacion)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
                arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt03", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(ECargaUnidadOperacion value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, value.IdCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, value.TipoCarga));
            arrPrm.Add(DataHelper.CreateParameter("@ppaleta", SqlDbType.Decimal, value.Paleta));
            arrPrm.Add(DataHelper.CreateParameter("@pempaque", SqlDbType.Decimal, value.Empaque));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidadPedido", SqlDbType.Decimal, value.CantidadPedido));
            arrPrm.Add(DataHelper.CreateParameter("@pkilosPedido", SqlDbType.Decimal, value.KilosPedido));
            arrPrm.Add(DataHelper.CreateParameter("@pimportePedido", SqlDbType.Decimal, value.ImportePedido));

            return arrPrm;

        }

        #endregion


        public int CargarCamion(ECargaUnidad value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, value.IdCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char,5, value.IdUserTkCarga));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt04", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int RetirarCamion(int idCargaUnidad)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt05", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int CerrarCamion(int idCargaUnidad)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt06", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int OpenCamion(int idCargaUnidad)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt09", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int RetirarCaXPartner(int idCargaUnidad,string codigoPartner)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char,9, codigoPartner));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt07", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int RetirarCaXFrio(int idCargaUnidad, string orden, int linea, int sublinea)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, sublinea));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt08", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int RetirarCaXFrioPorOrden(int idCargaUnidad, string orden)
        {

            ArrayList arrPrm = new ArrayList();
            arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, orden));

            try
            {
                int intRes = this.ExecuteNonQuery("DI_CargaUnidadOperacion_mnt10", arrPrm);

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
