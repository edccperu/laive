using System;
using System.ServiceModel;
using System.Reflection;

namespace Laive.Core.Data
{
   /// <summary>
   /// Clase base para los DataObjectBase y BusinessObjectBase
   /// </summary>
   /// <remarks></remarks>
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
   public class ServerObject
   {

      public virtual Exception GetException(string source, MethodBase method, Exception ex)
      {
         ServerObjectException objServerExp = new ServerObjectException(ex.Message, ex);

         objServerExp.Source = source + ": " + method.DeclaringType.FullName + "->" + method.Name;

         return objServerExp;

      }

   }
}
