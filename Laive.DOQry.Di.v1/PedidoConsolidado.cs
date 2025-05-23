using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Di
{
    /// <summary>
    /// Data Object para Consultas a la Tabla: CO_PedidoConsolidado (CO_PedidoConsolidado)
    /// </summary>
    /// <remarks></remarks>
    public class PedidoConsolidado : DataObjectBase, IDOQuery
    {
        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            EPedidoConsolidado objE = (EPedidoConsolidado)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, objE.IdRuta));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, objE.CodigoPartner));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoConsolidado_qry01", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public IEntityBase GetByKey(IEntityBase value)
        {

            throw new NotImplementedException();
        }

        public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
        {

            throw new NotImplementedException();
        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {
            throw new NotImplementedException();
        }

        public bool Exists(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        private ArrayList BuildParamInterface(EPedidoConsolidado value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));
            arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char, 9, value.CodigoPartner));

            return arrPrm;

        }

        #endregion

        public ICollection<T> CamConsoXIdCargaUnidad<T>(int idCargaUnidad) where T : new()
        {
            
            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, idCargaUnidad));
                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_PedidoConsolidado_qry06", arrPrm);

                return dt;
            }
            catch (Exception ex)
            {
                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;
            }
        }


    }
}
