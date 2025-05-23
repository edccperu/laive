using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using SYDOQry = Laive.DOQry.Sy;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Sy
{

    /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
    [ServiceContract()]
    public interface IUsuario
    {
        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        IEntityBase GetByKeyXIdLogon(IEntityBase value);

    }


    /// <summary>
    /// Business Object para Consultas a la Tabla: SY_Usuario (SY_Usuario)
    /// </summary>
    public class Usuario : BusinessObjectBase, IBOQuery, IUsuario
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.Usuario();

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

        #region IUsario Members


        public IEntityBase GetByKeyXIdLogon(IEntityBase value)
        {

            SYDOQry.Usuario objData = new SYDOQry.Usuario();

            try
            {

                IEntityBase objE = objData.GetByKeyXIdLogon(value);

                return objE;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }





        #endregion
    }
}
