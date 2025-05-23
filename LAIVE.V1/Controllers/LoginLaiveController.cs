using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Core.Common;
using System.Web.Security;
using System.Web.Configuration;
using System.DirectoryServices;
using Laive.Core.Data;
using Laive.Entity.Sy;
using SYBOQry = Laive.BOQry.Sy;

namespace LAIVE.V1.Controllers.LOGIN
{
    public class LoginLaiveController : SamcontrollerBase
    {
        [AllowAnonymous]
        public ActionResult Index(bool isRedirect = false, string ReturnUrl = null)
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult LogInAuthenticated(string IdLogon, string Password)
        {
            if (IdLogon == null || IdLogon == "" || Password == null || Password == "")
               return Json(new { Status = "invalid", Message = "Los Datos no se enviaron correctamente." });

            if (IsAuthenticated(IdLogon, Password))
            {

                EUsuario eUsuario = new EUsuario();
                SYBOQry.IUsuario objBOUser = (SYBOQry.IUsuario)WCFHelper.GetObject<SYBOQry.IUsuario>(typeof(SYBOQry.Usuario));
                eUsuario.IdLogon = IdLogon;
                eUsuario = (EUsuario)objBOUser.GetByKeyXIdLogon(eUsuario);
                if (eUsuario == null)
                {
                   return Json(new { Status = "invalid",Message ="El Usuario no se encuentra registrado en el sistema." });
                }
                Session[ConstSessionVar.USERID] = eUsuario.IdUser;
                Session[ConstSessionVar.USERLOGON] = eUsuario.IdLogon;

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, eUsuario.IdUser, DateTime.Now, DateTime.Now.AddMinutes(ConstSessionVar.TIMERSESSION), true, "");              
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

                Session[ConstSessionVar.SEDEID] = ConstDefaultValue.SEDE;
                Session[ConstSessionVar.PERIODO] = DateTime.Now.Year.ToString();


                return Json(new { Status = "success", Url = Url.Action("Index","Home") });
            }

            return Json(new { Status = "invalid", Message = "El Usuario no se encuentra en la RED." });
        }
                
        [HttpGet]
        public ActionResult InitAplication(string IdSede,string IdPeriodo) {
            try
            {
               

                return Content("true");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
            
        }

        public ActionResult LogOut()
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i <= limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            Session.Abandon();

            return RedirectToAction("Login");
        }

        private bool IsAuthenticated(string IdLogon, string Password)
        {
            string strAdPath = "LDAP://" + WebConfigurationManager.AppSettings[ConstSistema.APSET_AD_LDAP];
            string strDomain = WebConfigurationManager.AppSettings[ConstSistema.APSET_AD_DOMAIN];
            string domainAndUsername = strDomain + @"\" + IdLogon;

            
            try
            {
                string path = String.Format("WinNT://{0}/{1},user", strDomain, IdLogon);
                DirectoryEntry.Exists(path);
                DirectoryEntry entry = new DirectoryEntry(strAdPath, domainAndUsername, Password);
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + IdLogon + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
