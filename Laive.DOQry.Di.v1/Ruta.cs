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
    public class Ruta : DataObjectBase, IDOQuery
    {

        #region IDOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {
           ERuta objE = (ERuta)value;

           try
           {

              ArrayList arrPrm = new ArrayList();

              arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

              ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_Ruta_qry01", arrPrm);

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
            throw new NotImplementedException();
        }

        public bool Exists(IEntityBase value)
        {
            throw new NotImplementedException();
        }

        private ArrayList BuildParamInterface(ERuta value)
        {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pidRuta", SqlDbType.Int, value.IdRuta));

            return arrPrm;

        }

        public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
        {

            ERuta objE = (ERuta)value;

            try
            {

                ArrayList arrPrm = BuildParamInterface(objE);

                ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_Ruta_qry06", arrPrm);

                return dt;

            }
            catch (Exception ex)
            {

                ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
                throw objEx;

            }
        }


        #endregion

    }
}
