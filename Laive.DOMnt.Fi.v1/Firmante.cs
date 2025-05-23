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
   /// Data Object para Mantenimiento a la Tabla: FI_Firmante (FI_Firmante)
   /// </summary>
   /// <remarks></remarks>
   public class Firmante : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EFirmante objE = (EFirmante)value;
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            DataTable dt = this.ExecuteDatatable("FI_Firmante_mnt01", arrPrm);
            return new object[] { dt.Rows[0][0].ToString() };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EFirmante objE = (EFirmante)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("FI_Firmante_mnt02", arrPrm);

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

         EFirmante objE = (EFirmante)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));

            int intRes = this.ExecuteNonQuery("FI_Firmante_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EFirmante value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, value.CodigoFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pnombreFirmante", SqlDbType.VarChar, 50, value.NombreFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@plogin", SqlDbType.VarChar, 30, value.Login));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));
         arrPrm.Add(DataHelper.CreateParameter("@pfirmaManual", SqlDbType.Bit, value.FirmaManual));
         arrPrm.Add(DataHelper.CreateParameter("@pidTipoFirmante", SqlDbType.Int, value.IdTipoFirmante));

         return arrPrm;

      }


      public int UpdateFirma(IEntityBase value)
      {

         EFirmante objE = (EFirmante)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));
            arrPrm.Add(DataHelper.CreateParameter("@pFirma", SqlDbType.VarBinary,-1, objE.Firma));
        
            int intRes = this.ExecuteNonQuery("FI_Firmante_mnt04", arrPrm);

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
