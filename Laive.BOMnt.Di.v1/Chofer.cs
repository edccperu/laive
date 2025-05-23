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
   /// Business Object para Mantenimiento a la Tabla: DI_Chofer (DI_Chofer)
   /// </summary>
   public class Chofer : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EChofer objE = (EChofer)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EChofer, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.EChofer, objRet);

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

         EChofer objE = (EChofer)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EChofer, false);
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

      private object[] UpdateMaster(EChofer entity)
      {

         IDOUpdate objDO = new DIDOMnt.Chofer();

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

      private void UpdateDetail(IList<EChofer> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Chofer();

         foreach (EChofer objE in col)
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

      private void DeleteMaster(EChofer entity)
      {

         IDOUpdate objDO = new DIDOMnt.Chofer();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EChofer> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new DIDOMnt.Chofer();
         IEnumerable<EChofer> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EChofer>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EChofer>)deleteItems;
         }
         foreach (EChofer objE in colSel)
            objDO.Delete(objE);

      }

   }
}
