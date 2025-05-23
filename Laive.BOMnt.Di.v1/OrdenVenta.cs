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
   /// <summary>
   /// Interface para Consultas personalizadas
   /// </summary>
   [ServiceContract()]
   public interface IOrdenVenta
   {
      /// <summary>
      /// ASIGNACION AUTOMATICA DE PEDIDOS SEGUN STOCK
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int AsignacionAutomatica(IEntityBase ObjE);

      /// <summary>
      /// Eliminar Articulos
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un int</returns>
      [OperationContract()]
      [NetDataContract()]
      int EliminarArticulo(IEntityBase ObjE);

      /// <summary>
      /// Eliminar Partner
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un int</returns>
      [OperationContract()]
      [NetDataContract()]
      int EliminarPartner(IEntityBase ObjE);

   }


   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_OrdenVenta (DI_OrdenVenta)
   /// </summary>
   public class OrdenVenta : BusinessObjectBase, IBOUpdate, IOrdenVenta
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EOrdenVenta, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.EOrdenVenta, objRet);

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

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EOrdenVenta, false);
               this.DeleteMaster(objE);

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

      private object[] UpdateMaster(EOrdenVenta entity)
      {

         IDOUpdate objDO = new DIDOMnt.OrdenVenta();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;

            case EntityState.Modified:
               //if (entity.StAnulado == ConstFlagEstado.DESACTIVADO)
               objDO.Update(entity);
               //else
               //   objDO.Delete(entity);
               break;

            case EntityState.Deleted:
               objDO.Delete(entity);
               break;

         }

         return objRet;
      }

      private void UpdateDetail(IList<EOrdenVenta> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.OrdenVenta();

         foreach (EOrdenVenta objE in col)
         {

            object[] objRet = null;

            //if (primKey != null)
            //{
            //   objE.FechaPrograma = primKey[0].ToString();
            //}

            switch (objE.EntityState)
            {

               case EntityState.Added:
                  objRet = objDO.Insert(objE);
                  break;

               case EntityState.Modified:
                  //if (objE.StAnulado == ConstFlagEstado.DESACTIVADO)
                  objDO.Update(objE);
                  //else
                  //   objDO.Delete(objE);
                  break;

            }

         }

      }

      private void DeleteMaster(EOrdenVenta entity)
      {

         IDOUpdate objDO = new DIDOMnt.OrdenVenta();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EOrdenVenta> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.OrdenVenta();
         IEnumerable<EOrdenVenta> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EOrdenVenta>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EOrdenVenta>)deleteItems;
         }
         foreach (EOrdenVenta objE in colSel)
            objDO.Delete(objE);

      }
      
      public int AsignacionAutomatica(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
            DIDOMnt.OrdenVenta objDO = new DIDOMnt.OrdenVenta();
            objDO.AsignacionAutomatica(objE);

            //   tx.Complete();

            //}

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int EliminarArticulo(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
               DIDOMnt.OrdenVenta objDO = new DIDOMnt.OrdenVenta();
               objDO.EliminarArticulo(objE);
            //   tx.Complete();

            //}

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int EliminarPartner(IEntityBase value)
      {

         EOrdenVenta objE = (EOrdenVenta)value;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
               DIDOMnt.OrdenVenta objDO = new DIDOMnt.OrdenVenta();
               objDO.EliminarPartner(objE);

            //   tx.Complete();

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
