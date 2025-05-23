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
   public interface IPlantilla
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int CreatePlantilla(string nombre, DateTime fechaPrograma);

      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int CargarPlantilla(int codigoPlantilla, DateTime fechaPrograma);

   }


   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_Plantilla (DI_Plantilla)
   /// </summary>
   public class Plantilla : BusinessObjectBase, IBOUpdate,IPlantilla
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EPlantilla objE = (EPlantilla)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EPlantilla, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.EPlantilla, objRet);

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

         EPlantilla objE = (EPlantilla)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EPlantilla, false);
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

      private object[] UpdateMaster(EPlantilla entity)
      {

         IDOUpdate objDO = new DIDOMnt.Plantilla();

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

      private void UpdateDetail(IList<EPlantilla> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Plantilla();

         foreach (EPlantilla objE in col)
         {

            object[] objRet = null;

            switch (objE.EntityState)
            {

               case EntityState.Added:
                  objRet = objDO.Insert(objE);
                  break;

               case EntityState.Modified:
                     objDO.Update(objE);
                  break;

            }

         }

      }

      private void DeleteMaster(EPlantilla entity)
      {

         IDOUpdate objDO = new DIDOMnt.Plantilla();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EPlantilla> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Plantilla();
         IEnumerable<EPlantilla> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EPlantilla>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EPlantilla>)deleteItems;
         }
         foreach (EPlantilla objE in colSel)
            objDO.Delete(objE);

      }


      public int CreatePlantilla(string nombre, DateTime fechaPrograma)
      {
         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.Plantilla objDO = new DIDOMnt.Plantilla();
               result = objDO.CreatePlantilla(nombre, fechaPrograma);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int CargarPlantilla(int codigoPlantilla, DateTime fechaPrograma)
      {
         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.Plantilla objDO = new DIDOMnt.Plantilla();
               result = objDO.CargarPlantilla(codigoPlantilla, fechaPrograma);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


   }
}
