using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Fi;
using FIBOQry = Laive.BOQry.Fi;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using System.Net;

namespace LAIVE.V1.Areas.FI.Controllers
{
   public class SecurityMACController : SamcontrollerBase
   {
      //
      // GET: /SecurityMAC/

      [HttpGet]
      public PartialViewResult Index(string dsController, string dsAction,string dsArea)
      {
         HttpContext.Session["_dsController"] = dsController;
         HttpContext.Session["_dsAction"] = dsAction;
         HttpContext.Session["_dsArea"] = dsArea;
         return PartialView();
      }

      [HttpGet]
      public ActionResult ValidateMAC()
      {

         FIBOQry.IFirmante objBO = (FIBOQry.IFirmante)WCFHelper.GetObject<FIBOQry.IFirmante>(typeof(FIBOQry.Firmante));
         EFirmante eFirmante = new EFirmante();
         eFirmante.Login = HttpContext.Session[ConstSessionVar.USERLOGON].ToString();
         eFirmante = (EFirmante)objBO.GetByLogin(eFirmante);

         if (eFirmante == null)
         {
            ViewBag.messageError = "El Usuario no esta Registrado como Firmante.";
            return PartialView("ValidateError");
         }

         //string hostName = Dns.GetHostName();
         string ip = GetIP4Address();
         string hostNames = Dns.GetHostEntry(ip).HostName;
         int pos = hostNames.IndexOf(".laive");
         string hostName = pos != -1 ? hostNames.Substring(0, pos).ToUpper() : hostNames;

         bool isValid = false;


         IBOQuery BOQryFirmantePc = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.FirmantePc));
         EFirmantePc eFirmantePc = new EFirmantePc();
         eFirmantePc.CodigoFirmante = eFirmante.CodigoFirmante;

         eFirmantePc.HostNameFirmante = hostName;
         eFirmantePc.IpFirmante = ip;
         
         isValid = BOQryFirmantePc.Exists(eFirmantePc);

         if (!isValid)
         {
             ViewBag.messageError = "Solicitud Denegada, esté dispositivo no se encuentra registrado como dispositivo de confianza.";
             return PartialView("ValidateError");
         }

         return RedirectToAction(HttpContext.Session["_dsAction"].ToString(), HttpContext.Session["_dsController"].ToString(), new { area = HttpContext.Session["_dsArea"].ToString() });

      }

      public string GetIP4Address()
      {
         string IP4Address = String.Empty;

         foreach (IPAddress IPA in Dns.GetHostAddresses(Request.UserHostAddress))
         {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
               IP4Address = IPA.ToString();
               break;
            }
         }

         if (IP4Address != String.Empty)
         {
            return IP4Address;
         }

         foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
         {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
               IP4Address = IPA.ToString();
               break;
            }
         }

         return IP4Address;
      }
   }
}
