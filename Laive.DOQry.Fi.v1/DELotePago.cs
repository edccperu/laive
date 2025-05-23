using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Fi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Fi
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: FI_DELotePago (FI_DELotePago)
    /// </summary>
    /// <remarks></remarks>
    public class DELotePago : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, objE.EjercicioLote));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DELotePago_qry02", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public IEntityBase GetByKey(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry02", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EDELotePago>(dr, typeof(EDELotePago));

                return objE;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DELotePago_qry03", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DELotePago_qry04", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }


        public ICollection<T> GetLotePagoPartnerCuentaBan<T>(IEntityBase value) where T : new()
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLotePago", SqlDbType.Int, objE.IdLoteDetraccion));


                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DELotePago_qry14", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetDetraccionPagadosPartner<T>(IEntityBase value) where T : new()
        {

            EDetraccionPagadosPartner objE = (EDetraccionPagadosPartner)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pmesPagoIni", SqlDbType.Int, objE.mesPagoIni));
                arrPrm.Add(DataHelper.CreateParameter("@pmesPagoFin", SqlDbType.Int, objE.mesPagoFin));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartnerPagador", SqlDbType.VarChar,9, objE.codigoPartnerPagador));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DELotePago_qry12", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public ICollection<T> GetDetraccionComprobantesProveedor<T>(IEntityBase value) where T : new()
        {

            EDetraccionPagadosPartner objE = (EDetraccionPagadosPartner)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@ejercicio", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@periodo", SqlDbType.Int, objE.PeriodoLote));
      

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_DEComprobanteProveedor_qry01", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool ExistsCuentaCaja(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@ptraBaanBco", SqlDbType.Char, 3, objE.TraBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@pnroBaanBco", SqlDbType.Int, objE.NroBaanBco));

                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry07", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool ExistsCuentaIgv(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@ptraBaanBco", SqlDbType.Char, 3, objE.TraBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@pnroBaanBco", SqlDbType.Int, objE.NroBaanBco));

                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry08", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool ExistsTrabaan(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;

            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidLoteDetraccion", SqlDbType.Int, objE.IdLoteDetraccion));
                arrPrm.Add(DataHelper.CreateParameter("@ptraBaanBco", SqlDbType.Char,3, objE.TraBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@pnroBaanBco", SqlDbType.Int, objE.NroBaanBco));
                arrPrm.Add(DataHelper.CreateParameter("@ploteContable", SqlDbType.Int, objE.LoteContable));
                arrPrm.Add(DataHelper.CreateParameter("@pnroFinalizacion", SqlDbType.Int, objE.NroFinalizacion));

                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry05", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool Exists(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteIni", SqlDbType.Int, objE.NumeroLoteIni));
                arrPrm.Add(DataHelper.CreateParameter("@pejercicio", SqlDbType.Int, objE.EjercicioLote));

                //arrPrm.Add(DataHelper.CreateParameter("@pNumeroLoteFin", SqlDbType.Int, objE.NumeroLoteFin));

                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry03", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;
                    
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool ExistsIdLotePago(IEntityBase value)
        {
            EDELotePago objE = (EDELotePago)value;

            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pnumeroLote", SqlDbType.Int, objE.NumeroLoteIni));

   
                int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

                SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry06", arrPrm);

                return objPrm[intIdx].Value.ToString() == "1" ? true : false;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

     

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_DELotePago_qry05", arrPrm);

                return dt;

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

            return arrPrm;

        }

        #endregion


        public IEntityBase GetByEjercicioLote(IEntityBase value)
        {

            EDELotePago objE = (EDELotePago)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pejercicioLote", SqlDbType.Int, objE.EjercicioLote));
                arrPrm.Add(DataHelper.CreateParameter("@pnumeroLote", SqlDbType.Int, objE.NumeroLote));

                DataTable dt = this.ExecuteDatatable("FI_DELotePago_qry10", arrPrm);

                objE = null;

                foreach (DataRow dr in dt.Rows)
                    objE = DataHelper.CopyDataRowToEntity<EDELotePago>(dr, typeof(EDELotePago));

                return objE;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

    }

}
