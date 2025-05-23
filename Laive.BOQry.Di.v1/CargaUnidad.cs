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
   public interface ICargaUnidad
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetCamionCerrado<T>(IEntityBase value) where T : new();

      /// <summary>
      /// Comprueba si existe un camion con el mismo turno box
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un bool</returns>
      [OperationContract()]
      [NetDataContract()]
      bool ExistsTurnoBoxFrio(IEntityBase value);

      /// <summary>
      /// Comprueba si existe un camion con el mismo turno box
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un bool</returns>
      [OperationContract()]
      [NetDataContract()]
      bool ExistsTurnoBoxSeco(IEntityBase value);

   }

   /// <summary>
   /// Business Object para Consultas a la Tabla: DI_CargaUnidad (DI_CargaUnidad)
   /// </summary>
   public class CargaUnidad : BusinessObjectBase, IBOQuery, ICargaUnidad
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new DIDOQry.CargaUnidad();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.CargaUnidad();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.CargaUnidad();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.CargaUnidad();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.CargaUnidad();

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

      public ICollection<T> GetCamionCerrado<T>(IEntityBase value) where T : new()
      {

         DIDOQry.CargaUnidad objData = new DIDOQry.CargaUnidad();

         try
         {

            ICollection<T> dt = objData.GetCamionCerrado<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public bool ExistsTurnoBoxFrio(IEntityBase value)
      {

          DIDOQry.CargaUnidad objData = new DIDOQry.CargaUnidad();

          try
          {

              bool blnRes = objData.ExistsTurnoBoxFrio(value);

              return blnRes;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }

      public bool ExistsTurnoBoxSeco(IEntityBase value)
      {

          DIDOQry.CargaUnidad objData = new DIDOQry.CargaUnidad();

          try
          {

              bool blnRes = objData.ExistsTurnoBoxSeco(value);

              return blnRes;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }
   }
}
