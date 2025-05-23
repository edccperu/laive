using System;
using System.ServiceModel;
using System.Data;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.Core.Data
{
   /// <summary>
   /// Interface general para los Business Objects que realizan consultas a Tablas
   /// </summary>
   [ServiceContract()]
   public interface IBOQuery
   {
      [OperationContract()]
      [NetDataContract()]
       ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      IEntityBase GetByKey(IEntityBase value);

      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      ICollection<T> GetList<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      ICollection<EntitySelect> GetListForSelect(IEntityBase value);

      [OperationContract()]
      [NetDataContract()]
      bool Exists(IEntityBase value);

    

   }
}
