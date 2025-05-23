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

namespace Laive.BOMnt.Di
{
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_ShelfLifeAdicional (DI_ShelfLifeAdicional)
   /// </summary>
   public class ShelfLifeAdicional : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;
         object[] objRet = null;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
                 objRet = this.UpdateMaster(objE);
            //   tx.Complete();
            //}

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

         EShelfLifeAdicional objE = (EShelfLifeAdicional)value;

         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{

               //this.DeleteDetail(objE.EShelfLifeAdicional, false);
               this.DeleteMaster(objE);

               //tx.Complete();

            //}

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      #endregion

      private object[] UpdateMaster(EShelfLifeAdicional entity)
      {

         IDOUpdate objDO = new DIDOMnt.ShelfLifeAdicional();

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

      private void UpdateDetail(IList<EShelfLifeAdicional> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.ShelfLifeAdicional();

         foreach (EShelfLifeAdicional objE in col)
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

      private void DeleteMaster(EShelfLifeAdicional entity)
      {

         IDOUpdate objDO = new DIDOMnt.ShelfLifeAdicional();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EShelfLifeAdicional> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.ShelfLifeAdicional();
         IEnumerable<EShelfLifeAdicional> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EShelfLifeAdicional>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EShelfLifeAdicional>)deleteItems;
         }
         foreach (EShelfLifeAdicional objE in colSel)
            objDO.Delete(objE);

      }

   }
}
