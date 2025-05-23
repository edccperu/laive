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
   /// Business Object para Mantenimiento a la Tabla: SY_Rol (SY_Rol)
   /// </summary>
   public class Rol : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         ERol objE = (ERol)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               objRet = this.UpdateMaster(objE);
               int primary;
               if (objRet != null)
                  primary = Convert.ToInt32(objRet[0].ToString());
               else
                  primary = objE.IdRol;


               this.DeleteDetail(objE.ListNodeTV, primary);

               this.UpdateDetail(objE.ListNodeTV, primary);

               this.UpdateDetailUser(objE.ListRolUsuario, primary);

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

         ERol objE = (ERol)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               this.DeleteDetail(objE.ListNodeTV, objE.IdRol);
               this.UpdateDetailUser(objE.ListRolUsuario, objE.IdRol);

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

      private object[] UpdateMaster(ERol entity)
      {

         IDOUpdate objDO = new SYDOMnt.Rol();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;

            case EntityState.Modified:
               if (entity.StAnulado == ConstFlagEstado.DESACTIVADO)
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

      private void UpdateDetail(IList<EMenuPageRol> col, int primKey)
      {

         if (col == null && col.Count == 0)
            return;

         IDOUpdate objDO = new SYDOMnt.MenuPageRol();

         foreach (EMenuPageRol objE in col)
         {
            objE.IdRol = primKey;
            objDO.Insert(objE);
         }

      }

      private void UpdateDetailUser(IList<ERolUsuario> col, int primKey)
      {

         if (col == null || col.Count == 0)
            return;

         IDOUpdate objDO = new SYDOMnt.RolUsuario();

         foreach (ERolUsuario objE in col)
         {
            objE.IdRol = primKey;
            if (objE.EntityState == EntityState.Added)
               objDO.Insert(objE);
            else
               objDO.Delete(objE);
         }

      }


      private void DeleteMaster(ERol entity)
      {

         IDOUpdate objDO = new SYDOMnt.Rol();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EMenuPageRol> col, int primKey)
      {

         if (col == null && col.Count == 0)
            return;

         SYDOMnt.Rol objDO = new SYDOMnt.Rol();
         ERol objE = new ERol();
         objE.IdRol = primKey;
         objDO.DeleteMenu(objE);

      }

   }
}
