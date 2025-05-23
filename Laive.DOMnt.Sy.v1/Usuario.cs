using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Core.Common;
using Laive.Entity.Sy;

namespace Laive.DOMnt.Sy
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: SY_Usuario (SY_Usuario)
    /// </summary>
    /// <remarks></remarks>
    public class Usuario : DataObjectBase, IDOUpdate
    {

        #region IDOUpdate Members

        public object[] Insert(IEntityBase value)
        {

            EUsuario objE = (EUsuario)value;

            //----------- Generacion de Codigos ------------------
            TablaCorre objDO = new TablaCorre();
            ETablaCorre objECorre = new ETablaCorre();

            objECorre.IdPeriodo = ConstDefaultValue.PERIODO;
            objECorre.IdUnidadEjec = ConstDefaultValue.UNIDAD_EJECUTORA;
            objECorre.IdSede = ConstDefaultValue.SEDE;
            objECorre.IdTabla = "SY_Usuario";

            string strNewCode = objDO.GenNewCode(objECorre);
            objE.IdUser = "U" + strNewCode;

            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);

            try
            {
                int intRes = this.ExecuteNonQuery("SY_Usuario_mnt01", arrPrm);

                return new object[] { objE.IdUser };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        public int Update(IEntityBase value)
        {

            EUsuario objE = (EUsuario)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                int intRes = this.ExecuteNonQuery("SY_Usuario_mnt02", arrPrm);

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

            EUsuario objE = (EUsuario)value;

            try
            {

                ArrayList arrPrm = new ArrayList();


                arrPrm.Add(DataHelper.CreateParameter("@pidUser", SqlDbType.Char, 5, objE.IdUser));

                int intRes = this.ExecuteNonQuery("SY_Usuario_mnt03", arrPrm);

                return intRes;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

        private ArrayList BuildParamInterface(EUsuario value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidUser", SqlDbType.Char, 5, value.IdUser));
            arrPrm.Add(DataHelper.CreateParameter("@pidLogon", SqlDbType.VarChar, 30, value.IdLogon));
            arrPrm.Add(DataHelper.CreateParameter("@pidPassword", SqlDbType.VarChar, 16, (value.IdPassword != null ? value.IdPassword : "")));
            arrPrm.Add(DataHelper.CreateParameter("@pdsNombres", SqlDbType.VarChar, 50, value.DsNombres));
            arrPrm.Add(DataHelper.CreateParameter("@pstNoExpira", SqlDbType.Bit, value.StNoExpira));
            arrPrm.Add(DataHelper.CreateParameter("@pfeExpira", SqlDbType.DateTime, (value.FeExpira.HasValue ? (object)value.FeExpira : DateTime.Now)));
            arrPrm.Add(DataHelper.CreateParameter("@pidGrupo", SqlDbType.Char, 5, (value.IdGrupo != null ? value.IdGrupo : "")));
            arrPrm.Add(DataHelper.CreateParameter("@pstAnulado", SqlDbType.Char, 1, value.StAnulado));
            arrPrm.Add(DataHelper.CreateParameter("@pidUserTk", SqlDbType.Char, 5, value.IdUserTk));
            arrPrm.Add(DataHelper.CreateParameter("@pidPc", SqlDbType.VarChar, 20, value.IdPc));
            arrPrm.Add(DataHelper.CreateParameter("@pfeRegistro", SqlDbType.DateTime, value.FeRegistro));

            return arrPrm;

        }

        #endregion

    }
}
