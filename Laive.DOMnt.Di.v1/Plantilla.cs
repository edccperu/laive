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
   /// Data Object para Mantenimiento a la Tabla: DI_Plantilla (DI_Plantilla)
   /// </summary>
   /// <remarks></remarks>
   public class Plantilla : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EPlantilla objE = (EPlantilla)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Plantilla_mnt01", arrPrm);

            return new object[] { objE.CodigoPlantilla };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EPlantilla objE = (EPlantilla)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Plantilla_mnt02", arrPrm);

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

         EPlantilla objE = (EPlantilla)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPlantilla", SqlDbType.Int, objE.CodigoPlantilla));

            int intRes = this.ExecuteNonQuery("DI_Plantilla_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EPlantilla value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPlantilla", SqlDbType.Int, value.CodigoPlantilla));
         arrPrm.Add(DataHelper.CreateParameter("@pglosaPlantilla", SqlDbType.VarChar, 150, value.GlosaPlantilla));
         arrPrm.Add(DataHelper.CreateParameter("@pnumeroCamiones", SqlDbType.Int, value.NumeroCamiones));

         return arrPrm;

      }


      public int CreatePlantilla(string nombre, DateTime fechaPrograma)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pglosaPlantilla", SqlDbType.VarChar, 150, nombre));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, fechaPrograma));

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Plantilla_mnt10", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public int CargarPlantilla(int codigoPlantilla, DateTime fechaPrograma)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPlantilla", SqlDbType.Int, codigoPlantilla));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, fechaPrograma));

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Plantilla_mnt11", arrPrm);

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
