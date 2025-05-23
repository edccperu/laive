using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Di;
using Laive.Core.Entity;
using Laive.Core.Data;
using DIBOMnt = Laive.BOMnt.Di;
using LGBOQry = Laive.BOQry.Di;
using MGBOMnt = Laive.BOMnt.Mg;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.DI.Controllers
{
    public class TransportistaController : SamcontrollerBase
    {
        //
        // GET: /Transportista/
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView("Index");
        }

        [HttpPost]
        public JsonResult GetBandeja(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(LGBOQry.Transportista));
            ETransportista eTrans = new ETransportista();

            if (Param.query != null && Param.query != "[]" && Param.query != "")
            {
              
                FilterSearch filterSearch = new FilterSearch();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
                eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
            }

            jsonR.rows = jsonR.resultArray<ETransportista>(eTrans.ColumnSet(), objBO.GetByCriteria<ETransportista>(eTrans));
            return Json(jsonR);
        }

        [HttpGet]
        public PartialViewResult GetEditModel(ETransportista eTransportista)
        {



            return PartialView("EditModel");
        }

        [HttpPost]
        public JsonResult UpdateModel(ETransportista eTransportista)
        {
            JsonMessage jmessage = new JsonMessage();
            try
            {
                IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.Transportista));
                objBO.UpdateData(eTransportista);
                jmessage.Status = JsonMessageStatus.SUCCESS;
                jmessage.Message = "Datos se Actualizaron Correctamente.";
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
