using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Fi;
using Laive.Core.Entity;
using Laive.Core.Data;
using FIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using System.Data.SqlClient;

namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ProcesarDetraccionController : SamcontrollerBase
    {
        //
        // GET: /FI/ProcesarDetraccion/

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetBandeja()
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.DELotePago));
            EDELotePago objE = new EDELotePago();
            objE.EjercicioLote = 0;
            var EjercicioLote = objBO.GetByCriteria<EDELotePago>(objE);
            jsonR.rows = jsonR.resultArray<EDELotePago>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);

        }

        [HttpPost]
        public JsonResult GetBandejaEjercicio(int Ejercicio)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.DELotePago));
            EDELotePago objE = new EDELotePago();
            objE.EjercicioLote = Ejercicio;
            var EjercicioLote = objBO.GetByCriteria<EDELotePago>(objE);
            jsonR.rows = jsonR.resultArray<EDELotePago>(objE.ColumnSet(), EjercicioLote);
            return Json(jsonR);
        }

        [HttpPost]
        public JsonResult UpdateConcilacion(int vEjercicio, int vPeriodo)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                EDELotePago objE = new EDELotePago();
                objE.EjercicioLote = vEjercicio;
                objE.PeriodoLote = vPeriodo;
             
                FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
                objBOMnt.UpdateComprobanteProveedor(objE);
                message.Status = JsonMessageStatus.SUCCESS;
            }
            catch (Exception e)
            {
                message.Status = JsonMessageStatus.INVALID;
                message.Message = e.Message;
            }
            return Json(message);
        }
    }
}
