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

namespace Laive.DOMnt.Sy
{
    /// <summary>
    /// Data Object para Mantenimiento a la Tabla: Tabla Correlativo (SY_TablaCorre)
    /// </summary>
    /// <remarks></remarks>
    public class TablaCorre : DataObjectBase
    {
        public string GenNewCode(IEntityBase value)
        {

            ETablaCorre objE = (ETablaCorre)value;

            try
            {
                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidUnidadEjec", SqlDbType.Char, 6, objE.IdUnidadEjec));
                arrPrm.Add(DataHelper.CreateParameter("@pidSede", SqlDbType.Char, 3, objE.IdSede));
                arrPrm.Add(DataHelper.CreateParameter("@pidPeriodo", SqlDbType.Char, 4, objE.IdPeriodo));
                arrPrm.Add(DataHelper.CreateParameter("@pidTabla", SqlDbType.VarChar, 25, objE.IdTabla));

                DataTable dt = this.ExecuteDatatable("SY_TablaCorre_mnt10", arrPrm);

                int intCode = 0;
                string strFmt = "";

                foreach (DataRow dr in dt.Rows)
                {
                    intCode = Convert.ToInt32(dr[0]);
                    strFmt = dr[1].ToString();
                }

                return intCode.ToString(strFmt);

            }
            catch (Exception ex)
            {
                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }

        }

    }
}
