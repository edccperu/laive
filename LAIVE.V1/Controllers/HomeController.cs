using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Sy;
using Laive.Core.Data;
using Laive.Core.Common;
using SYBOQry = Laive.BOQry.Sy;
using System.Globalization;

namespace LAIVE.V1.Controllers
{
   public class HomeController : SamcontrollerBase
   {
      public ActionResult Index()
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Usuario));
         EUsuario eUsuario = new EUsuario();
         eUsuario.IdUser = Session[ConstSessionVar.USERID].ToString();
         eUsuario = (EUsuario)objBO.GetByKey(eUsuario);

         ViewBag.User = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(eUsuario.DsNombres.ToLower());

         return View();
      }

   }
}
