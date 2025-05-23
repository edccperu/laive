using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Transactions;
using System.ServiceModel;
using Laive.Core.Data;
using FIDOQry = Laive.DOQry.Fi;
using System.Collections.Generic;
using Laive.Core.Common;
using Laive.Entity.Fi;



namespace Laive.BOQry.Fi
{
  
    /// <summary>
    /// Business Object para Consultas a la Tabla: FI_Cheque (FI_Cheque)
    /// </summary>
    public class ChequeResumen : BusinessObjectBase, IBOQuery
    {
        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.ChequeResumen();

            try
            {

                ICollection<T> dt = objData.GetByCriteria<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public IEntityBase GetByKey(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

            try
            {

                IEntityBase objE = objData.GetByKey(value);

                return objE;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

            try
            {

                ICollection<T> dt = objData.GetByParentKey<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

            try
            {

                ICollection<T> dt = objData.GetList<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public bool Exists(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

            try
            {

                bool blnRes = objData.Exists(value);

                return blnRes;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

            try
            {

                ICollection<EntitySelect> dt = objData.GetListForSelect(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
        
        #endregion
    }
}
