using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SamNet.Core.Common
{
    public class controllerBase:Controller
    {
        /// <summary>
        /// Crea un mensaje que se mostrara en el Postback
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string CreateMessage(string msgType,string msg,string idcode)
        {
            return msgType + ";" + msg + ";" + idcode;
        }

    }
}
