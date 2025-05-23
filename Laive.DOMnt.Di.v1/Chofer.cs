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
   /// Data Object para Mantenimiento a la Tabla: DI_Chofer (DI_Chofer)
   /// </summary>
   /// <remarks></remarks>
   public class Chofer : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EChofer objE = (EChofer)value;

         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Chofer_mnt01", arrPrm);

            return new object[] { objE.IdChofer };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EChofer objE = (EChofer)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Chofer_mnt02", arrPrm);

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

         EChofer objE = (EChofer)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidChofer", SqlDbType.Int, objE.IdChofer));

            int intRes = this.ExecuteNonQuery("DI_Chofer_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EChofer value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidChofer", SqlDbType.Int, value.IdChofer));
         arrPrm.Add(DataHelper.CreateParameter("@pclaveChofer", SqlDbType.VarChar, 10, value.ClaveChofer));
         arrPrm.Add(DataHelper.CreateParameter("@pnombreChofer", SqlDbType.VarChar, 50, value.NombreChofer));
         arrPrm.Add(DataHelper.CreateParameter("@plicenciaChofer", SqlDbType.VarChar, 30, value.LicenciaChofer));
         arrPrm.Add(DataHelper.CreateParameter("@pcomunicacion", SqlDbType.VarChar, 50, value.Comunicacion));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));

         return arrPrm;

      }

      #endregion

   }
}
