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
   /// <summary>
   /// Interface para Consultas personalizadas
   /// </summary>
   [ServiceContract()]
   public interface IPedidoOperacion
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      IEntityBase GetTotalesByIdUser(IEntityBase value);

      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetApertura<T>(IEntityBase value) where T : new();
   }

   /// <summary>
   /// Business Object para Consultas a la Tabla: DI_PedidoOperacion (DI_PedidoOperacion)
   /// </summary>
   public class PedidoOperacion : BusinessObjectBase, IBOQuery, IPedidoOperacion
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new DIDOQry.PedidoOperacion();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.PedidoOperacion();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.PedidoOperacion();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.PedidoOperacion();

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

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         throw new NotImplementedException();

      }

      public bool Exists(IEntityBase value)
      {

         IDOQuery objData = (IDOQuery)new DIDOQry.PedidoOperacion();

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



      #endregion

      public IEntityBase GetTotalesByIdUser(IEntityBase value)
      {

         DIDOQry.PedidoOperacion objData = new DIDOQry.PedidoOperacion();

         try
         {

            IEntityBase objE = objData.GetTotalesByIdUser(value);

            return objE;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetApertura<T>(IEntityBase value) where T : new()
      {

         DIDOQry.PedidoOperacion objData = new DIDOQry.PedidoOperacion();

         try
         {

            ICollection<T> dt = objData.GetApertura<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


   }
}
