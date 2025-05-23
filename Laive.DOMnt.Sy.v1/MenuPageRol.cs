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
   /// Data Object para Mantenimiento a la Tabla: SY_MenuPageRol (SY_MenuPageRol)
   /// </summary>
   /// <remarks></remarks>
   public class MenuPageRol : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EMenuPageRol objE = (EMenuPageRol)value;
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("SY_MenuPageRol_mnt01", arrPrm);

            return new object[] { objE.IdMenuPage };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EMenuPageRol objE = (EMenuPageRol)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("SY_MenuPageRol_mnt02", arrPrm);

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

         EMenuPageRol objE = (EMenuPageRol)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidMenuPage", SqlDbType.Char, 8, objE.IdMenuPage));
            arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, objE.IdRol));

            int intRes = this.ExecuteNonQuery("SY_MenuPageRol_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EMenuPageRol value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidMenuPage", SqlDbType.Char, 8, value.IdMenuPage));
         arrPrm.Add(DataHelper.CreateParameter("@pidRol", SqlDbType.Int, value.IdRol));
         arrPrm.Add(DataHelper.CreateParameter("@pstateCheck", SqlDbType.Int, value.StateCheck));

         return arrPrm;

      }

      #endregion

   }
}
