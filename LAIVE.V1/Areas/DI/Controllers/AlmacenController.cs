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
    public class AlmacenController : SamcontrollerBase
    {
        //
        // GET: /Almacen/

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView("Index");
        }


        [HttpPost]
        public JsonResult GetBandeja(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
            EAlmacen eTrans = new EAlmacen();

            FilterSearch filterSearch = new FilterSearch();
            List<FilterOperator> filtro = new List<FilterOperator>();
            filtro.Add(new FilterOperator("CodigoAlmacen", "<>", "00    "));


            if (Param.query != null && Param.query != "[]" && Param.query != "")
            { 
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<FilterOperator> filtroDes = ser.Deserialize<List<FilterOperator>>(Param.query);
                filtro.AddRange(filtroDes);
            }

            eTrans.EntityFilter = filterSearch.Create(filtro, eTrans.ColumnSetBandeja());

            jsonR.rows = jsonR.resultArray<EAlmacen>(eTrans.ColumnSetBandeja(), objBO.GetByCriteria<EAlmacen>(eTrans));
            return Json(jsonR);
        }

        [HttpPost]
        public JsonResult GetBandejaAlmacenSerie(string codigoAlmacen)
        {
           JsonSamNet jsonR = new JsonSamNet();
           IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.AlmacenSerie));
           EAlmacenSerie eAlmacenSerie = new EAlmacenSerie();
           eAlmacenSerie.CodigoAlmacen = codigoAlmacen;
           jsonR.rows = jsonR.resultArray<EAlmacenSerie>(eAlmacenSerie.ColumnSet(), objBO.GetByCriteria<EAlmacenSerie>(eAlmacenSerie));
           return Json(jsonR);
        }

        [HttpPost]
        public JsonResult UpdateModel(EAlmacen eAlmacen)
        {
           JsonMessage jmessage = new JsonMessage();

           try
           {
              IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.Almacen));
              objBO.UpdateData(eAlmacen);
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
