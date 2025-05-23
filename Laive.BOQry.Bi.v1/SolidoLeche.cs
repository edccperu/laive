using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using Laive.Core.Common;
using BIDOQry = Laive.DOQry.Bi;
using System.Collections.Generic;

namespace Laive.BOQry.Bi
{

    [ServiceContract()]
   public interface ISolidoLeche
   {

        [OperationContract()]
        [NetDataContract()]
        bool ExistsDB(IEntityBase value);

    }

   /// <summary>
   /// Business Object para Consultas a la Tabla: BI_SolidoLeche (BI_SolidoLeche)
   /// </summary>
   public class SolidoLeche : BusinessObjectBase, IBOQuery, ISolidoLeche
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

      public bool ExistsDB(IEntityBase value)
      {

          BIDOQry.SolidoLeche objData = new BIDOQry.SolidoLeche();
          

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

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         IDOQuery objData = (IDOQuery)new BIDOQry.SolidoLeche();

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

   }
}
