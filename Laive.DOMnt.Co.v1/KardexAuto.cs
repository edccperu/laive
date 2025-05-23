using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Co;

namespace Laive.DOMnt.Co
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: CO_KardexAuto (CO_KardexAuto)
    /// </summary>
    /// <remarks></remarks>
    public class KardexAuto : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            EKardexAuto objE = (EKardexAuto)value;

            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("CO_KardexAuto_mnt01", arrPrm);

                return new object[] { objE.Periodo };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
                arrPrm.Add(DataHelper.CreateParameter("@pfechaTransaccion", SqlDbType.DateTime, objE.FechaTransaccion));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 3, objE.CodigoAlmacen));
                arrPrm.Add(DataHelper.CreateParameter("@ptipoOperacion", SqlDbType.Char, 1, objE.TipoOperacion));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@psecuencia", SqlDbType.Int, objE.Secuencia));
                arrPrm.Add(DataHelper.CreateParameter("@pmauc_OK", SqlDbType.Decimal, objE.Mauc_OK));
                arrPrm.Add(DataHelper.CreateParameter("@pcantidad_OK", SqlDbType.Decimal, objE.Cantidad_OK));
                arrPrm.Add(DataHelper.CreateParameter("@punitario_OK", SqlDbType.Decimal, objE.Unitario_OK));
                arrPrm.Add(DataHelper.CreateParameter("@pcosto_OK", SqlDbType.Decimal, objE.Costo_OK));
                arrPrm.Add(DataHelper.CreateParameter("@pcantidadSaldo_OK", SqlDbType.Decimal, objE.CantidadSaldo_OK));
                arrPrm.Add(DataHelper.CreateParameter("@pcostoSaldo_OK", SqlDbType.Decimal, objE.CostoSaldo_OK));
                arrPrm.Add(DataHelper.CreateParameter("@pstate", SqlDbType.Char, 1, objE.State));

                int intRes = this.ExecuteNonQuery("CO_KardexAuto_mnt02", arrPrm);

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

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
                arrPrm.Add(DataHelper.CreateParameter("@pfechaTransaccion", SqlDbType.DateTime, objE.FechaTransaccion));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 3, objE.CodigoAlmacen));
                arrPrm.Add(DataHelper.CreateParameter("@ptipoOperacion", SqlDbType.Char, 1, objE.TipoOperacion));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@psecuencia", SqlDbType.Int, objE.Secuencia));

                int intRes = this.ExecuteNonQuery("CO_KardexAuto_mnt03", arrPrm);

                return intRes;

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

            arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, value.Periodo));
            arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, value.Mes));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaTransaccion", SqlDbType.DateTime, value.FechaTransaccion));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 3, value.CodigoAlmacen));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoOperacion", SqlDbType.Char, 1, value.TipoOperacion));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@psecuencia", SqlDbType.Int, value.Secuencia));
            arrPrm.Add(DataHelper.CreateParameter("@pposicion", SqlDbType.Int, value.Posicion));
            arrPrm.Add(DataHelper.CreateParameter("@pmauc", SqlDbType.Decimal, value.Mauc));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidad", SqlDbType.Decimal, value.Cantidad));
            arrPrm.Add(DataHelper.CreateParameter("@punitario", SqlDbType.Decimal, value.Unitario));
            arrPrm.Add(DataHelper.CreateParameter("@pcosto", SqlDbType.Decimal, value.Costo));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidadSaldo", SqlDbType.Decimal, value.CantidadSaldo));
            arrPrm.Add(DataHelper.CreateParameter("@pcostoSaldo", SqlDbType.Decimal, value.CostoSaldo));
            arrPrm.Add(DataHelper.CreateParameter("@pmauc_OK", SqlDbType.Decimal, value.Mauc_OK));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidad_OK", SqlDbType.Decimal, value.Cantidad_OK));
            arrPrm.Add(DataHelper.CreateParameter("@punitario_OK", SqlDbType.Decimal, value.Unitario_OK));
            arrPrm.Add(DataHelper.CreateParameter("@pcosto_OK", SqlDbType.Decimal, value.Costo_OK));
            arrPrm.Add(DataHelper.CreateParameter("@pcantidadSaldo_OK", SqlDbType.Decimal, value.CantidadSaldo_OK));
            arrPrm.Add(DataHelper.CreateParameter("@pcostoSaldo_OK", SqlDbType.Decimal, value.CostoSaldo_OK));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoMovimiento", SqlDbType.SmallInt, value.CodigoMovimiento));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoTransaccion", SqlDbType.SmallInt, value.CodigoTransaccion));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFamilia", SqlDbType.Char, 6, value.CodigoFamilia));
            arrPrm.Add(DataHelper.CreateParameter("@pstate", SqlDbType.Char, 1, value.State));

            return arrPrm;

        }

        public int UpdateValues(IEntityBase value)
        {

            EKardexAuto objE = (EKardexAuto)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pperiodo", SqlDbType.Char, 4, objE.Periodo));
                arrPrm.Add(DataHelper.CreateParameter("@pmes", SqlDbType.Char, 2, objE.Mes));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, objE.CodigoArticulo));
                arrPrm.Add(DataHelper.CreateParameter("@pfechaTransaccion", SqlDbType.DateTime, objE.FechaTransaccion));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 3, objE.CodigoAlmacen));
                arrPrm.Add(DataHelper.CreateParameter("@ptipoOperacion", SqlDbType.Char, 1, objE.TipoOperacion));
                arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
                arrPrm.Add(DataHelper.CreateParameter("@psecuencia", SqlDbType.Int, objE.Secuencia));
                arrPrm.Add(DataHelper.CreateParameter("@pmauc", SqlDbType.Decimal, objE.Mauc));
                arrPrm.Add(DataHelper.CreateParameter("@pcantidad", SqlDbType.Decimal, objE.Cantidad));
                arrPrm.Add(DataHelper.CreateParameter("@punitario", SqlDbType.Decimal, objE.Unitario));
                arrPrm.Add(DataHelper.CreateParameter("@pcosto", SqlDbType.Decimal, objE.Costo));
                arrPrm.Add(DataHelper.CreateParameter("@pcantidadSaldo", SqlDbType.Decimal, objE.CantidadSaldo));
                arrPrm.Add(DataHelper.CreateParameter("@pcostoSaldo", SqlDbType.Decimal, objE.CostoSaldo));

                int intRes = this.ExecuteNonQuery("CO_KardexAuto_mnt04", arrPrm);

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
