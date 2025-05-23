using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Sy;
using Laive.Entity.Mg;
using Laive.Core.Data;
using Laive.Core.Common;
using SYBOQry = Laive.BOQry.Sy;

namespace LAIVE.V1.Controllers
{
    public class MenuController : SamcontrollerBase
    {
        //
        // GET: /Menu/
        [ChildActionOnly] 
        public ActionResult MainMenu()
        {
            SYBOQry.IMenuPage objIMenuPage = (SYBOQry.IMenuPage)WCFHelper.GetObject<SYBOQry.IMenuPage>(typeof(SYBOQry.MenuPage));
            var MenuPage = objIMenuPage.GetListXForMenu<EMenuPage>(Session[ConstSessionVar.USERID].ToString());
            return View(MenuPage);
        }

        [HttpPost]
        public JsonResult GetTotalesXMenu()
        {

           SYBOQry.IMenuPage objIMenuPage = (SYBOQry.IMenuPage)WCFHelper.GetObject<SYBOQry.IMenuPage>(typeof(SYBOQry.MenuPage));
           ICollection<EContadorMenu> listaE = objIMenuPage.GetListNumRegMenu<EContadorMenu>(Session[ConstSessionVar.USERLOGON].ToString());

           return Json(listaE);
        }

    }
}
