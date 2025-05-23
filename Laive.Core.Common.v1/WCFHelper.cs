using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Laive.Core.Common
{
   public class WCFHelper
   {

      public static T GetObject<T>(Type type)
      {
#if !DEBUG
		return GetObject<T>(type, false);
#else
         return GetObject<T>(type, true);
#endif
      }

      public static T GetObject<T>(Type type, bool isDebugMode)
      {

         string strServer = "dbsvrmain";
         string strPort = "";

         if (type.FullName.IndexOf(".BOMnt") != -1)
         {
            strPort = "5001";
         }

         if (type.FullName.IndexOf(".BOQry") != -1)
         {
            strPort = "5002";
         }

         if (type.FullName.IndexOf(".BORpt") != -1)
         {
            strPort = "5003";
         }

         string strUrl = "net.tcp://" + strServer + ":" + strPort + "/" + type.ToString();
         T proxy = default(T);


         if (!isDebugMode)
         {
            NetTcpBinding netTcp = new NetTcpBinding();
            netTcp.Security.Mode = SecurityMode.None;

            EndpointAddress epAdd = new EndpointAddress(strUrl);
            netTcp.MaxReceivedMessageSize = 2147483647;
            proxy = ChannelFactory<T>.CreateChannel(netTcp, epAdd);

         }
         else
         {
            proxy = (T)Activator.CreateInstance(type);
         }

         return proxy;
      }
   }
}