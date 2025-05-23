using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using DIDOQry = Laive.DOQry.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Di
{


   [ServiceContract()]
   public interface IChofer
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      IEntityBase GetByClaveChofer(IEntityBase value);
   }


   /// <summary>
   /// Business Object para Consultas a la Tabla: DI_Chofer (DI_Chofer)
   /// </summary>
   public class Chofer : BusinessObjectBase, IBOQuery, IChofer
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new DIDOQry.Chofer();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.Chofer();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.Chofer();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.Chofer();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.Chofer();

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

      #region IChofer
      public IEntityBase GetByClaveChofer(IEntityBase value)
      {

         DIDOQry.Chofer objData = new DIDOQry.Chofer();

         try
         {

            IEntityBase objE = objData.GetByClaveChofer(value);

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
