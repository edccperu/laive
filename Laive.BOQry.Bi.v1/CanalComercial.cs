using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using BIDOQry = Laive.DOQry.Bi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Bi
{

      /// <summary>
   /// Interface para Consultas personalizadas
   /// </summary>
   [ServiceContract()]
   public interface ICanalComercial
   {

      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetListNivel1<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetListNivel2<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      bool ExistsDB(IEntityBase value);

   }


   /// <summary>
   /// Business Object para Consultas a la Tabla: BI_CanalComercial (BI_CanalComercial)
   /// </summary>
   public class CanalComercial : BusinessObjectBase, IBOQuery, ICanalComercial
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.CanalComercial();

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


      public ICollection<T> GetListNivel1<T>(IEntityBase value) where T : new()
      {

         BIDOQry.CanalComercial objData = new BIDOQry.CanalComercial();

         try
         {

            ICollection<T> dt = objData.GetListNivel1<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


      public ICollection<T> GetListNivel2<T>(IEntityBase value) where T : new()
      {

         BIDOQry.CanalComercial objData = new BIDOQry.CanalComercial();

         try
         {

            ICollection<T> dt = objData.GetListNivel2<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public bool ExistsDB(IEntityBase value)
      {

          //BIDOQry.CanalComercial objData = (BIDOQry.CanalComercial)new BIDOQry.CanalComercial();
          BIDOQry.CanalComercial objData = new BIDOQry.CanalComercial();
          try
          {

              bool blnRes = objData.ExistsDB(value);

              return blnRes;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }


   }
}
