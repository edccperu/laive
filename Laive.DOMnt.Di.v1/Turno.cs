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

namespace Laive.DOMnt.Di
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: DI_Turno (DI_Turno)
    /// </summary>
    /// <remarks></remarks>
    public class Turno : DataObjectBase, IDOUpdate
    {
        public object[] Insert(IEntityBase value) {
                
            ETurno objE = (ETurno)value;
            //----------- Generacion de Codigos ------------------
            //----------------------------------------------------
            ArrayList arrPrm = BuildParamInterface(objE);
            try
            {
                int intRes = this.ExecuteNonQuery("DI_Turno_mnt01", arrPrm);
                return new object[] { objE.IdTurno };

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;
            }
        }

            
        public int Update(IEntityBase value)
        {
            ETurno objE = (ETurno)value;
            try
            {
                ArrayList arrPrm = BuildParamInterface(objE);
                int intRes = this.ExecuteNonQuery("DI_Turno_mnt02", arrPrm);

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
            ETurno objE = (ETurno)value;
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pidTurno", SqlDbType.Int, objE.IdTurno));
                int intRes = this.ExecuteNonQuery("DI_Turno_mnt03", arrPrm);

                return intRes;
            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        private ArrayList BuildParamInterface(ETurno value) 
        {
            ArrayList arrPrm = new ArrayList();
            arrPrm.Add(DataHelper.CreateParameter("@pidTurno",SqlDbType.Int,value.IdTurno));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoTurno", SqlDbType.Char,3, value.CodigoTurno));
            arrPrm.Add(DataHelper.CreateParameter("@pglosaTurno", SqlDbType.VarChar, 30, value.GlosaTurno));
            arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));
            return arrPrm;
        }


    }
}
