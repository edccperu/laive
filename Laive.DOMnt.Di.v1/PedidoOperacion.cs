using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;

namespace Laive.DOMnt.Di
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: DI_PedidoOperacion (DI_PedidoOperacion)
    /// </summary>
    /// <remarks></remarks>
    public class PedidoOperacion : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            EPedidoOperacion objE = (EPedidoOperacion)value;
            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt01", arrPrm);

                return new object[] { objE.IdRuta };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt02", arrPrm);

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

            EPedidoOperacion objE = (EPedidoOperacion)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
                arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

                int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt03", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(EPedidoOperacion value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, value.TipoCarga));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@ppaleta", SqlDbType.Decimal, value.Paleta));
            arrPrm.Add(DataHelper.CreateParameter("@pempaque", SqlDbType.Decimal, value.Empaque));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidadPedido", SqlDbType.Decimal, value.CantidadPedido));
            arrPrm.Add(DataHelper.CreateParameter("@pkilosPedido", SqlDbType.Decimal, value.KilosPedido));
            arrPrm.Add(DataHelper.CreateParameter("@pimportePedido", SqlDbType.Decimal, value.ImportePedido));
            arrPrm.Add(DataHelper.CreateParameter("@pstpo", SqlDbType.Bit, value.Stpo));
            arrPrm.Add(DataHelper.CreateParameter("@pstEstado", SqlDbType.Char, 3, value.StEstado));

            return arrPrm;

        }

        #endregion

        public int UpdateStpo(EPedidoOperacion objE)
        {
            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
                arrPrm.Add(DataHelper.CreateParameter("@pstpo", SqlDbType.Bit, objE.Stpo));
                arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char, 5, objE.IdUserTkCarga));

                int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt04", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateStpoApertura(EPedidoOperacion objE)
        {
           try
           {

              ArrayList arrPrm = new ArrayList();


              arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
              arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
              arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
              arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
              arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));
              arrPrm.Add(DataHelper.CreateParameter("@pstpo", SqlDbType.Bit, objE.Stpo));
              arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char, 5, objE.IdUserTkCarga));

              int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt07", arrPrm);

              return intRes;

           }
           catch (Exception ex)
           {

              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;

           }

        }


        public int ImportarBaanOpe01(EAlmacen objE)
        {
            try
            {

                ArrayList arrPrm = new ArrayList();

                int intRes = this.ExecuteNonQueryTimeOut("DI_ImportarBaan_ope01", arrPrm,1800);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int ImportarBaanOpe02(EAlmacen objE)
        {
            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pCodigoAlmacen", SqlDbType.Char, 6, objE.CodigoAlmacen));
                arrPrm.Add(DataHelper.CreateParameter("@pCodigoAlmacenSerie", SqlDbType.Char, 3, objE.CodigoAlmacenSerie));
                arrPrm.Add(DataHelper.CreateParameter("@pIdOrdenDesde", SqlDbType.Char, 9, objE.IdOrdenDesde));
                arrPrm.Add(DataHelper.CreateParameter("@pIdOrdenHasta", SqlDbType.Char, 9, objE.IdOrdenHasta));
                arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));

                int intRes = this.ExecuteNonQueryTimeOut("DI_ImportarBaan_ope02", arrPrm,1800);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int DLUpdateEstado(EPedidoOperacion objE)
        {
            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
                arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

                int intRes = this.ExecuteNonQueryTimeOut("DI_PedidoOperacion_mnt05", arrPrm, 1800);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }


        public int DLCreateSubLinea(EPedidoOperacion objE)
        {
            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
                arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));
                arrPrm.Add(DataHelper.CreateParameter("@pcantidadPedido", SqlDbType.Decimal, objE.CantidadPedido));
                arrPrm.Add(DataHelper.CreateParameter("@pkilosPedido", SqlDbType.Decimal, objE.KilosPedido));
                arrPrm.Add(DataHelper.CreateParameter("@pimportePedido", SqlDbType.Decimal, objE.ImportePedido));

                int intRes = this.ExecuteNonQueryTimeOut("DI_PedidoOperacion_mnt06", arrPrm, 1800);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }


        public int RetirarPedidoConsolidado(EOrdenVenta objE)
        {
           try
           {

              ArrayList arrPrm = new ArrayList();


              arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
              arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
              arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));

              int intRes = this.ExecuteNonQuery("DI_PedidoOperacion_mnt08", arrPrm);

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
