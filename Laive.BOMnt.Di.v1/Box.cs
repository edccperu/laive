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
   /// Business Object para Mantenimiento a la Tabla: DI_Box (DI_Box)
   /// </summary>
   public class Box : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EBox objE = (EBox)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EBox, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.EBox, objRet);

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

         EBox objE = (EBox)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EBox, false);
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

      private object[] UpdateMaster(EBox entity)
      {

         IDOUpdate objDO = new DIDOMnt.Box();

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

      private void UpdateDetail(IList<EBox> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Box();

         foreach (EBox objE in col)
         {

            object[] objRet = null;

            //if (primKey != null)
            //{
            //   objE.IdBox = primKey[0].ToString();
            //}

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

      private void DeleteMaster(EBox entity)
      {

         IDOUpdate objDO = new DIDOMnt.Box();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EBox> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Box();
         IEnumerable<EBox> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EBox>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EBox>)deleteItems;
         }
         foreach (EBox objE in colSel)
            objDO.Delete(objE);

      }

   }
}
