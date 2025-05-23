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
   /// Data Object para Mantenimiento a la Tabla: DI_Almacen (DI_Almacen)
   /// </summary>
   /// <remarks></remarks>
   public class Almacen : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EAlmacen objE = (EAlmacen)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Almacen_mnt01", arrPrm);

            return new object[] { objE.CodigoAlmacen };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EAlmacen objE = (EAlmacen)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Almacen_mnt02", arrPrm);

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

         EAlmacen objE = (EAlmacen)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, objE.CodigoAlmacen));

            int intRes = this.ExecuteNonQuery("DI_Almacen_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EAlmacen value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@pglosaAlmacen", SqlDbType.VarChar, 30, value.GlosaAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@pprimeraOrden", SqlDbType.Char, 9, value.PrimeraOrden));
         arrPrm.Add(DataHelper.CreateParameter("@pultimaOrden", SqlDbType.Char, 9, value.UltimaOrden));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));
         arrPrm.Add(DataHelper.CreateParameter("@plocacion", SqlDbType.Char, 6, value.Locacion));
         arrPrm.Add(DataHelper.CreateParameter("@pentidad", SqlDbType.Char, 6, value.Entidad));

         return arrPrm;

      }

      #endregion

   }
}
