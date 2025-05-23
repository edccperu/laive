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
   /// Data Object para Mantenimiento a la Tabla: DI_OrdenVenta (DI_OrdenVenta)
   /// </summary>
   /// <remarks></remarks>
   public class OrdenVenta : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt01", arrPrm);

            return new object[] { objE.FechaPrograma };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt02", arrPrm);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));
            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, objE.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));

            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(EOrdenVenta value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, value.FechaPrograma));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));
         arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
         arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char, 9, value.Orden));
         arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, value.Linea));
         arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, value.Sublinea));
         arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, value.TipoCarga));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoGrupo", SqlDbType.Char, 9, value.CodigoGrupo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaOrden", SqlDbType.DateTime, value.FechaOrden));
         arrPrm.Add(DataHelper.CreateParameter("@ppaleta", SqlDbType.Decimal, value.Paleta));
         arrPrm.Add(DataHelper.CreateParameter("@pempaque", SqlDbType.Decimal, value.Empaque));
         arrPrm.Add(DataHelper.CreateParameter("@punidadPedido", SqlDbType.Char, 3, value.UnidadPedido));
         arrPrm.Add(DataHelper.CreateParameter("@pcantidadPedido", SqlDbType.Decimal, value.CantidadPedido));
         arrPrm.Add(DataHelper.CreateParameter("@pkilosNeto", SqlDbType.Decimal, value.KilosNeto));
         arrPrm.Add(DataHelper.CreateParameter("@pkilosBruto", SqlDbType.Decimal, value.KilosBruto));
         arrPrm.Add(DataHelper.CreateParameter("@pimportePedido", SqlDbType.Decimal, value.ImportePedido));
         arrPrm.Add(DataHelper.CreateParameter("@pstpo", SqlDbType.Bit, value.Stpo));
         arrPrm.Add(DataHelper.CreateParameter("@pstEstado", SqlDbType.Char, 3, value.StEstado));
         arrPrm.Add(DataHelper.CreateParameter("@pidUserTkCarga", SqlDbType.Char, 5, value.IdUserTkCarga));

         return arrPrm;

      }

      #endregion


      public int AsignacionAutomatica(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();
            
            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pidUser", SqlDbType.Char, 5, objE.IdUserProceso));

            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt10", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }


      public int EliminarArticulo(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char,9, objE.CodigoArticulo));
            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt11", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int EliminarPartner(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.DateTime, objE.FechaPrograma));
            arrPrm.Add(DataHelper.CreateParameter("@ptipoAsignacion", SqlDbType.Int, objE.TipoAsignacion));
            arrPrm.Add(DataHelper.CreateParameter("@porden", SqlDbType.Char,9, objE.Orden));
            arrPrm.Add(DataHelper.CreateParameter("@plinea", SqlDbType.Int, objE.Linea));
            arrPrm.Add(DataHelper.CreateParameter("@psublinea", SqlDbType.Int, objE.Sublinea));
            int intRes = this.ExecuteNonQuery("DI_OrdenVenta_mnt12", arrPrm);

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
