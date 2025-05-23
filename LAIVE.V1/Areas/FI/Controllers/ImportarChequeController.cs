using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Core.Data;
using Laive.Core.Common;
using FIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using Laive.Entity.Fi;
using System.Web.Security;
using Laive.Core.Entity;                                                                                                                                                                                                                    
using LAIVE.V1.Controllers;


namespace LAIVE.V1.Areas.FI.Controllers 
{
   public class ImportarChequeController : SamcontrollerBase
   {
      [HttpGet]
      public PartialViewResult Index()
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.BaanBanco));
         EBaanBanco eBaanBanco = new EBaanBanco();
         ICollection<EBaanBanco> listBancos = objBO.GetList<EBaanBanco>(eBaanBanco);

         string JsonBancos = "";

         foreach (EBaanBanco eSel in listBancos)
         {
            if (JsonBancos != "")
               JsonBancos = string.Concat(JsonBancos, ",");
            JsonBancos = string.Concat(JsonBancos, "{text: '", eSel.GlosaBanco.Trim(), "', value: '", eSel.CodigoBanco.Trim(), "', chequeInicial : ", eSel.UltimoNumCheque, "}");
         }

         ViewBag.Bancos = JsonBancos;

         return PartialView("Index");
      }



      [HttpPost]
      public JsonResult ImportarBancosBaan(EBaanBancoImport eBaanBancoImport)
      {

         JsonMessage jmessage = new JsonMessage();

         try
         {
            FIBOMnt.Cheque BOMnt = new FIBOMnt.Cheque();
            eBaanBancoImport.Login = HttpContext.Session[ConstSessionVar.USERLOGON].ToString(); 
            int intIdx = BOMnt.ImportChequeBaan(eBaanBancoImport);

            switch (intIdx) { 
                case 1:
                    jmessage.Message = "NO SE ENCONTRARON CHEQUES";
                    break;
                case 2:
                    jmessage.Message = "SE IMPORTARON CHEQUES CON INCONSISTENCIAS";
                    break;
                case 3:
                    jmessage.Message = "IMPORTACIÓN CON EXITO";
                    break;
            }
                        
            jmessage.Status = JsonMessageStatus.SUCCESS;
            jmessage.Data = eBaanBancoImport.IdGrid;
            return Json(jmessage);
            
         }
         catch // (Exception e)
         { 
            jmessage.Message = "ERROR AL IMPORTAR DATOS";
            jmessage.Status = JsonMessageStatus.INVALID;
            jmessage.Data = eBaanBancoImport.IdGrid;
            return Json(jmessage);  
         }
         
      }


      
      [HttpPost]
      public JsonResult ImportarChequeInconsistente(List<ECheque> cheques)
      {
         JsonMessage jmessage = new JsonMessage();
         try
         {
            FIBOMnt.Cheque BOMnt = new FIBOMnt.Cheque();
            foreach (ECheque cheque in cheques)
            {
               BOMnt.ImportChequeInconsistente(cheque);
            }

            jmessage.Status = JsonMessageStatus.SUCCESS;
            jmessage.Message = "Datos Actualizados Correctamente";
            return Json(jmessage);
            
         }
         catch //(Exception e)
         {
            jmessage.Message = "ERROR AL IMPORTAR DATOS";
            jmessage.Status = JsonMessageStatus.INVALID;
            return Json(jmessage);  
         }
         
      }

      [HttpPost]
      public JsonResult GetChequesIconsistentes(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         FIBOQry.ICheque objBO = (FIBOQry.ICheque)WCFHelper.GetObject<FIBOQry.ICheque>(typeof(FIBOQry.Cheque));
         ECheque objE = new ECheque();

         var ActProy = objBO.GetChequeInconsistente<ECheque>(objE);

         jsonR.rows = jsonR.resultArray<ECheque>(objE.ColumnSet(), ActProy);

         return Json(jsonR);
      }

   }
}
