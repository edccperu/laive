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
using DIBOMnt = Laive.BOMnt.Di;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.DI.Controllers
{
    public class ChoferController : SamcontrollerBase
    {
        //
        // GET: /Chofer/

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView("Index");
        }

        // GET: bandeja/Chofer/
        [HttpPost]
        public JsonResult GetBandeja(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(LGBOQry.Chofer));
            EChofer eTrans = new EChofer();

            if (Param.query != null && Param.query != "[]" && Param.query != "")
            {

                FilterSearch filterSearch = new FilterSearch();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
                eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
            }

            jsonR.rows = jsonR.resultArray<EChofer>(eTrans.ColumnSet(), objBO.GetByCriteria<EChofer>(eTrans));
            return Json(jsonR);
        }

        [HttpPost]
        public JsonResult UpdateModel(EChofer echofer)
        {
            JsonMessage jmessage = new JsonMessage();

            try
            {

               LGBOQry.IChofer objIBO = (LGBOQry.IChofer)WCFHelper.GetObject<LGBOQry.IChofer>(typeof(LGBOQry.Chofer));
               EChofer newEChofer = (EChofer)objIBO.GetByClaveChofer(echofer);

               if (newEChofer == null || (echofer.EntityState == EntityState.Modified && newEChofer.IdChofer == echofer.IdChofer))
               {
                  IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.Chofer));
                  objBO.UpdateData(echofer);
                  jmessage.Status = JsonMessageStatus.SUCCESS;
                  jmessage.Message = "Datos Guardados Correctamente.";
               }
               else {
                  jmessage.Status = JsonMessageStatus.INFORMATION;
                  jmessage.Message = "La clave de chofer ya se encuentra registrada.";
               }



            }
            catch (Exception e) {

               jmessage.Status = JsonMessageStatus.INVALID;
               jmessage.Message = e.Message;
            }

            return Json(jmessage);
        }

    }
}
