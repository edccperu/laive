using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Sy;
using Laive.Core.Common;
using SYDOMnt = Laive.DOMnt.Sy;

namespace Laive.BOMnt.Sy
{
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: SY_ParametroSistema (SY_ParametroSistema)
   /// </summary>
   public class ParametroSistema : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EParametroSistema objE = (EParametroSistema)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EParametroSistema, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.EParametroSistema, objRet);

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

         EParametroSistema objE = (EParametroSistema)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.EParametroSistema, false);
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

      private object[] UpdateMaster(EParametroSistema entity)
      {

         IDOUpdate objDO = new SYDOMnt.ParametroSistema();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;

            case EntityState.Modified:
               if (entity.Anulado == ConstFlagEstado.DESACTIVADO)
                  objDO.Update(entity);
               else
                  objDO.Delete(entity);
               break;

            case EntityState.Deleted:
               objDO.Delete(entity);
               break;

         }

         return objRet;
      }

      private void UpdateDetail(IList<EParametroSistema> col, object[] primKey)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new SYDOMnt.ParametroSistema();

         foreach (EParametroSistema objE in col)
         {

            object[] objRet = null;

            if (primKey != null)
            {
               objE.IdParametroSistema = Convert.ToInt32(primKey[0].ToString());
            }

            switch (objE.EntityState)
            {

               case EntityState.Added:
                  objRet = objDO.Insert(objE);
                  break;

               case EntityState.Modified:
                  if (objE.Anulado == ConstFlagEstado.DESACTIVADO)
                     objDO.Update(objE);
                  else
                     objDO.Delete(objE);
                  break;

            }

         }

      }

      private void DeleteMaster(EParametroSistema entity)
      {

         IDOUpdate objDO = new SYDOMnt.ParametroSistema();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EParametroSistema> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new SYDOMnt.ParametroSistema();
         IEnumerable<EParametroSistema> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EParametroSistema>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EParametroSistema>)deleteItems;
         }
         foreach (EParametroSistema objE in colSel)
            objDO.Delete(objE);

      }

   }
}
