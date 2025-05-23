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
   /// Data Object para Mantenimiento a la Tabla: FI_FirmantePc (FI_FirmantePc)
   /// </summary>
   /// <remarks></remarks>
   public class FirmantePc : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;

         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("FI_FirmantePc_mnt01", arrPrm);

            return new object[] { objE.CodigoFirmante };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("FI_FirmantePc_mnt02", arrPrm);

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

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));
            arrPrm.Add(DataHelper.CreateParameter("@pnuSecuen", SqlDbType.Int, objE.NuSecuen));

            int intRes = this.ExecuteNonQuery("FI_FirmantePc_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EFirmantePc value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, value.CodigoFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pnuSecuen", SqlDbType.Int, value.NuSecuen));
         arrPrm.Add(DataHelper.CreateParameter("@pipFirmante", SqlDbType.VarChar, 15, value.IpFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@phostNameFirmante", SqlDbType.VarChar, 50, value.HostNameFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Char, 1, value.Activo));

         return arrPrm;

      }

      #endregion

   }
}
