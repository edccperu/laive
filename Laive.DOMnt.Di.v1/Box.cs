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
   /// Data Object para Mantenimiento a la Tabla: DI_Box (DI_Box)
   /// </summary>
   /// <remarks></remarks>
   public class Box : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EBox objE = (EBox)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Box_mnt01", arrPrm);

            return new object[] { objE.IdBox };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EBox objE = (EBox)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Box_mnt02", arrPrm);

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

         EBox objE = (EBox)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidBox", SqlDbType.Int, objE.IdBox));

            int intRes = this.ExecuteNonQuery("DI_Box_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EBox value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidBox", SqlDbType.Int, value.IdBox));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoBox", SqlDbType.VarChar, 15, value.CodigoBox));
         arrPrm.Add(DataHelper.CreateParameter("@pglosaBox", SqlDbType.VarChar, 30, value.GlosaBox));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@psiempredisponible", SqlDbType.Char, 1, value.Siempredisponible));

         return arrPrm;

      }

      #endregion

   }
}
