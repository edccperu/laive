using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using SamNet.Core.Data;
using SamNet.Entity.Mg;
using SamNet.Core.Common;
using MGDOMnt = SamNet.DOMnt.Mg;

namespace SamNet.BOMnt.Mg
{
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: MG_UsuarioCCosto (MG_UsuarioCCosto)
    /// </summary>
    public class UsuarioCCosto : BusinessObjectBase, IBOUpdate
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            EUsuarioCCostoSet objE = (EUsuarioCCostoSet)value;
            object[] objRet = null;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    this.DeleteDetail(objE.listUsuarioCCosto, true);

                    //objRet = this.UpdateMaster(objE.EUsuarioCCosto);
                    this.UpdateDetail(objE.listUsuarioCCosto, objRet);

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

            EUsuarioCCostoSet objE = (EUsuarioCCostoSet)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    this.DeleteDetail(objE.listUsuarioCCosto, false);
                    //this.DeleteMaster(objE.EUsuarioCCosto);

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

        private object[] UpdateMaster(EUsuarioCCosto entity)
        {

            IDOUpdate objDO = new MGDOMnt.UsuarioCCosto();

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

        private void UpdateDetail(IList<EUsuarioCCosto> col, object[] primKey)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new MGDOMnt.UsuarioCCosto();

            foreach (EUsuarioCCosto objE in col)
            {

                object[] objRet = null;

                if (primKey != null)
                {
                    objE.IdUnidadEjec = primKey[0].ToString();
                }

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

        private void DeleteMaster(EUsuarioCCosto entity)
        {

            IDOUpdate objDO = new MGDOMnt.UsuarioCCosto();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<EUsuarioCCosto> col, bool filterModified)
        {

            if (col == null && col.Count == 0)
                return;

            IDOUpdate objDO = new MGDOMnt.UsuarioCCosto();
            EUsuarioCCosto objE = col[0] as EUsuarioCCosto;

            if (objE != null)
            {
                objDO.Delete(objE);
            }
        }

    }
}
