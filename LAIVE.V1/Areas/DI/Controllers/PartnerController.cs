using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Di;
using Laive.Core.Entity;
using Laive.Core.Data;
using DIBOQry = Laive.BOQry.Di;
using MGBOMnt = Laive.BOMnt.Mg;
using DIBOMnt = Laive.BOMnt.Di;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.DI.Controllers
{
   public class PartnerController : SamcontrollerBase
   {
      //
      // GET: /Partner/

      [HttpGet]
      public PartialViewResult Index()
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Ruta));
         ERuta eUESede = new ERuta();
         ViewBag.Ruta = objBO.GetListForSelect(eUESede);

         return PartialView("Index");
      }

      [HttpPost]
      public JsonResult GetBandeja(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanPartner));
         EBaanPartner eTrans = new EBaanPartner();

         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {

            FilterSearch filterSearch = new FilterSearch();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
            eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
         }

         jsonR.rows = jsonR.resultArray<EBaanPartner>(eTrans.ColumnSet(), objBO.GetByCriteria<EBaanPartner>(eTrans));
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult UpdateModel(string IdPartner, int IdRuta)
      {
         JsonMessage jmessage = new JsonMessage();

         try
         {
            DIBOMnt.IRuta objBO = (DIBOMnt.IRuta)WCFHelper.GetObject<DIBOMnt.IRuta>(typeof(DIBOMnt.Ruta));
            objBO.UpdateRutaXPartner(IdPartner, IdRuta);
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
   }
}
