using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using FIDOQry = Laive.DOQry.Fi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Fi
{

    /// <summary>
    /// Interfaz para Consultas a la Tabla: DEPagoComprobante 
    /// </summary> 
    /// <remarks></remarks>
    [ServiceContract()]
    public interface IDEPagoComprobante
    {

        /// <summary>
        /// Obtiene Registros de los comprobantes de detraccion para su consiliación
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un ICollection</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetComprobanteDetraForConsiliacion<T>(IEntityBase value) where T : new();

        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetComprobanteDetraForConsiliacionMonto<T>(IEntityBase value) where T : new();


    }



    /// <summary>
    /// Business Object para Consultas a la Tabla: FI_DEPagoComprobante (FI_DEPagoComprobante)
    /// </summary>
    public class DEPagoComprobante : BusinessObjectBase, IBOQuery, IDEPagoComprobante
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DEPagoComprobante();

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


        #region IDEPagoComprobante

        public ICollection<T> GetComprobanteDetraForConsiliacion<T>(IEntityBase value) where T : new()
        {

            FIDOQry.DEPagoComprobante objData = new FIDOQry.DEPagoComprobante();

            try
            {

                ICollection<T> dt = objData.GetComprobanteDetraForConsiliacion<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> GetComprobanteDetraForConsiliacionMonto<T>(IEntityBase value) where T : new()
        {

            FIDOQry.DEPagoComprobante objData = new FIDOQry.DEPagoComprobante();

            try
            {

                ICollection<T> dt = objData.GetComprobanteDetraForConsiliacionMonto<T>(value);

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
