using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;

namespace Laive.DOMnt.Di
{
   /// <summary>
   /// Data Object para Mantenimiento a la Tabla: DI_Ruta (DI_Ruta)
   /// </summary>
   /// <remarks></remarks>
   public class Ruta : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         ERuta objE = (ERuta)value;

         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Ruta_mnt01", arrPrm);

            return new object[] { objE.IdRuta };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         ERuta objE = (ERuta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Ruta_mnt02", arrPrm);

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

         ERuta objE = (ERuta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));

            int intRes = this.ExecuteNonQuery("DI_Ruta_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(ERuta value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
         arrPrm.Add(DataHelper.CreateParameter("@pglosaRuta", SqlDbType.VarChar, 30, value.GlosaRuta));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));

         return arrPrm;

      }
      public int UpdateRutaXPartner(string idPartner, int idRuta)
      {
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidPartner", SqlDbType.Char, 9, idPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, idRuta));

            try
            {
               int intRes = this.ExecuteNonQuery("DI_Ruta_mnt04", arrPrm);

               return 0;

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
}
