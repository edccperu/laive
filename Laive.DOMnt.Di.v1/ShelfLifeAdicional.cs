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
   /// Data Object para Mantenimiento a la Tabla: DI_ShelfLifeAdicional (DI_ShelfLifeAdicional)
   /// </summary>
   /// <remarks></remarks>
   public class ShelfLifeAdicional : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_ShelfLifeAdicional_mnt01", arrPrm);

            return new object[] { objE.IdShelfLifeAdicional };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_ShelfLifeAdicional_mnt02", arrPrm);

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidShelfLifeAdicional", SqlDbType.Int, objE.IdShelfLifeAdicional));

            int intRes = this.ExecuteNonQuery("DI_ShelfLifeAdicional_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EShelfLifeAdicional value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidShelfLifeAdicional", SqlDbType.Int, value.IdShelfLifeAdicional));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoGrupo", SqlDbType.Char, 9, value.CodigoGrupo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
         arrPrm.Add(DataHelper.CreateParameter("@pshelfLife", SqlDbType.Int, value.ShelfLife));
         arrPrm.Add(DataHelper.CreateParameter("@pdiasAdicional", SqlDbType.Int, value.DiasAdicional));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaInicio", SqlDbType.DateTime, value.FechaInicio));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaFin", SqlDbType.DateTime, value.FechaFin));
         arrPrm.Add(DataHelper.CreateParameter("@ptipoRegistro", SqlDbType.Char, 3, value.TipoRegistro));
         arrPrm.Add(DataHelper.CreateParameter("@pidUserTk", SqlDbType.Char, 5, value.IdUserTk));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));

         return arrPrm;

      }

      #endregion

   }
}
