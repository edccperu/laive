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
   /// Data Object para Mantenimiento a la Tabla: DI_PrioridadAtencion (DI_PrioridadAtencion)
   /// </summary>
   /// <remarks></remarks>
   public class PrioridadAtencion : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EPrioridadAtencion objE = (EPrioridadAtencion)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_PrioridadAtencion_mnt01", arrPrm);

            return new object[] { objE.CodigoPartner };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EPrioridadAtencion objE = (EPrioridadAtencion)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_PrioridadAtencion_mnt02", arrPrm);

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

         EPrioridadAtencion objE = (EPrioridadAtencion)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

            int intRes = this.ExecuteNonQuery("DI_PrioridadAtencion_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EPrioridadAtencion value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
         arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
         arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
         arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
         arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, value.FechaPrograma));
         arrPrm.Add(DataHelper.CreateParameter("@pprioridad", SqlDbType.Int, value.Prioridad));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
         arrPrm.Add(DataHelper.CreateParameter("@pconsistencia", SqlDbType.Int, value.Consistencia));
         arrPrm.Add(DataHelper.CreateParameter("@pcantidadPedido", SqlDbType.Decimal, value.CantidadPedido));
         arrPrm.Add(DataHelper.CreateParameter("@pkilosNeto", SqlDbType.Decimal, value.KilosNeto));
         arrPrm.Add(DataHelper.CreateParameter("@pkilosBruto", SqlDbType.Decimal, value.KilosBruto));
         arrPrm.Add(DataHelper.CreateParameter("@pimportePedido", SqlDbType.Decimal, value.ImportePedido));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaVencimiento", SqlDbType.DateTime, value.FechaVencimiento));
         return arrPrm;

      }

      #endregion



      public int EliminarPriorizacion(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));
            arrPrm.Add(DataHelper.CreateParameter("@pconsistencia", SqlDbType.Int, objE.Consistencia));
            arrPrm.Add(DataHelper.CreateParameter("@pfechaVencimiento", SqlDbType.Date, objE.FechaVencimiento));

            int intRes = this.ExecuteNonQuery("DI_PrioridadAtencion_mnt11", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int PriorizarFiltro(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

            int intRes = this.ExecuteNonQuery("DI_PrioridadAtencion_mnt10", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }
   }
}
