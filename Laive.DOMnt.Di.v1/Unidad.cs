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
   /// Data Object para Mantenimiento a la Tabla: DI_Unidad (DI_Unidad)
   /// </summary>
   /// <remarks></remarks>
   public class Unidad : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EUnidad objE = (EUnidad)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_Unidad_mnt01", arrPrm);
            return new object[] { objE.IdTransportista };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EUnidad objE = (EUnidad)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_Unidad_mnt02", arrPrm);

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

         EUnidad objE = (EUnidad)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pidTransportista", SqlDbType.Int, objE.IdTransportista));
            arrPrm.Add(DataHelper.CreateParameter("@pidUnidad", SqlDbType.Int, objE.IdUnidad));

            int intRes = this.ExecuteNonQuery("DI_Unidad_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EUnidad value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidTransportista", SqlDbType.Int, value.IdTransportista));
         arrPrm.Add(DataHelper.CreateParameter("@pidUnidad", SqlDbType.Int, value.IdUnidad));
         arrPrm.Add(DataHelper.CreateParameter("@pidOperador", SqlDbType.Int, value.IdOperador));
         arrPrm.Add(DataHelper.CreateParameter("@pidChofer", SqlDbType.Int, value.IdChofer));
         arrPrm.Add(DataHelper.CreateParameter("@pplaca", SqlDbType.VarChar, 15, value.Placa));
         arrPrm.Add(DataHelper.CreateParameter("@pcargaUtil", SqlDbType.Decimal, value.CargaUtil));
         arrPrm.Add(DataHelper.CreateParameter("@pcapacidad", SqlDbType.Decimal, value.Capacidad));
         arrPrm.Add(DataHelper.CreateParameter("@pcostoFrios", SqlDbType.Decimal, value.CostoFrios));
         arrPrm.Add(DataHelper.CreateParameter("@pcostoSecos", SqlDbType.Decimal, value.CostoSecos));
         arrPrm.Add(DataHelper.CreateParameter("@pcomunicacion", SqlDbType.VarChar, 50, value.Comunicacion));
         arrPrm.Add(DataHelper.CreateParameter("@phoraCarga", SqlDbType.Char, 8, value.HoraCarga));
         arrPrm.Add(DataHelper.CreateParameter("@ppaleta", SqlDbType.Decimal, value.Paleta));
         arrPrm.Add(DataHelper.CreateParameter("@pmarcaUnidad", SqlDbType.VarChar, 50, value.MarcaUnidad));
         arrPrm.Add(DataHelper.CreateParameter("@pmodeloUnidad", SqlDbType.VarChar, 50, value.ModeloUnidad));
         arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, value.TipoCarga));
         arrPrm.Add(DataHelper.CreateParameter("@pactivo", SqlDbType.Bit, value.Activo));

         return arrPrm;

      }

      #endregion

   }
}
