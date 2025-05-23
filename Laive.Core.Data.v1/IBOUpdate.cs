using System;
using System.ServiceModel;


namespace Laive.Core.Data
{
    [ServiceContract()]
    public interface IBOUpdate
    {

        [OperationContract()]
        [NetDataContract()]
        string[] UpdateData(IEntityBase value);

        [OperationContract()]
        [NetDataContract()]
        int DeleteData(IEntityBase value);

    }
}
