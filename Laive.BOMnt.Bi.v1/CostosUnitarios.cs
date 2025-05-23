using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Bi;
using Laive.Core.Common;
using BIDOMnt = Laive.DOMnt.Bi;


namespace Laive.BOMnt.Bi
{
    public class CostosUnitarios : BusinessObjectBase, IBOUpdate
    {
        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            ECostosUnitarios objE = (ECostosUnitarios)value;
            object[] objRet = null;

            try
            {
                objRet = this.UpdateMaster(objE);
                //using (TransactionScope tx = new TransactionScope())
                //{

                //    this.DeleteDetail(objE.ECostosUnitarios, true);

                //    objRet = this.UpdateMaster(objE.ECostosUnitarios);
                //    this.UpdateDetail(objE.ECostosUnitarios, objRet);

                //    tx.Complete();

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

            ECostosUnitarios objE = (ECostosUnitarios)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE.ECosto_SMV, false);
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

        private object[] UpdateMaster(ECostosUnitarios entity)
        {

            IDOUpdate objDO = new BIDOMnt.CostosUnitarios();

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

        private void UpdateDetail(IList<ECostosUnitarios> col, object[] primKey)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new BIDOMnt.CostosUnitarios();

            foreach (ECostosUnitarios objE in col)
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

        private void DeleteMaster(ECostosUnitarios entity)
        {

            IDOUpdate objDO = new BIDOMnt.CostosUnitarios();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<ECostosUnitarios> col, bool filterModified)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new BIDOMnt.CostosUnitarios();
            IEnumerable<ECostosUnitarios> colSel = null;

            if (filterModified)
            {
                var deleteItems = from itm in col
                                  where itm.EntityState == EntityState.Deleted
                                  select itm;

                colSel = (IEnumerable<ECostosUnitarios>)deleteItems;
            }
            else
            {
                var deleteItems = from itm in col
                                  select itm;

                colSel = (IEnumerable<ECostosUnitarios>)deleteItems;
            }
            foreach (ECostosUnitarios objE in colSel)
                objDO.Delete(objE);

        }


    }
}
