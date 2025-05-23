using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Fi;
using Laive.Core.Common;
using FIDOMnt = Laive.DOMnt.Fi;
using System.ServiceModel;


namespace Laive.BOMnt.Fi
{   
    /// <summary>
   /// Interface para Consultas personalizadas
   /// </summary>
   [ServiceContract()]
   public interface IDELotePago
   {
       [OperationContract()]
       [NetDataContract()]
       int UpdateImportarLotePago(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateTraBaanLotPago(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateConcilacionPago(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateConcilacionPagoComprobante(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateGenerarPagoSunat(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateLotePago(IEntityBase value);

       [OperationContract()]
       [NetDataContract()]
       int UpdateComprobanteProveedor(IEntityBase value);

   }
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: FI_DELotePago (FI_DELotePago)
    /// </summary>
   public class DELotePago : BusinessObjectBase, IBOUpdate, IDELotePago
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            throw new NotImplementedException();
        }

        public int DeleteData(IEntityBase value)
        {
            IDOUpdate objDO = new FIDOMnt.DELotePago();

            int intRes = objDO.Delete(value);
            return intRes;
        }

        #endregion

        private object[] UpdateMaster(EDELotePago entity)
        {

            IDOUpdate objDO = new FIDOMnt.DELotePago();

            if (entity.EntityState == EntityState.Unchanged)
                return null;

            object[] objRet = null;

            switch (entity.EntityState)
            {

                case EntityState.Added:
                    objRet = objDO.Insert(entity);
                    break;

                case EntityState.Modified:
                    objDO.Update(entity);
                    break;

                case EntityState.Deleted:
                    objDO.Delete(entity);
                    break;

            }

            return objRet;
        }

        private void UpdateDetail(IList<EDELotePago> col, object[] primKey)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new FIDOMnt.DELotePago();

            foreach (EDELotePago objE in col)
            {

                object[] objRet = null;

               
                switch (objE.EntityState)
                {

                    case EntityState.Added:
                        objRet = objDO.Insert(objE);
                        break;

                    case EntityState.Modified:
                        objDO.Update(objE);
                        break;

                }

            }

        }   

    

        private void DeleteMaster(EDELotePago entity)
        {

            IDOUpdate objDO = new FIDOMnt.DELotePago();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<EDELotePago> col, bool filterModified)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new FIDOMnt.DELotePago();
            IEnumerable<EDELotePago> colSel = null;

            if (filterModified)
            {
                var deleteItems = from itm in col
                                  where itm.EntityState == EntityState.Deleted
                                  select itm;

                colSel = (IEnumerable<EDELotePago>)deleteItems;
            }
            else
            {
                var deleteItems = from itm in col
                                  select itm;

                colSel = (IEnumerable<EDELotePago>)deleteItems;
            }
            foreach (EDELotePago objE in colSel)
                objDO.Delete(objE);

        }

       public int UpdateGenerarPagoSunat(IEntityBase value)
        {
            int result;
            try
            {
                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateGenerarPagoSunat(value);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public int UpdateConcilacionPago(IEntityBase value)
        {
            int result;
            try
            {
                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateConcilacionPago(value);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int UpdateConcilacionPagoComprobante(IEntityBase value)
        {
            int result;
            try
            {
                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateConcilacionPagoComprobante(value);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
       
       
        public int UpdateComprobanteProveedor(IEntityBase value)
        {

            int result;
            try
            {
                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateComprobanteProveedor(value);
                return result;

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
       
       public int UpdateLotePago(IEntityBase value)
        {

            int result;
            try
            {
                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateLotePago(value);
                return result;

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int UpdateImportarLotePago(IEntityBase value)
        {

            int result;
            try
            {

                //using (TransactionScope tx = new TransactionScope())
                //{
                //    FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                //    result = objDO.UpdateImportarLotePago(value);
                //    tx.Complete();
                //}
           
                    FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                    result = objDO.UpdateImportarLotePago(value);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int UpdateTraBaanLotPago(IEntityBase value)
        {

            int result;
            try
            {

                //using (TransactionScope tx = new TransactionScope())
                //{
                //    FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                //    result = objDO.UpdateImportarLotePago(value);
                //    tx.Complete();
                //}

                FIDOMnt.DELotePago objDO = new FIDOMnt.DELotePago();
                result = objDO.UpdateTraBaanLotPago(value);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

    }

}
