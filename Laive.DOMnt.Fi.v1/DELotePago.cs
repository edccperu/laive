using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Fi;

namespace Laive.DOMnt.Fi
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: FI_DELotePago (FI_DELotePago)
    /// </summary>
    /// <remarks></remarks>
    public class DELotePago : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;


            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt01", arrPrm);

                return new object[] { objE.IdLoteDetraccion };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateComprobanteProveedor(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pEjercicio", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pPeriodo", SqlDbType.Int, objE.PeriodoLote));
                    
                int intRes = this.ExecuteNonQuery("FI_DEComprobanteProveedor_mnt01", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public int Update(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pEjercicio", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteIni", SqlDbType.Int, objE.NumeroLoteIni));
                arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteFin", SqlDbType.Int, objE.NumeroLoteFin));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt01", arrPrm);

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

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt13", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateTraBaanLotPago(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@piEjercicioLote", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@ptraBaanBco", SqlDbType.Char,3, objE.TraBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@pnroBaanBco", SqlDbType.Int, objE.NroBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@ploteContable", SqlDbType.Int, objE.LoteContable));
                arrPrm.Add(DataHelper.CreateParameter("@pnroFinalizacion", SqlDbType.Int, objE.NroFinalizacion));
                arrPrm.Add(DataHelper.CreateParameter("@parchivoDeposito", SqlDbType.VarChar,20, objE.ArchivoDeposito));
                arrPrm.Add(DataHelper.CreateParameter("@pestadoLote", SqlDbType.VarChar, 20, objE.EstadoLote));
                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt02", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateLotePago(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pnumeroLote", SqlDbType.Int, objE.NumeroLote));
                arrPrm.Add(DataHelper.CreateParameter("@pnumeroOperacion", SqlDbType.VarChar,20, objE.OperacionDeposito));
                arrPrm.Add(DataHelper.CreateParameter("@pconstanciaSunat", SqlDbType.VarChar, 20, objE.ConstanciaSunat));
                arrPrm.Add(DataHelper.CreateParameter("@parchivoDeposito", SqlDbType.VarChar, 100, objE.ArchivoDeposito));
                arrPrm.Add(DataHelper.CreateParameter("@parchivoSunat", SqlDbType.VarChar, 100, objE.ArchivoSunat));
                arrPrm.Add(DataHelper.CreateParameter("@pfechaConstancia", SqlDbType.VarChar, 30, objE.FechaConstancia));
                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt12", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public int UpdateImportarLotePago(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pEjercicio", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteIni", SqlDbType.Int, objE.NumeroLoteIni));
                //arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteFin", SqlDbType.Int, objE.NumeroLoteFin));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt01", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateGenerarPagoSunat(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@pestadoLote", SqlDbType.Char,1, objE.EstadoLote));
                arrPrm.Add(DataHelper.CreateParameter("@parchivoDeposito", SqlDbType.VarChar,100, objE.ArchivoDeposito));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt04", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public int UpdateConcilacionPago(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;

            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@pestadoLote", SqlDbType.Char,1, objE.EstadoLote));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt10", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int UpdateConcilacionPagoComprobante(IEntityBase value)
        {
            EDEPagoComprobanteConcilia objE = (EDEPagoComprobanteConcilia)value;

            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidPagCom", SqlDbType.Int, objE.IdPagCom));
                arrPrm.Add(DataHelper.CreateParameter("@pconciliado", SqlDbType.Char, 1, objE.Conciliado));
                arrPrm.Add(DataHelper.CreateParameter("@pconstanciasunat", SqlDbType.VarChar, 20, objE.ConstanciaSunat));
                arrPrm.Add(DataHelper.CreateParameter("@pperiodoTributaro", SqlDbType.VarChar, 6, objE.PeriodoTributario));

                int intRes = this.ExecuteNonQuery("FI_DELotePago_mnt11", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }


        private ArrayList BuildParamInterface(EDELotePago value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, value.IdLoteDetraccion));
            arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, value.EjercicioLote));
            arrPrm.Add(DataHelper.CreateParameter("@pnumeroLote", SqlDbType.Int, value.NumeroLote));
            //arrPrm.Add(DataHelper.CreateParameter("@ptraBaanBco", SqlDbType.Char, 3, (value.TraBaanBco != null ? value.TraBaanBco : DBNull.Value)));
            //arrPrm.Add(DataHelper.CreateParameter("@pnroBaanBco", SqlDbType.Int, (value.NroBaanBco.HasValue ? (object)value.NroBaanBco : DBNull.Value)));
            //arrPrm.Add(DataHelper.CreateParameter("@ploteContable", SqlDbType.Int, (value.LoteContable.HasValue ? (object)value.LoteContable : DBNull.Value)));
            //arrPrm.Add(DataHelper.CreateParameter("@pnroFinalizacion", SqlDbType.Int, (value.NroFinalizacion.HasValue ? (object)value.NroFinalizacion : DBNull.Value)));
            arrPrm.Add(DataHelper.CreateParameter("@pimporteLote", SqlDbType.Decimal, value.ImporteLote));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaLote", SqlDbType.DateTime, value.FechaLote));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaDeposito", SqlDbType.DateTime, value.FechaDeposito));
            arrPrm.Add(DataHelper.CreateParameter("@ppagoQuintoDia", SqlDbType.Char, 1, value.PagoQuintoDia));
            //arrPrm.Add(DataHelper.CreateParameter("@pformaPago", SqlDbType.Char, 1, (value.FormaPago != null ? value.FormaPago : DBNull.Value)));
            arrPrm.Add(DataHelper.CreateParameter("@pconstanciaSunat", SqlDbType.VarChar, 20, value.ConstanciaSunat));

            return arrPrm;

        }

        #endregion

    }

}
