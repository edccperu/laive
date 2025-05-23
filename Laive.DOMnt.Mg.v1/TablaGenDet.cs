using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Core.Common;
using Laive.Entity.Mg;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;

namespace Laive.DOMnt.Mg
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: MG_TablaGenDet (MG_TablaGenDet)
    /// </summary>
    /// <remarks></remarks>
    public class TablaGenDet : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            ETablaGenDet objE = (ETablaGenDet)value;
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("MG_TablaGenDet_mnt01", arrPrm);

                return new object[] { objE.IdTabla };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            ETablaGenDet objE = (ETablaGenDet)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("MG_TablaGenDet_mnt02", arrPrm);

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

            ETablaGenDet objE = (ETablaGenDet)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidTabla", SqlDbType.Char, 3, objE.IdTabla));
                arrPrm.Add(DataHelper.CreateParameter("@pidCodigo", SqlDbType.Char, 3, objE.IdCodigo));

                int intRes = this.ExecuteNonQuery("MG_TablaGenDet_mnt03", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(ETablaGenDet value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidTabla", SqlDbType.Char, 3, value.IdTabla));
            arrPrm.Add(DataHelper.CreateParameter("@pidCodigo", SqlDbType.Char, 3, value.IdCodigo));
            arrPrm.Add(DataHelper.CreateParameter("@pdsDescrip", SqlDbType.VarChar, 100, value.DsDescrip));
            arrPrm.Add(DataHelper.CreateParameter("@pdsAbrev", SqlDbType.VarChar, 20, value.DsAbrev));
            arrPrm.Add(DataHelper.CreateParameter("@pidCodAlter", SqlDbType.VarChar, 10, value.IdCodAlter));
            arrPrm.Add(DataHelper.CreateParameter("@pmtValor", SqlDbType.Decimal, value.MtValor));
            arrPrm.Add(DataHelper.CreateParameter("@pidUserTk", SqlDbType.Char, 5, value.IdUserTk));
            arrPrm.Add(DataHelper.CreateParameter("@pidPc", SqlDbType.VarChar, 20, value.IdPc));
            arrPrm.Add(DataHelper.CreateParameter("@pfeRegistro", SqlDbType.DateTime, value.FeRegistro));
            arrPrm.Add(DataHelper.CreateParameter("@pstAnulado", SqlDbType.Char, 1, value.StAnulado));

            return arrPrm;

        }

        #endregion

    }
}
