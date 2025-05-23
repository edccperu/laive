using Laive.Entity.Fi;
using Laive.Entity.Di;
using Laive.Core.Common;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIBOQry = Laive.BOQry.Di;
using FIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using LAIVE.V1.Controllers;
using Laive.Core.Data;
using System.Web.Script.Serialization;
using System.Globalization;
using Newtonsoft.Json;

namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ConsultaDetraccionPagadosController : SamcontrollerBase
    {

        [HttpGet]
        public PartialViewResult Index()
        {
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanPartner));
            EBaanPartner eBaanPartner = new EBaanPartner();
            ICollection<EBaanPartner> listPartners = objBO.GetByParentKey<EBaanPartner>(eBaanPartner);

            var JsonPartner = from partner in listPartners select new { text = string.Concat(partner.CodigoPartner.Trim(), " - ", partner.GlosaPartner.Trim()), value = partner.CodigoPartner.Trim() };
            
            //string JsonPartner = "";

            //foreach (EBaanPartner eSel in listPartners){
            //    if (JsonPartner != "")
            //        JsonPartner = string.Concat(JsonPartner, ",");
            //        JsonPartner = string.Concat(JsonPartner, "{text: '", eSel.GlosaPartner.Trim(), "', value: '", eSel.CodigoPartner.Trim(), "'}");

            
            ViewBag.Partners = JsonConvert.SerializeObject(JsonPartner);
            return PartialView("Index");
        }

        [HttpPost]
        public JsonResult GetBandeja()
        {
            JsonSamNet jsonR = new JsonSamNet();
            FIBOQry.IDeLotePago objBO = (FIBOQry.IDeLotePago)WCFHelper.GetObject<FIBOQry.IDeLotePago>(typeof(FIBOQry.DELotePago));
            EDetraccionPagadosPartner objE = new EDetraccionPagadosPartner();
            objE.EjercicioLote = DateTime.Now.Year;
            objE.mesPagoIni = DateTime.Now.Month;
            objE.mesPagoFin = DateTime.Now.Month;
            objE.codigoPartnerPagador = "";
            var EjercicioLote = objBO.GetDetraccionPagadosPartner<EDELotePago>(objE);
            jsonR.rows = jsonR.resultArray<EDELotePago>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);
        }

        public JsonResult GetDetraccionPagados(int vPeriodo, int vMesIni, int vMesFin, string vcodigoPartner)
        {
            JsonSamNet jsonR = new JsonSamNet();
            FIBOQry.IDeLotePago objBO = (FIBOQry.IDeLotePago)WCFHelper.GetObject<FIBOQry.IDeLotePago>(typeof(FIBOQry.DELotePago));
            EDetraccionPagadosPartner objE = new EDetraccionPagadosPartner();
            objE.EjercicioLote = vPeriodo;
            objE.mesPagoIni = vMesIni;
            objE.mesPagoFin = vMesFin;
            objE.codigoPartnerPagador = vcodigoPartner;
            var EjercicioLote = objBO.GetDetraccionPagadosPartner<EDetraccionPagadosPartner>(objE);
            jsonR.rows = jsonR.resultArray<EDetraccionPagadosPartner>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);
        }


    }
}
