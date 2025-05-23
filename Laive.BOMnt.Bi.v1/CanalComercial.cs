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
    


    public class CanalComercial : BusinessObjectBase, IBOUpdate
    {

        public string[] UpdateData(IEntityBase value)
        {

            ECanalComercial objE = (ECanalComercial)value;
            object[] objRet = null;

            try
            {

                //using (TransactionScope tx = new TransactionScope())
                //{

                //this.DeleteDetail(objE.ESolidoLeche, true);

                objRet = this.UpdateMaster(objE);
                //this.UpdateDetail(objE.ESolidoLeche, objRet);

                //tx.Complete();

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

            ECanalComercial objE = (ECanalComercial)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE.ESolidoLeche, false);
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
        private object[] UpdateMaster(ECanalComercial entity)
        {

            IDOUpdate objDO = new BIDOMnt.CanalComercial();

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

        private void UpdateDetail(IList<ECanalComercial> col, object[] primKey)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new BIDOMnt.CanalComercial();

            foreach (ECanalComercial objE in col)
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

        private void DeleteMaster(ECanalComercial entity)
        {

            IDOUpdate objDO = new BIDOMnt.CanalComercial();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<ESolidoLeche> col, bool filterModified)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new BIDOMnt.SolidoLeche();
            IEnumerable<ESolidoLeche> colSel = null;

            if (filterModified)
            {
                var deleteItems = from itm in col
                                  where itm.EntityState == EntityState.Deleted
                                  select itm;

                colSel = (IEnumerable<ESolidoLeche>)deleteItems;
            }
            else
            {
                var deleteItems = from itm in col
                                  select itm;

                colSel = (IEnumerable<ESolidoLeche>)deleteItems;
            }
            foreach (ESolidoLeche objE in colSel)
                objDO.Delete(objE);

        }
    }
    
}
