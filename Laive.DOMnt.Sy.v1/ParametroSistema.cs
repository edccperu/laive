using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Sy;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;

namespace Laive.DOMnt.Sy
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: SY_ParametroSistema (SY_ParametroSistema)
    /// </summary>
    /// <remarks></remarks>
    public class ParametroSistema : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            EParametroSistema objE = (EParametroSistema)value;

            //----------- Generacion de Codigos ------------------
            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("SY_ParametroSistema_mnt01", arrPrm);

                return new object[] { objE.IdParametroSistema };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            EParametroSistema objE = (EParametroSistema)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("SY_ParametroSistema_mnt02", arrPrm);

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

            EParametroSistema objE = (EParametroSistema)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidParametroSistema", SqlDbType.Int, objE.IdParametroSistema));

                int intRes = this.ExecuteNonQuery("SY_ParametroSistema_mnt03", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(EParametroSistema value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidParametroSistema", SqlDbType.Int, value.IdParametroSistema));
            arrPrm.Add(DataHelper.CreateParameter("@pdsNombre", SqlDbType.VarChar, 100, value.DsNombre));
            arrPrm.Add(DataHelper.CreateParameter("@pdsModulo", SqlDbType.Char, 2, value.DsModulo));
            arrPrm.Add(DataHelper.CreateParameter("@pdsDescripcion", SqlDbType.VarChar, 250, value.DsDescripcion));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoValor", SqlDbType.Char, 1, value.TipoValor));
            arrPrm.Add(DataHelper.CreateParameter("@pnuValorNumerico", SqlDbType.Decimal, (value.NuValorNumerico.HasValue ? (object)value.NuValorNumerico : DBNull.Value)));
            arrPrm.Add(DataHelper.CreateParameter("@pnuValorFecha", SqlDbType.DateTime, (value.NuValorFecha.HasValue ? (object)value.NuValorFecha : DBNull.Value)));
            arrPrm.Add(DataHelper.CreateParameter("@pnuValorCadena", SqlDbType.VarChar, 500, value.NuValorCadena));
            arrPrm.Add(DataHelper.CreateParameter("@panulado", SqlDbType.Char, 1, value.Anulado));

            return arrPrm;

        }

        #endregion

    }
}
