using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using DIDOQry = Laive.DOQry.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Di
{
    /// <summary>
    /// Business Object para Consultas a la Tabla: DI_Ruta (DI_Ruta)
    /// </summary>
    public class Turno : BusinessObjectBase, IBOQuery
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {
            IDOQuery objData = (IDOQuery)new DIDOQry.Turno();

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
            throw new NotImplementedException();
        }

        public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {
            throw new NotImplementedException();
        }

        public bool Exists(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new DIDOQry.Turno();

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
