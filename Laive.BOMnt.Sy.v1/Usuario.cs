using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Core.Entity;
using Laive.Entity.Sy;
using Laive.Core.Common;
using SYDOMnt = Laive.DOMnt.Sy;

namespace Laive.BOMnt.Sy
{
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: SY_Usuario (SY_Usuario)
    /// </summary>
    public class Usuario : BusinessObjectBase, IBOUpdate
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            EUsuario objE = (EUsuario)value;
            object[] objRet = null;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    objRet = this.UpdateMaster(objE);
                    string primary = "";

                    if (objRet != null)
                        primary = objRet[0].ToString();
                    else
                        primary = objE.IdUser;


                    //this.DeleteDetail(objE.ListNodeTV, primary);
                    //this.UpdateDetail(objE.ListNodeTV, primary);

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

            EUsuario objE = (EUsuario)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    
                    this.DeleteMaster(objE);
                    this.DeleteDetail(objE.ListNodeTV, objE.IdUser);
                    
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

        private object[] UpdateMaster(EUsuario entity)
        {

            IDOUpdate objDO = new SYDOMnt.Usuario();

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

        private void UpdateDetail(IList<EMenuPageUsuario> col, string primKey)
        {

            if (col == null && col.Count == 0)
                return;

            IDOUpdate objDO = new SYDOMnt.MenuPageUsuario();

            foreach (EMenuPageUsuario objE in col)
            {
                objE.IdUser = primKey;
                objDO.Insert(objE);
            }

        }

        private void DeleteMaster(EUsuario entity)
        {

            IDOUpdate objDO = new SYDOMnt.Usuario();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<EMenuPageUsuario> col, string primKey)
        {

            if (col == null && col.Count == 0)
                return;

            IDOUpdate objDO = new SYDOMnt.MenuPageUsuario();
            EMenuPageUsuario objE = col[0] as EMenuPageUsuario;

            if (objE != null)
            {
                objE.IdUser = primKey;
                objDO.Delete(objE);
            }
        }

    }
}
