using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Mg;
using Laive.Core.Common;
using MGDOMnt = Laive.DOMnt.Mg;

namespace Laive.BOMnt.Mg
{
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: MG_TablaGen (MG_TablaGen)
    /// </summary>
    public class TablaGen : BusinessObjectBase, IBOUpdate
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            ETablaGen objE = (ETablaGen)value;
            object[] objRet = null;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    this.DeleteDetail(objE.TablaGenDet, true);

                    objRet = this.UpdateMaster(objE);
                    this.UpdateDetail(objE.TablaGenDet, objRet);

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

            ETablaGen objE = (ETablaGen)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    this.DeleteDetail(objE.TablaGenDet, false);
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

        private object[] UpdateMaster(ETablaGen entity)
        {

            IDOUpdate objDO = new MGDOMnt.TablaGen();

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

        private void UpdateDetail(ICollection<ETablaGenDet> col, object[] primKey)
        {

            if (col == null && col.Count != 0)
                return;

            IDOUpdate objDO = new MGDOMnt.TablaGenDet();

            foreach (ETablaGenDet objE in col)
            {

                object[] objRet = null;

                if (primKey != null)
                {
                    objE.IdTabla = primKey[0].ToString();
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
                    case EntityState.Deleted:
                        objDO.Delete(objE);
                        break;
                }

            }

        }

        private void DeleteMaster(ETablaGen entity)
        {

            IDOUpdate objDO = new MGDOMnt.TablaGen();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(ICollection<ETablaGenDet> col, bool filterModified)
        {

            if (col == null && col.Count != 0)
                return;

            IDOUpdate objDO = new MGDOMnt.TablaGenDet();
            IEnumerable<ETablaGenDet> colSel = null;

            if (filterModified)
            {
                var deleteItems = from itm in col
                                  where itm.EntityState == EntityState.Deleted
                                  select itm;

                colSel = (IEnumerable<ETablaGenDet>)deleteItems;
            }
            else
            {
                var deleteItems = from itm in col
                                  select itm;

                colSel = (ICollection<ETablaGenDet>)deleteItems;
            }
            foreach (ETablaGenDet objE in colSel)
                objDO.Delete(objE);

        }

    }
}
