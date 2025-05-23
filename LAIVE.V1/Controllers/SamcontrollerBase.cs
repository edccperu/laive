using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using Laive.Core.Common;
using BOQrySY = Laive.BOQry.Sy;
using Laive.Core.Data;
using Laive.Entity.Sy;

namespace LAIVE.V1.Controllers
{
    public class SamcontrollerBase : Controller
    {
        /// <summary>
        /// Crea un mensaje que se mostrara en el Postback
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string CreateMessage(string msgType, string msg, string idcode)
        {
            return msgType + ";" + msg + ";" + idcode;
        }

        public string GetParametroSistemaString(int id)
        {
            IBOQuery boParametroSistema = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BOQrySY.ParametroSistema));
            EParametroSistema eParametroSistema = new EParametroSistema();
            eParametroSistema.IdParametroSistema = id;
            eParametroSistema = (EParametroSistema)boParametroSistema.GetByKey(eParametroSistema);
            return eParametroSistema.NuValorCadena;
        }

        public decimal? GetParametroSistemaInt(int id)
        {
            IBOQuery boParametroSistema = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BOQrySY.ParametroSistema));
            EParametroSistema eParametroSistema = new EParametroSistema();
            eParametroSistema.IdParametroSistema = id;
            eParametroSistema = (EParametroSistema)boParametroSistema.GetByKey(eParametroSistema);
            return eParametroSistema.NuValorNumerico;
        }

        public DateTime? GetParametroSistemaDateTime(int id)
        {
            IBOQuery boParametroSistema = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BOQrySY.ParametroSistema));
            EParametroSistema eParametroSistema = new EParametroSistema();
            eParametroSistema.IdParametroSistema = id;
            eParametroSistema = (EParametroSistema)boParametroSistema.GetByKey(eParametroSistema);
            return eParametroSistema.NuValorFecha;
        }


    }
}
