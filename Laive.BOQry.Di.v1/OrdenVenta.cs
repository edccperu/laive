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
   public interface IOrdenVenta
   {
      /// <summary>
      /// Lista los Articulos Agrupados de la orden por fecha.
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetOrdenVentaArticulos<T>(IEntityBase value) where T : new();


      /// <summary>
      /// Lista Partner por Articulo.
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetOrdenVentaPartners<T>(IEntityBase value) where T : new();
      
      /// <summary>
      /// Lista el Stock por Articulo.
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetOrdenVentaStock<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      int CantidadOrdenXArticuloNoEliminados(IEntityBase value);


      [OperationContract()]
      [NetDataContract()]
      int CantidadOrdenXPartnerNoEliminados(IEntityBase value);

   }

   /// <summary>
   /// Business Object para Consultas a la Tabla: DI_OrdenVenta (DI_OrdenVenta)
   /// </summary>
   public class OrdenVenta : BusinessObjectBase, IBOQuery,IOrdenVenta
   {

      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

         IDOQuery objData = (IDOQuery)new DIDOQry.OrdenVenta();

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

      #region IOrdenVenta
      public ICollection<T> GetOrdenVentaArticulos<T>(IEntityBase value) where T : new()
      {

         DIDOQry.OrdenVenta objData = new DIDOQry.OrdenVenta();

         try
         {

            ICollection<T> dt = objData.GetOrdenVentaArticulos<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetOrdenVentaPartners<T>(IEntityBase value) where T : new()
      {

         DIDOQry.OrdenVenta objData = new DIDOQry.OrdenVenta();

         try
         {

            ICollection<T> dt = objData.GetOrdenVentaPartners<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetOrdenVentaStock<T>(IEntityBase value) where T : new()
      {

         DIDOQry.OrdenVenta objData = new DIDOQry.OrdenVenta();

         try
         {

            ICollection<T> dt = objData.GetOrdenVentaStock<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int CantidadOrdenXArticuloNoEliminados(IEntityBase value)
      {

         DIDOQry.OrdenVenta objData = new DIDOQry.OrdenVenta();

         try
         {

            int objE = objData.CantidadOrdenXArticuloNoEliminados(value);

            return objE;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int CantidadOrdenXPartnerNoEliminados(IEntityBase value)
      {

         DIDOQry.OrdenVenta objData = new DIDOQry.OrdenVenta();

         try
         {

            int objE = objData.CantidadOrdenXPartnerNoEliminados(value);

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
