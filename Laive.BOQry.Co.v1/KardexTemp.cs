using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using CODOQry = Laive.DOQry.Co;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Co
{


    [ServiceContract()]
    public interface IKardexTemp
    {

        /// <summary>
        /// Obtiene un registro por idLogon
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> ImportarKardex<T>(IEntityBase value) where T : new();

        /// <summary>
        /// Importa datos de Kardex DCA
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns>Retorna un DataTable</returns>
        [OperationContract()]
        [NetDataContract()]
        ICollection<T> ImportarKardexDCA<T>(IEntityBase value) where T : new();
        
    }
    /// <summary>
    /// Business Object para Consultas a la Tabla: CO_KardexTemp (CO_KardexTemp)
    /// </summary>
    public class KardexTemp : BusinessObjectBase, IBOQuery,IKardexTemp
    {

        #region IBOQuery Members

        public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
        {

            IDOQuery objData = (IDOQuery)new CODOQry.KardexTemp();

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

            IDOQuery objData = (IDOQuery)new CODOQry.KardexTemp();

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

            IDOQuery objData = (IDOQuery)new CODOQry.KardexTemp();

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

            IDOQuery objData = (IDOQuery)new CODOQry.KardexTemp();

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

        public bool Exists(IEntityBase value)
        {

            IDOQuery objData = (IDOQuery)new CODOQry.KardexTemp();

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

            throw new NotImplementedException();

        }

        #endregion

        public ICollection<T> ImportarKardex<T>(IEntityBase value) where T : new()
        {

            CODOQry.KardexTemp objData = new CODOQry.KardexTemp();

            try
            {

                ICollection<T> dt= objData.ImportarKardex<T>(value);

                return dt;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public ICollection<T> ImportarKardexDCA<T>(IEntityBase value) where T : new()
        {

           CODOQry.KardexTemp objData = new CODOQry.KardexTemp();

           try
           {

              ICollection<T> dt = objData.ImportarKardexDCA<T>(value);

              return dt;

           }
           catch (Exception ex)
           {

              throw ex;

           }

        }
    }
}
