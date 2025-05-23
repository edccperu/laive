using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Fi;
using Laive.Core.Common;
using FIDOMnt = Laive.DOMnt.Fi;

namespace Laive.BOMnt.Fi
{
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: FI_FirmantePc (FI_FirmantePc)
   /// </summary>
   public class FirmantePc : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               objRet = this.UpdateMaster(objE);
               
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

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

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

      private object[] UpdateMaster(EFirmantePc entity)
      {

         IDOUpdate objDO = new FIDOMnt.FirmantePc();

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

      private void UpdateDetail(IList<EFirmantePc> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new FIDOMnt.FirmantePc();

         foreach (EFirmantePc objE in col)
         {

            object[] objRet = null;

            if (primKey != null)
            {
               objE.CodigoFirmante = primKey[0].ToString();
            }

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

      private void DeleteMaster(EFirmantePc entity)
      {

         IDOUpdate objDO = new FIDOMnt.FirmantePc();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EFirmantePc> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new FIDOMnt.FirmantePc();
         IEnumerable<EFirmantePc> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EFirmantePc>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EFirmantePc>)deleteItems;
         }
         foreach (EFirmantePc objE in colSel)
            objDO.Delete(objE);

      }

   }
}
