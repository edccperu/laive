using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using SamNet.Core.Data;
using SamNet.Entity.Mg;
using SamNet.Core.Common;
using MGDOMnt = SamNet.DOMnt.Mg;
using System.ServiceModel;

namespace SamNet.BOMnt.Mg
{

    /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
    [ServiceContract()]
    public interface IBienServicio
    {
        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un collection de clases</returns>
        [OperationContract()]
        [NetDataContract()]
        int UpdateState(string value,bool state);

    }

    /// <summary>
    /// Business Object para Mantenimiento a la Tabla: MG_BienServicio (MG_BienServicio)
    /// </summary>
    public class BienServicio : BusinessObjectBase, IBOUpdate,IBienServicio
    {

        #region IBOUpdate Members

        public string[] UpdateData(IEntityBase value)
        {

            EBienServicio objE = (EBienServicio)value;
            object[] objRet = null;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE, true);

                    //objRet = this.UpdateMaster(objE.EBienServicio);
                    //this.UpdateDetail(objE.EBienServicio, objRet);

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

            EBienServicio objE = (EBienServicio)value;

            try
            {

                using (TransactionScope tx = new TransactionScope())
                {

                    //this.DeleteDetail(objE.EBienServicio, false);
                    //this.DeleteMaster(objE.EBienServicio);

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

        #region IBienServicio Members

        public int UpdateState(string IdBien,bool state)
        {
            MGDOMnt.BienServicio objDO = new MGDOMnt.BienServicio();
            return objDO.UpdateState(IdBien,state);
        }

        #endregion

        private object[] UpdateMaster(EBienServicio entity)
        {

            IDOUpdate objDO = new MGDOMnt.BienServicio();

            if (entity.EntityState == EntityState.Unchanged)
                return null;

            object[] objRet = null;

            switch (entity.EntityState)
            {

                case EntityState.Added:
                    objRet = objDO.Insert(entity);
                    break;

                case EntityState.Modified:
                    if (entity.StAnulado == ConstFlagEstado.DESACTIVADO)
                        objDO.Update(entity);
                    else
                        objDO.Delete(entity);
                    break;

                case EntityState.Deleted:
                    objDO.Delete(entity);
                    break;

            }

            return objRet;
        }

        private void UpdateDetail(IList<EBienServicio> col, object[] primKey)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new MGDOMnt.BienServicio();

            foreach (EBienServicio objE in col)
            {

                object[] objRet = null;

                if (primKey != null)
                {
                    objE.IdBien = primKey[0].ToString();
                }

                switch (objE.EntityState)
                {

                    case EntityState.Added:
                        objRet = objDO.Insert(objE);
                        break;

                    case EntityState.Modified:
                        if (objE.StAnulado == ConstFlagEstado.DESACTIVADO)
                            objDO.Update(objE);
                        else
                            objDO.Delete(objE);
                        break;

                }

            }

        }

        private void DeleteMaster(EBienServicio entity)
        {

            IDOUpdate objDO = new MGDOMnt.BienServicio();

            if (entity.EntityState == EntityState.Unchanged)
                return;

            objDO.Delete(entity);

        }

        private void DeleteDetail(IList<EBienServicio> col, bool filterModified)
        {

            if (col == null)
                return;

            IDOUpdate objDO = new MGDOMnt.BienServicio();
            IEnumerable<EBienServicio> colSel = null;

            if (filterModified)
            {
                var deleteItems = from itm in col
                                  where itm.EntityState == EntityState.Deleted
                                  select itm;

                colSel = (IEnumerable<EBienServicio>)deleteItems;
            }
            else
            {
                var deleteItems = from itm in col
                                  select itm;

                colSel = (IEnumerable<EBienServicio>)deleteItems;
            }
            foreach (EBienServicio objE in colSel)
                objDO.Delete(objE);

        }

       
    }
}
