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
   /// Data Object para Mantenimiento a la Tabla: SY_RolUsuario (SY_RolUsuario)
   /// </summary>
   /// <remarks></remarks>
   public class RolUsuario : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         ERolUsuario objE = (ERolUsuario)value;
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("SY_RolUsuario_mnt01", arrPrm);

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

         ERolUsuario objE = (ERolUsuario)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("SY_RolUsuario_mnt02", arrPrm);

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

         ERolUsuario objE = (ERolUsuario)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, objE.IdRol));
            arrPrm.Add(DataHelper.CreateParameter("@pidUser", SqlDbType.Char, 5, objE.IdUser));

            int intRes = this.ExecuteNonQuery("SY_RolUsuario_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(ERolUsuario value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, value.IdRol));
         arrPrm.Add(DataHelper.CreateParameter("@pidUser", SqlDbType.Char, 5, value.IdUser));

         return arrPrm;

      }

      #endregion

   }
}
