using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using SamNet.Core.Data;
using MGDOQry = SamNet.DOQry.Mg;
using System.Collections.Generic;
using SamNet.Core.Common;

namespace SamNet.BOQry.Mg
{
    /// <summary>
    /// Business Object para Consultas a la Tabla: MG_BienServicio (MG_BienServicio)
    /// </summary>
    public class BienServicio : BusinessObjectBase, IBOQuery
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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

        public ICollection<T> GetByParentKey<T>(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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

        public ICollection<T> GetList<T>(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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
        
        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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
        public bool Exists(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new MGDOQry.BienServicio();

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

        #endregion

    }
}
