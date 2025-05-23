using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYBOQry = Laive.BOQry.Sy;
using SYBOMnt = Laive.BOMnt.Sy;
using Laive.Entity.Sy;
using System.Web.Script.Serialization;

namespace LAIVE.V1.Controllers.SY
{
    public class ParametrosSistemaController : Controller
    {
       [HttpGet]
       public PartialViewResult Index()
       {
          return PartialView("Index");
       }

       [HttpPost]
       public JsonResult GetBandeja(FlexigridParamSamNet Param)
       {
          JsonSamNet jsonR = new JsonSamNet();
          IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.ParametroSistema));
          EParametroSistema eParametroSistema = new EParametroSistema();

          if (Param.query != null && Param.query != "[]" && Param.query != "")
          {

             FilterSearch filterSearch = new FilterSearch();
             JavaScriptSerializer ser = new JavaScriptSerializer();
             List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
             eParametroSistema.EntityFilter = filterSearch.Create(filtro, eParametroSistema.ColumnSet());
          }

          jsonR.rows = jsonR.resultArray<EParametroSistema>(eParametroSistema.ColumnSet(), objBO.GetByCriteria<EParametroSistema>(eParametroSistema));
          return Json(jsonR);
       }


       [HttpPost]
       public JsonResult UpdateModel(EParametroSistema eParametroSistema)
       {
          JsonMessage jmessage = new JsonMessage();

          try
          {
             IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(SYBOMnt.ParametroSistema));
             objBO.UpdateData(eParametroSistema);
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
