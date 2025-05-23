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
    public class Turno : BusinessObjectBase, IBOUpdate
    {

        public string[] UpdateData(IEntityBase value)
        {
            ETurno objE = (ETurno)value;
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
            ETurno objE = (ETurno)value;
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE.EUnidad, false);
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


        private void DeleteMaster(ETurno entity)
        {

            IDOUpdate objDO = new DIDOMnt.Turno();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private object[] UpdateMaster(ETurno entity)
        {
            IDOUpdate objDO = new DIDOMnt.Turno();
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

    }
}
