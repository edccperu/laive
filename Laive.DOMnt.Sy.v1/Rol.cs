using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;
using Laive.Core.Common;

namespace Laive.DOMnt.Sy
{
   /// <summary>
   /// Data Object para Mantenimiento a la Tabla: SY_Rol (SY_Rol)
   /// </summary>
   /// <remarks></remarks>
   public class Rol : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         ERol objE = (ERol)value;

         //----------- Generacion de Codigos ------------------
         TablaCorre objDO = new TablaCorre();
         ETablaCorre objECorre = new ETablaCorre();

         objECorre.IdPeriodo = ConstDefaultValue.PERIODO;
         objECorre.IdUnidadEjec = ConstDefaultValue.UNIDAD_EJECUTORA;
         objECorre.IdSede = ConstDefaultValue.SEDE;
         objECorre.IdTabla = "SY_Rol";

         int strNewCode = Convert.ToInt32(objDO.GenNewCode(objECorre));
         objE.IdRol = strNewCode;

         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("SY_Rol_mnt01", arrPrm);

            return new object[] { objE.IdRol };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         ERol objE = (ERol)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("SY_Rol_mnt02", arrPrm);

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

         ERol objE = (ERol)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, objE.IdRol));

            int intRes = this.ExecuteNonQuery("SY_Rol_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(ERol value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, value.IdRol));
         arrPrm.Add(DataHelper.CreateParameter("@pdsNombreRol", SqlDbType.VarChar, 120, value.DsNombreRol));
         arrPrm.Add(DataHelper.CreateParameter("@pdsDescripcionRol", SqlDbType.VarChar, 450, value.DsDescripcionRol));
         arrPrm.Add(DataHelper.CreateParameter("@pstAnulado", SqlDbType.Char, 1, value.StAnulado));
         arrPrm.Add(DataHelper.CreateParameter("@pidUserTk", SqlDbType.Char, 5, value.IdUserTk));
         arrPrm.Add(DataHelper.CreateParameter("@pidPc", SqlDbType.VarChar, 20, value.IdPc));
         arrPrm.Add(DataHelper.CreateParameter("@pfeRegistro", SqlDbType.DateTime, value.FeRegistro));

         return arrPrm;

      }


      public int DeleteMenu(IEntityBase value)
      {

         ERol objE = (ERol)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, objE.IdRol));

            int intRes = this.ExecuteNonQuery("SY_Rol_mnt04", arrPrm);

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
