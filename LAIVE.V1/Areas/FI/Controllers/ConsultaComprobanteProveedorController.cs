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

namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ConsultaComprobanteProveedorController : SamcontrollerBase
    {
        //
        // GET: /FI/ConsultaComprobanteProveedor/

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetBandeja()
        {
            JsonSamNet jsonR = new JsonSamNet();
            FIBOQry.IDeLotePago objBO = (FIBOQry.IDeLotePago)WCFHelper.GetObject<FIBOQry.IDeLotePago>(typeof(FIBOQry.DELotePago));
            EDetraccionPagadosPartner objE = new EDetraccionPagadosPartner();
            objE.EjercicioLote = DateTime.Now.Year;
            objE.PeriodoLote = 0; //DateTime.Now.Month;
           
            var EjercicioLote = objBO.GetDetraccionComprobantesProveedor<EDetraccionPagadosPartner>(objE);
            jsonR.rows = jsonR.resultArray<EDetraccionPagadosPartner>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);
        }

        public JsonResult GetDetraccionComprobantesProv(int vEjercicio, int vPeriodo)
        {
            JsonSamNet jsonR = new JsonSamNet();
            FIBOQry.IDeLotePago objBO = (FIBOQry.IDeLotePago)WCFHelper.GetObject<FIBOQry.IDeLotePago>(typeof(FIBOQry.DELotePago));
            EDetraccionPagadosPartner objE = new EDetraccionPagadosPartner();
            objE.EjercicioLote = vEjercicio;
            objE.PeriodoLote = vPeriodo;

            var EjercicioLote = objBO.GetDetraccionComprobantesProveedor<EDetraccionPagadosPartner>(objE);
            jsonR.rows = jsonR.resultArray<EDetraccionPagadosPartner>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);
        }

    }
}
