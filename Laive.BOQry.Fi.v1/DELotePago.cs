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

     [ServiceContract()]
    public interface IDeLotePago
    {
         [OperationContract()]
         [NetDataContract()]
         bool ExistsTrabaan(IEntityBase value);

         [OperationContract()]
         [NetDataContract()]
         bool ExistsIdLotePago(IEntityBase value);

         [OperationContract()]
         [NetDataContract()]
         bool ExistsCuentaCaja(IEntityBase value);

         [OperationContract()]
         [NetDataContract()]
         bool ExistsCuentaIgv(IEntityBase value);

         [OperationContract()]
         [NetDataContract()]
         IEntityBase GetByEjercicioLote(IEntityBase value);

         [OperationContract()]
         [NetDataContract()]
         ICollection<T> GetDetraccionPagadosPartner<T>(IEntityBase value) where T : new();

         [OperationContract()]
         [NetDataContract()]
         ICollection<T> GetDetraccionComprobantesProveedor<T>(IEntityBase value) where T : new();

         [OperationContract()]
         [NetDataContract()]
         ICollection<T> GetLotePagoPartnerCuentaBan<T>(IEntityBase value) where T : new();
    }

    /// <summary>
    /// Business Object para Consultas a la Tabla: FI_DELotePago (FI_DELotePago)
    /// </summary>

    public class DELotePago : BusinessObjectBase, IBOQuery,IDeLotePago
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

        public ICollection<T> GetLotePagoPartnerCuentaBan<T>(IEntityBase value) where T : new()
        {

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            try
            {
                ICollection<T> dt = objData.GetLotePagoPartnerCuentaBan<T>(value);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ICollection<T> GetDetraccionPagadosPartner<T>(IEntityBase value) where T : new()
        {

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            try
            {
                ICollection<T> dt = objData.GetDetraccionPagadosPartner<T>(value);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ICollection<T> GetDetraccionComprobantesProveedor<T>(IEntityBase value) where T : new()
        {

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            try
            {
                ICollection<T> dt = objData.GetDetraccionComprobantesProveedor<T>(value);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool ExistsTrabaan(IEntityBase value)
        {
           

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            //IDeLotePago objData = (IDeLotePago)new FIDOQry.DELotePago();

            try
            {

                bool blnRes = objData.ExistsTrabaan(value);

                return blnRes;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }


        public bool ExistsCuentaCaja(IEntityBase value)
        {


            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            //IDeLotePago objData = (IDeLotePago)new FIDOQry.DELotePago();

            try
            {

                bool blnRes = objData.ExistsCuentaCaja(value);

                return blnRes;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public bool ExistsCuentaIgv(IEntityBase value)
        {


            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            //IDeLotePago objData = (IDeLotePago)new FIDOQry.DELotePago();

            try
            {

                bool blnRes = objData.ExistsCuentaIgv(value);

                return blnRes;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public bool ExistsIdLotePago(IEntityBase value)
        {

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();
            //IDeLotePago objData = (IDeLotePago)new FIDOQry.DELotePago();

            try
            {

                bool blnRes = objData.ExistsIdLotePago(value);

                return blnRes;

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public bool Exists(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

            IDOQuery objData = (IDOQuery)new FIDOQry.DELotePago();

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

        #region IDELotePago
        public IEntityBase GetByEjercicioLote(IEntityBase value)
        {

            FIDOQry.DELotePago objData = new FIDOQry.DELotePago();

            try
            {

                IEntityBase objE = objData.GetByEjercicioLote(value);

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
