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
    public class CargaUnidadOperacion : DataObjectBase
    {
        public ICollection<T> CaUnidOpeXUnidadXPartner<T>(IEntityBase value) where T : new()
        {
            ECargaUnidadOperacion objE = (ECargaUnidadOperacion)value;

            try
            {
                ArrayList arrPrm = new ArrayList();
                arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
                arrPrm.Add(DataHelper.CreateParameter("@pcodigoPartner", SqlDbType.Char,9, objE.CodigoPartner));
                arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char,1, objE.TipoCarga));
                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_CargaUnidadOperacion_qry06", arrPrm);

                return dt;
            }
            catch (Exception ex)
            {
                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;
            }
        }

        public ICollection<T> GetBuscarCliente<T>(IEntityBase value) where T : new()
        {
           ECargaUnidad objE = (ECargaUnidad)value;

           try
           {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pfechaPrograma", SqlDbType.Date, objE.FechaPrograma));
              arrPrm.Add(DataHelper.CreateParameter("@pEntityFilter", SqlDbType.VarChar, 200, objE.EntityFilter));
              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_CargaUnidadOperacion_qry07", arrPrm);

              return dt;
           }
           catch (Exception ex)
           {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
           }
        }

        public ICollection<T> GetFacturasXCargaUnidad<T>(IEntityBase value) where T : new()
        {
           ECargaUnidadFactura objE = (ECargaUnidadFactura)value;

           try
           {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_CargaUnidadOperacion_qry08", arrPrm);

              return dt;
           }
           catch (Exception ex)
           {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
           }
        }

        public ICollection<T> GetSFacturasXCargaUnidad<T>(IEntityBase value) where T : new()
        {
           ECargaUnidadFactura objE = (ECargaUnidadFactura)value;

           try
           {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_CargaUnidadOperacion_qry09", arrPrm);

              return dt;
           }
           catch (Exception ex)
           {
              ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
              throw objEx;
           }
        }

        public ICollection<T> GetOrdenesWMS<T>(IEntityBase value) where T : new()
        {
           ECargaUnidadFactura objE = (ECargaUnidadFactura)value;

           try
           {
              ArrayList arrPrm = new ArrayList();
              arrPrm.Add(DataHelper.CreateParameter("@pidCargaUnidad", SqlDbType.Int, objE.IdCargaUnidad));
              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_CargaUnidadOperacion_qry10", arrPrm);

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
