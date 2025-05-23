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
    public class Transportista : BusinessObjectBase, IBOUpdate
    {

        public string[] UpdateData(IEntityBase value)
        {
            ETransportista objE = (ETransportista)value;
            object[] objRet = null;

            try 
            {
                objRet = this.UpdateMaster(objE);
              
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
            ETransportista objE = (ETransportista)value;
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


        private void DeleteMaster(ETransportista entity)
        {

            IDOUpdate objDO = new DIDOMnt.Transportista();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private object[] UpdateMaster(ETransportista entity)
        {
            IDOUpdate objDO = new DIDOMnt.Transportista();
            if (entity.EntityState == EntityState.Unchanged)
                return null;
            object[] objRet = null;
            switch (entity.EntityState)
            {
                case EntityState.Modified:
                    objDO.Update(entity);
                    break;
            }
            return objRet;
        }
    }
}
