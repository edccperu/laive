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
    /// Data Object para Consultas a la Tabla: DI_Ruta (DI_Ruta)
    /// </summary>
    /// <remarks></remarks>
    public class Almacen : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {
            EAlmacen objE = (EAlmacen)value;

            try
            {

                ArrayList arrPrm = new ArrayList();

                arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_Almacen_qry01", arrPrm);

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

        public ICollection<T> GetList<T>(IEntityBase value) where T : new()
        {
            EAlmacen objE = (EAlmacen)value;

            try
            {

                ArrayList arrPrm = new ArrayList();
                ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_Almacen_qry04", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }

        public bool Exists(IEntityBase value)
        {
            throw new NotImplementedException();

        }

        private ArrayList BuildParamInterface(EAlmacen value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoAlmacen", SqlDbType.Char, 6, value.CodigoAlmacen));

            return arrPrm;

        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            throw new NotImplementedException();
        }


        #endregion

    }
}
