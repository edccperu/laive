using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Di;
using Laive.Core.Common;
using DIDOMnt = Laive.DOMnt.Di;
using System.ServiceModel;

namespace Laive.BOMnt.Di
{

   [ServiceContract()]
   public interface IPrioridadAtencion
   {

      /// <summary>
      /// Eliminar registro de priorizacion
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un int</returns>
      [OperationContract()]
      [NetDataContract()]
      int EliminarPriorizacion(List<IEntityBase> ObjE);

      /// <summary>
      /// Prioriza Orden segun Filtro
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un int</returns>
      [OperationContract()]
      [NetDataContract()]
      int PriorizarFiltro(IEntityBase ObjE);
   }
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_PrioridadAtencion (DI_PrioridadAtencion)
   /// </summary>
   public class PrioridadAtencion : BusinessObjectBase, IBOUpdate,IPrioridadAtencion
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {
         EPrioridadAtencionSet objE = (EPrioridadAtencionSet)value;
         object[] objRet = null;

         try
         {
            using (TransactionScope tx = new TransactionScope())
            {
               //this.DeleteDetail(objE.EPrioridadAtencionList, true);
               //objRet = this.UpdateMaster(objE.EPrioridadAtencion);
               this.UpdateDetail(objE.EPrioridadAtencionList, objRet);

               tx.Complete();

            }

            if (objRet == null)
               return null;

            return new String[] { objRet[0].ToString() };

         }
         catch (Exception ex)
         {

            throw ex;

         }
      }

      public int DeleteData(IEntityBase value)
      {

         EPrioridadAtencionSet objE = (EPrioridadAtencionSet)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               this.DeleteDetail(objE.EPrioridadAtencionList, false);
               //this.DeleteMaster(objE.EPrioridadAtencion);

               tx.Complete();

            }

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      #endregion

      private object[] UpdateMaster(EPrioridadAtencion entity)
      {

         IDOUpdate objDO = new DIDOMnt.PrioridadAtencion();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;

            case EntityState.Modified:
               objDO.Update(entity);
               break;
            case EntityState.Deleted:
               objDO.Delete(entity);
               break;

         }

         return objRet;
      }

      private void UpdateDetail(IList<EPrioridadAtencion> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.PrioridadAtencion();

         foreach (EPrioridadAtencion objE in col)
         {

            object[] objRet = null;

            switch (objE.EntityState)
            {

               case EntityState.Added:
                  objRet = objDO.Insert(objE);
                  break;

               case EntityState.Modified:
                  if (objE.StAnulado == ConstFlagEstado.DESACTIVADO)
                     objDO.Update(objE);
                  else
                     objDO.Delete(objE);
                  break;

            }

         }

      }

      private void DeleteMaster(EPrioridadAtencion entity)
      {

         IDOUpdate objDO = new DIDOMnt.PrioridadAtencion();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EPrioridadAtencion> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.PrioridadAtencion();
         IEnumerable<EPrioridadAtencion> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EPrioridadAtencion>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EPrioridadAtencion>)deleteItems;
         }
         foreach (EPrioridadAtencion objE in colSel)
            objDO.Delete(objE);

      }

      public int EliminarPriorizacion(List<IEntityBase> list)
      {
         try
         {
            using (TransactionScope tx = new TransactionScope())
            {
               foreach (IEntityBase IEB in list)
               {
                  DIDOMnt.PrioridadAtencion objDO = new DIDOMnt.PrioridadAtencion();
                  objDO.EliminarPriorizacion(IEB);
               }
               tx.Complete();
            }
            return 1;
         }
         catch (Exception ex)
         {
            throw ex;
         }

      }

      public int PriorizarFiltro(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
            DIDOMnt.PrioridadAtencion objDO = new DIDOMnt.PrioridadAtencion();
            objDO.PriorizarFiltro(objE);

            //tx.Complete();

            //}

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }
   }
}
