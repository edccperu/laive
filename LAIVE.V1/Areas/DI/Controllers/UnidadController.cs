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
using DIBOMnt = Laive.BOMnt.Di;
using MGBOMnt = Laive.BOMnt.Mg;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using Newtonsoft.Json;

namespace LAIVE.V1.Areas.DI.Controllers
{
    public class UnidadController : SamcontrollerBase
    {
        //
        // GET: /Unidad/

        [HttpGet]
        public PartialViewResult Index()
        {
           IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Transportista));
           ETransportista eTransportista = new ETransportista();
           ICollection<ETransportista> transportistaLista = objBO.GetList<ETransportista>(eTransportista);
           var JsonTransportista = from transportista in transportistaLista select new { value = transportista.IdTransportista.ToString(), text = transportista.RazonSocial.Trim() };
           ViewBag.ListaTransportista = JsonConvert.SerializeObject(JsonTransportista);

           IBOQuery objBOChofer = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Chofer));
           EChofer eChofer = new EChofer();
           ICollection<EChofer> choferLista = objBOChofer.GetList<EChofer>(eChofer);
           var JsonChofer = from chofer in choferLista select new { value = chofer.IdChofer.ToString(), text = chofer.NombreChofer.Trim() };
           ViewBag.ListaChofer = JsonConvert.SerializeObject(JsonChofer);

            return PartialView("Index");
        }

        [HttpPost]
        public JsonResult GetBandeja(FlexigridParamSamNet Param)
        {
           JsonSamNet jsonR = new JsonSamNet();
           IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Unidad));
           EUnidad eTrans = new EUnidad();
           eTrans.EntityFilter = "";
           if (Param.query != null && Param.query != "[]" && Param.query != "")
           {

              FilterSearch filterSearch = new FilterSearch();
              JavaScriptSerializer ser = new JavaScriptSerializer();
              List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
              eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSet());
           }

           jsonR.rows = jsonR.resultArray<EUnidad>(eTrans.ColumnSet(), objBO.GetByCriteria<EUnidad>(eTrans));
           return Json(jsonR);
        }


        [HttpPost]
        public JsonResult UpdateModel(EUnidad eUnidad)
        {
           JsonMessage jmessage = new JsonMessage();

           try
           {
              IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.Unidad));
              objBO.UpdateData(eUnidad);
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
