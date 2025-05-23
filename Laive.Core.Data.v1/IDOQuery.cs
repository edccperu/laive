using System;
using System.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Core.Data
{
   /// <summary>
   /// Interface general para los Data Object que realizan consultas a Tablas
   /// </summary>
   public interface IDOQuery
   {
      /// <summary>
      /// Metodo general para consultar datos por un criterio, es usado en las bandejas de busqueda para llenar un GridView
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
       ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new();

      /// <summary>
      /// Metodo general para consultar datos por la llave primaria
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna una Entidad Base que representa el registro requerido</returns>
      IEntityBase GetByKey(IEntityBase value);

      /// <summary>
      /// Metodo general para consultar datos por la llave de la tabla padre, es usado en para llenar un GridView en un escenario Master/Detail
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new();

      /// <summary>
      /// Metodo general para consultar datos por la llave de la tabla padre, es usado en para llenar un control Lista
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      ICollection<T> GetList<T>(IEntityBase value) where T : new();

      /// <summary>
      /// Metodo general para consultar datos por la llave de la tabla padre, es usado en para llenar un control Combo Box
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      ICollection<EntitySelect> GetListForSelect(IEntityBase value);

      /// <summary>
      /// Metodo general para consultar si existen datos por la llave primaria
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna Verdadero o Falso</returns>
      bool Exists(IEntityBase value);

      
   }
}
