using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Di;
using Laive.Core.Entity;
using Laive.Core.Data;
using LGBOQry = Laive.BOQry.Di;
using MGBOMnt = Laive.BOMnt.Mg;
using DIBOQry = Laive.BOQry.Di;
using DIBOMnt = Laive.BOMnt.Di;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;


namespace LAIVE.V1.Areas.DI.Controllers
{
   public class BoxController : SamcontrollerBase
   {
      //
      // GET: /Box/
      [HttpGet]
      public PartialViewResult Index()
      {
         IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         EAlmacen eAlmacen = new EAlmacen();
         ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         ViewBag.ListAlmacen = listAlma;

         return PartialView("Index");
      }

      [HttpPost]
      public JsonResult GetBandeja(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Box));
         EBox eTrans = new EBox();

         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {

            FilterSearch filterSearch = new FilterSearch();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
            eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
         }

         jsonR.rows = jsonR.resultArray<EBox>(eTrans.ColumnSet(), objBO.GetByCriteria<EBox>(eTrans));
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult UpdateModel(EBox eBox)
      {
         JsonMessage jmessage = new JsonMessage();

         try
         {
            IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.Box));
            objBO.UpdateData(eBox);
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
