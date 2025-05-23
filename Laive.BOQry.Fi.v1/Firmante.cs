using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using FIDOQry = Laive.DOQry.Fi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Fi
{
   /// <summary>
   /// Interfaz para Consultas a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   /// <remarks></remarks>
   [ServiceContract()]
   public interface IFirmante
   {

      /// <summary>
      /// Obtiene Registros de los cheques con inconsistencia (Opcion Importacion del Menu)
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      IEntityBase GetByLogin(IEntityBase value);

      /// <summary>
      /// Obtiene Registros de los Firmantes por Poder.
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetFirmantesXPoder<T>(IEntityBase value) where T : new();
   }

   /// <summary>
   /// Business Object para Consultas a la Tabla: FI_Firmante (FI_Firmante)
   /// </summary>
   public class Firmante : BusinessObjectBase, IBOQuery, IFirmante
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

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

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

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

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

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

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

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

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

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

         IDOQuery objData = (IDOQuery)new FIDOQry.Firmante();

         try
         {

            ICollection<EntitySelect> dt = objData.GetListForSelect(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      #endregion

      public IEntityBase GetByLogin(IEntityBase value)
      {

         FIDOQry.Firmante objData = new FIDOQry.Firmante();

         try
         {

            IEntityBase objE = objData.GetByLogin(value);

            return objE;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetFirmantesXPoder<T>(IEntityBase value) where T : new()
      {

         FIDOQry.Firmante objData = new FIDOQry.Firmante();

         try
         {

            ICollection<T> dt = objData.GetFirmantesXPoder<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }
   }
}
