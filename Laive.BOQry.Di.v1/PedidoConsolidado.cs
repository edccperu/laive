using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using CODOQry = Laive.DOQry.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Di
{
    /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
    [ServiceContract()]
    public interface IPedidoConsolidado
    {
        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> CamConsoXIdCargaUnidad<T>(int idCargaUnidad) where T : new();

    }
    /// <summary>
    /// Business Object para Consultas a la Tabla: CO_PedidoConsolidado (CO_PedidoConsolidado)
    /// </summary>
    public class PedidoConsolidado : BusinessObjectBase, IBOQuery, IPedidoConsolidado
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new CODOQry.PedidoConsolidado();

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

            IDOQuery objData = (IDOQuery)new CODOQry.PedidoConsolidado();

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

            IDOQuery objData = (IDOQuery)new CODOQry.PedidoConsolidado();

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

            IDOQuery objData = (IDOQuery)new CODOQry.PedidoConsolidado();

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

            IDOQuery objData = (IDOQuery)new CODOQry.PedidoConsolidado();

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

                throw new NotImplementedException();

        }

        #endregion


        public ICollection<T> CamConsoXIdCargaUnidad<T>(int idCargaUnidad) where T : new()
        {

            CODOQry.PedidoConsolidado objData = new CODOQry.PedidoConsolidado();

            try
            {

                ICollection<T> dt = objData.CamConsoXIdCargaUnidad<T>(idCargaUnidad);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

    }
}
