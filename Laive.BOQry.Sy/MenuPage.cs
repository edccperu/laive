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
    public interface IMenuPage
    {
        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetListXidRol<T>(int value) where T : new();

        /// <summary>
        /// Obtiene lista para el menu
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetListXForMenu<T>(string value) where T : new();

        /// <summary>
        /// Obtiene de valor de numero de registros segun menu
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetListNumRegMenu<T>(string value) where T : new();

    }


    /// <summary>
    /// Business Object para Consultas a la Tabla: SY_MenuPage (SY_MenuPage)
    /// </summary>
    public class MenuPage : BusinessObjectBase, IBOQuery, IMenuPage
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

            IDOQuery objData = (IDOQuery)new SYDOQry.MenuPage();

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

        #region IMenuPage Members

        public ICollection<T> GetListXidRol<T>(int value) where T : new()
        {

            SYDOQry.MenuPage objData = new SYDOQry.MenuPage();

            try
            {

               ICollection<T> dt = objData.GetListXidRol<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> GetListXForMenu<T>(string value) where T : new()
        {

            SYDOQry.MenuPage objData = new SYDOQry.MenuPage();

            try
            {

                ICollection<T> dt = objData.GetListXForMenu<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> GetListNumRegMenu<T>(string value) where T : new()
        {

           SYDOQry.MenuPage objData = new SYDOQry.MenuPage();

           try
           {

              ICollection<T> dt = objData.GetListNumRegMenu<T>(value);

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
