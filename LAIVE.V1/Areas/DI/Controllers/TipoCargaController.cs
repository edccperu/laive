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
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.DI.Controllers
{
    public class TipoCargaController : SamcontrollerBase
    {
        //
        // GET: /TipoCarga/

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView("Index");
        }

        [HttpPost]
        public JsonResult GetBandeja(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(LGBOQry.TipoCarga));
            ETipoCarga eTrans = new ETipoCarga();

            if (Param.query != null && Param.query != "[]" && Param.query != "")
            {

                FilterSearch filterSearch = new FilterSearch();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
                eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
            }

            jsonR.rows = jsonR.resultArray<ETipoCarga>(eTrans.ColumnSet(), objBO.GetByCriteria<ETipoCarga>(eTrans));
            return Json(jsonR);
        }
    }
}
