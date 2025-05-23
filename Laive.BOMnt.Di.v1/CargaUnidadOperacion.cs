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
using System.ServiceModel;

namespace Laive.BOMnt.Di
{
    /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
    [ServiceContract()]
    public interface ICargaUnidadOperacion
    {
        /// <summary>
        /// Obtiene un Cargar Mercaderia
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int CargarCamion(ECargaUnidad value);

        /// <summary>
        /// Obtiene un Cargar Mercaderia
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int RetirarCamion(int idCargaUnidad);

        /// <summary>
        /// Obtiene un Cerrar Mercaderia
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int CerrarCamion(int idCargaUnidad);

        /// <summary>
        /// Obtiene un Abrir Camion
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int OpenCamion(int idCargaUnidad);

        /// <summary>
        /// regresa la percaderia cargada a un cambion por codigo de cargaunidad y partner
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int RetirarCaXPartner(int idCargaUnidad, string codigoPartner);

        /// <summary>
        /// regresa la percaderia cargada a un cambion por codigo de cargaunidad y partner
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int RetirarCaXFrio(int idCargaUnidad, string orden, int linea, int sublinea);

        /// <summary>
        /// regresa la percaderia cargada a un cambion por codigo de cargaunidad y partner
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int RetirarCaXFrioPorOrden(int idCargaUnidad, string orden);


    }
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: DI_CargaUnidadOperacion (DI_CargaUnidadOperacion)
    /// </summary>
    public class CargaUnidadOperacion : BusinessObjectBase, IBOUpdate, ICargaUnidadOperacion
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        public int DeleteData(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        #endregion

        public int CargarCamion(ECargaUnidad value)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.CargarCamion(value);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetirarCamion(int idCargaUnidad)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.RetirarCamion(idCargaUnidad);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int CerrarCamion(int idCargaUnidad)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.CerrarCamion(idCargaUnidad);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int OpenCamion(int idCargaUnidad)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.OpenCamion(idCargaUnidad);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetirarCaXPartner(int idCargaUnidad,string codigoPartner)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.RetirarCaXPartner(idCargaUnidad, codigoPartner);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetirarCaXFrio(int idCargaUnidad, string orden, int linea, int sublinea)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.RetirarCaXFrio(idCargaUnidad, orden, linea, sublinea);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetirarCaXFrioPorOrden(int idCargaUnidad, string orden)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.CargaUnidadOperacion objDO = new DIDOMnt.CargaUnidadOperacion();
                    result = objDO.RetirarCaXFrioPorOrden(idCargaUnidad,orden);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
    }
}
