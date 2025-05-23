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
    public interface ICargaUnidadOperacion
    {
        /// <summary>
        /// Lista el detalle de los camiones cargados por camion y por partner
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> CaUnidOpeXUnidadXPartner<T>(IEntityBase value) where T : new();

        /// <summary>
        /// Busca un Cliente en un camion cargado.
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetBuscarCliente<T>(IEntityBase value) where T : new();

        /// <summary>
        /// Lista las facturas de un Camion cerrado.
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetFacturasXCargaUnidad<T>(IEntityBase value) where T : new();

        /// <summary>
        /// Lista las facturas de un Camion cerrado.
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetSFacturasXCargaUnidad<T>(IEntityBase value) where T : new();
       

       /// <summary>
        /// Lista Ordenes WMS
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> GetOrdenesWMS<T>(IEntityBase value) where T : new();
    }
    /// <summary>
    /// Business Object para Consultas a la Tabla: CO_PedidoConsolidado (CO_PedidoConsolidado)
    /// </summary>
    public class CargaUnidadOperacion : BusinessObjectBase, ICargaUnidadOperacion
    {

        public ICollection<T> CaUnidOpeXUnidadXPartner<T>(IEntityBase value) where T : new()
        {

            CODOQry.CargaUnidadOperacion objData = new CODOQry.CargaUnidadOperacion();

            try
            {

                ICollection<T> dt = objData.CaUnidOpeXUnidadXPartner<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
        public ICollection<T> GetBuscarCliente<T>(IEntityBase value) where T : new()
        {

           CODOQry.CargaUnidadOperacion objData = new CODOQry.CargaUnidadOperacion();

           try
           {

              ICollection<T> dt = objData.GetBuscarCliente<T>(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }
        public ICollection<T> GetFacturasXCargaUnidad<T>(IEntityBase value) where T : new()
        {

           CODOQry.CargaUnidadOperacion objData = new CODOQry.CargaUnidadOperacion();

           try
           {

              ICollection<T> dt = objData.GetFacturasXCargaUnidad<T>(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }
        public ICollection<T> GetSFacturasXCargaUnidad<T>(IEntityBase value) where T : new()
        {

           CODOQry.CargaUnidadOperacion objData = new CODOQry.CargaUnidadOperacion();

           try
           {

              ICollection<T> dt = objData.GetSFacturasXCargaUnidad<T>(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }

        public ICollection<T> GetOrdenesWMS<T>(IEntityBase value) where T : new()
        {

           CODOQry.CargaUnidadOperacion objData = new CODOQry.CargaUnidadOperacion();

           try
           {

              ICollection<T> dt = objData.GetOrdenesWMS<T>(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }

    }
}
