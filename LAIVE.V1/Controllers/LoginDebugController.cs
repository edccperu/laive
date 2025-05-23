using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Core.Data;
using Laive.Core.Common;
using SYBOQry = Laive.BOQry.Sy;
using Laive.Entity.Sy;
using System.Web.Security;

namespace LAIVE.V1.Controllers.LOGIN
{
    public class LoginDebugController : SamcontrollerBase
    {
        [AllowAnonymous]
        public ActionResult Index()
        {

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Usuario));
            EUsuario eUsuario = new EUsuario();
            var Usuario = objBO.GetList<EUsuario>(eUsuario);
            try
            {
               Session[ConstSessionVar.NAMEPCCLIENT] = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' })[0];
               Session[ConstSessionVar.IPCLIENT] = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).AddressList[1];
            }
            catch
            {
               Session[ConstSessionVar.NAMEPCCLIENT] = Request.UserHostName;
               Session[ConstSessionVar.IPCLIENT] = Request.UserHostAddress;
            }

            Session[ConstSessionVar.SEDEID] = ConstDefaultValue.SEDE;
            Session[ConstSessionVar.PERIODO] = DateTime.Now.Year.ToString();

            return PartialView("Index", Usuario);
        }

        [AllowAnonymous]
        [HttpGet]
        public bool Login(string IdUser, string IdLogon)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, IdUser, DateTime.Now, DateTime.Now.AddMinutes(ConstSessionVar.TIMERSESSION),false, "");
            String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            try
            {
                Session[ConstSessionVar.NAMEPCCLIENT] = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' })[0];
                Session[ConstSessionVar.IPCLIENT] = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).AddressList[1];
            }
            catch
            {
                Session[ConstSessionVar.NAMEPCCLIENT] = Request.UserHostName;
                Session[ConstSessionVar.IPCLIENT] = Request.UserHostAddress; 
            }

            Session[ConstSessionVar.USERID] = IdUser; 
            Session[ConstSessionVar.SEDEID] = ConstDefaultValue.SEDE;
            Session[ConstSessionVar.PERIODO] = DateTime.Now.Year.ToString();
            Session[ConstSessionVar.USERLOGON] = IdLogon;
            return true;
        }

    }
}
