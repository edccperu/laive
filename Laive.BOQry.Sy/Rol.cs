using System;
using System.Collections;
using System.Data;
using System.Text;
using System.ServiceModel;
using Laive.Core.Data;
using SYDOQry = Laive.DOQry.Sy;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.BOQry.Sy
{
       /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
   [ServiceContract()]
   public interface IRol
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetUsuariosXRol<T>(int value) where T : new();

   }


   /// <summary>
   /// Business Object para Consultas a la Tabla: SY_Rol (SY_Rol)
   /// </summary>
   public class Rol : BusinessObjectBase, IBOQuery,IRol 
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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

         IDOQuery objData = (IDOQuery)new SYDOQry.Rol();

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


      #region IRol

      public ICollection<T> GetUsuariosXRol<T>(int value) where T : new()
      {

         SYDOQry.Rol objData = new SYDOQry.Rol();

         try
         {

            ICollection<T> dt = objData.GetUsuariosXRol<T>(value);

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
