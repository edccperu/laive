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
using FIBOMnt = Laive.BOMnt.Fi;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using System.Net;
using System.IO;

namespace LAIVE.V1.Areas.FI.Controllers
{
   public class GestionFirmanteController : SamcontrollerBase
   {
      //
      // GET: /GestionFirmante/

      [HttpGet]
      public PartialViewResult Index()
      {

         IBOQuery tipoFirmanteBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.TipoFirmante));
         ETipoFirmante eTipoFirmante = new ETipoFirmante();
         ViewBag.tipoFirmanteLista = tipoFirmanteBO.GetListForSelect(eTipoFirmante);

         return PartialView("Index");
      }


      [HttpPost]
      public JsonResult GetBandeja(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.Firmante));
         EFirmante eTrans = new EFirmante();

         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {

            FilterSearch filterSearch = new FilterSearch();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
            eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
         }

         jsonR.rows = jsonR.resultArray<EFirmante>(eTrans.ColumnSet(), objBO.GetByCriteria<EFirmante>(eTrans));
         return Json(jsonR);
      }


      [HttpPost]
      public JsonResult GetBandejaFirmantePc(string codigoFirmante)
      {
         JsonSamNet jsonR = new JsonSamNet();
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.FirmantePc));
         EFirmantePc eFirmantePc = new EFirmantePc();
         eFirmantePc.CodigoFirmante = codigoFirmante;
         jsonR.rows = jsonR.resultArray<EFirmantePc>(eFirmantePc.ColumnSet(), objBO.GetByParentKey<EFirmantePc>(eFirmantePc));
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult UpdateModel(EFirmante eFirmante)
      {
         JsonMessage jmessage = new JsonMessage();

         try
         {
            IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(FIBOMnt.Firmante));

            string[] idFirmante = objBO.UpdateData(eFirmante);

            TempData["idFirmante"] = idFirmante == null ? eFirmante.CodigoFirmante : idFirmante[0];
            
            jmessage.Status = JsonMessageStatus.SUCCESS;
            jmessage.Message = "Datos Guardados Correctamente.";
         }
         catch (Exception e)
         {
            jmessage.Status = JsonMessageStatus.INVALID;
            jmessage.Message = e.Message;
         }

         return Json(jmessage);
      }


      [HttpPost]
      public JsonResult UploadFile()
      {

         JsonMessage message = new JsonMessage();
         try
         {

            for (int i = 0; i < Request.Files.Count; i++)
            {
               var file = Request.Files[i];
               BinaryReader b = new BinaryReader(file.InputStream);
               byte[] binData = b.ReadBytes(file.ContentLength);

               EFirmante eFirmante = new EFirmante();
               eFirmante.CodigoFirmante = Convert.ToString(TempData["idFirmante"]);
               eFirmante.Firma = binData;

               FIBOMnt.IFirmante objBO = (FIBOMnt.IFirmante)WCFHelper.GetObject<FIBOMnt.IFirmante>(typeof(FIBOMnt.Firmante));
               objBO.UpdateFirma(eFirmante);
               break;
            }

            message.Status = JsonMessageStatus.SUCCESS;
            message.Message = "Carga Correcta";
         }
         catch (Exception e)
         {

            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;
         }

         return Json(message);
      }



      [HttpPost]
      public JsonResult GetDataNetwork() {
         JsonMessage jmessage = new JsonMessage();

         try
         {
             string ip = GetIP4Address();
             //string hostName = Dns.GetHostName();
             string hostNames = Dns.GetHostEntry(ip).HostName;
             int pos = hostNames.IndexOf(".laive");
             string hostName = pos != -1 ? hostNames.Substring(0, pos).ToUpper():hostNames;
             
            jmessage.Data = new { hostName = hostName,ip = ip };

            jmessage.Status = JsonMessageStatus.SUCCESS;
            jmessage.Message = "Datos Guardados Correctamente.";
         }
         catch (Exception e)
         {
            jmessage.Status = JsonMessageStatus.INVALID;
            jmessage.Message = e.Message;
         }

         return Json(jmessage);      
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
