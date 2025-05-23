using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Co;
using Laive.Core.Common;
using CODOMnt = Laive.DOMnt.Co;
using System.ServiceModel;

namespace Laive.BOMnt.Co
{

    /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
    [ServiceContract()]
    public interface IKardexAuto
    {

        /// <summary>
        /// Actualización de recalculo de valores mauc unitario y saldos
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        void UpdateValues(ICollection<EKardexAuto> value);

    }
    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: CO_KardexAuto (CO_KardexAuto)
    /// </summary>
    public class KardexAuto : BusinessObjectBase, IBOUpdate, IKardexAuto
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            EKardexAutoSet objE = (EKardexAutoSet)value;
            object[] objRet = null;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    this.UpdateMaster(objE.listKardex);

                    tx.Complete();

                }

                if (objRet == null)
                    return null;

                return new String[] { objRet[0].ToString() };

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public int DeleteData(IEntityBase value)
        {

            EKardexAutoSet objE = (EKardexAutoSet)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE.EKardexAuto, false);
                    //this.DeleteMaster(objE.EKardexAuto);

                    tx.Complete();

                }

                return 1;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        #endregion

        private void UpdateMaster(ICollection<EKardexAuto> col)
        {
            if (col == null)
                return;

            IDOUpdate objDO = new CODOMnt.KardexAuto();

            foreach (EKardexAuto objE in col)
            {
                objDO.Update(objE);
            }

        }

        public void UpdateValues(ICollection<EKardexAuto> col)
        {
            if (col == null && col.Count > 0)
                return;
            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    CODOMnt.KardexAuto objDO = new CODOMnt.KardexAuto();

                    foreach (EKardexAuto objE in col)
                    {

                        switch (objE.TipoOperacion)
                        {
                            case ConstTipoMovimiento.EGRESO:
                                objE.Cantidad = objE.CantidadEgreso;
                                objE.Unitario = objE.UnitarioEgreso;
                                objE.Costo = objE.CostoEgreso;
                                break;
                            case ConstTipoMovimiento.INGRESO:
                                objE.Cantidad = objE.CantidadIngreso ;
                                objE.Unitario = objE.UnitarioIngreso ;
                                objE.Costo = objE.CostoIngreso ;
                                break;
                        }

                        objDO.UpdateValues(objE);
                    }

                    tx.Complete();

                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        private void DeleteMaster(EKardexAuto entity)
        {

            IDOUpdate objDO = new CODOMnt.KardexAuto();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

    }
}
