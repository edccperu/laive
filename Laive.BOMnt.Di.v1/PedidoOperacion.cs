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
    public interface IPedidoOperacion
    {
        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        int UpdateStpo(EPedidoOperacion ObjE);

        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        int UpdateStpoApertura(EPedidoOperacion ObjE);

        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        int UpdateMarcarSelec(List<EPedidoOperacion> list);

        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        int ImportarOrdenVenta(EAlmacen ObjE);


        /// <summary>
        /// Sirve la dicir una linea en Sublineas.
        /// </summary>
        /// <param name="value">Lista de EpedidoOperacion</param>
        /// <returns>Retorna un int</returns>
        [OperationContract()]
        [NetDataContract()]
        int DividirLinea(List<EPedidoOperacion> objList);

        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        int RetirarPedidoConsolidado(EOrdenVenta ObjE);
    }
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: DI_PedidoOperacion (DI_PedidoOperacion)
    /// </summary>
    public class PedidoOperacion : BusinessObjectBase, IBOUpdate,IPedidoOperacion
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

        public int UpdateStpo(EPedidoOperacion ObjE)
        {
            int result;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                    result = objDO.UpdateStpo(ObjE);
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int UpdateStpoApertura(EPedidoOperacion ObjE)
        {
           int result;
           try
           {

              using (TransactionScope tx = new TransactionScope())
              {
                 DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                 result = objDO.UpdateStpoApertura(ObjE);
                 tx.Complete();
              }

              return result;
           }
           catch (Exception ex)
           {

              throw ex;

           }
        }


        public int UpdateMarcarSelec(List<EPedidoOperacion> list)
        {
            int result = 0;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                    foreach (EPedidoOperacion objE in list) {
                        result += objDO.UpdateStpo(objE);
                    }
                            
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int ImportarOrdenVenta(EAlmacen ObjE)
        {

            int result;
            try
            {

                //using (TransactionScope tx = new TransactionScope())
                //{
                    DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                    result = objDO.ImportarBaanOpe01(ObjE);
                    result += objDO.ImportarBaanOpe02(ObjE);
                //    tx.Complete();
                //}

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DividirLinea(List<EPedidoOperacion> objList)
        {

            int result = 0;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {
                    DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                    foreach (EPedidoOperacion objE in objList) {
                        if (objE.IsLineaPadre)
                            result = objDO.DLUpdateEstado(objE);
                        else
                            result = objDO.DLCreateSubLinea(objE);
            
                    }
                    tx.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int RetirarPedidoConsolidado(EOrdenVenta ObjE)
        {
           int result;
           try
           {

              using (TransactionScope tx = new TransactionScope())
              {
                 DIDOMnt.PedidoOperacion objDO = new DIDOMnt.PedidoOperacion();
                 result = objDO.RetirarPedidoConsolidado(ObjE);
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
