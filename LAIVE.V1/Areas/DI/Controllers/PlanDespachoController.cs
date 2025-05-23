using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Di;
using System.Web.Script.Serialization;
using DIBOMnt = Laive.BOMnt.Di;
using DIBOQry = Laive.BOQry.Di;
using DIBORpt = Laive.BORpt.Di;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Data;
using System.Text;
using Ionic.Zip;
using System.Xml.Linq;
using System.Xml;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.DI.Controllers
{
   public class PlanDespachoController : SamcontrollerBase
   {
      [HttpGet]
      public PartialViewResult Index()
      {
         return PartialView("Index");
      }

      [HttpGet]
      public PartialViewResult GetPlanDespacho(string FechaDespacho)
      {
         Session["FechaDespacho"] = FechaDespacho;

         IBOQuery objBORuta = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Ruta));
         ERuta eRuta = new ERuta();
         EntitySelect eItem = new EntitySelect();
         eItem.value = "";
         eItem.text = ".:: Seleccione ::.";
         List<EntitySelect> listItem = objBORuta.GetListForSelect(eRuta).ToList();
         listItem.Insert(0, eItem);
         ViewBag.Ruta = listItem;

         IBOQuery objBOTurno = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Turno));
         ETurno eTurno = new ETurno();
         ViewBag.Turno = objBOTurno.GetListForSelect(eTurno);

         IBOQuery objBOBox = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Box));
         EBox eBFrio = new EBox();
         eBFrio.TipoCarga = "F";
         ViewBag.BFrio = objBOBox.GetListForSelect(eBFrio);

         eBFrio.TipoCarga = "S";
         ViewBag.BSeco = objBOBox.GetListForSelect(eBFrio);

         IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         EAlmacen eAlmacen = new EAlmacen();

         ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         ViewBag.ListAlmacen = listAlma;
         var jsonSerialiser = new JavaScriptSerializer();
         ViewBag.ListAlmacenString = jsonSerialiser.Serialize(listAlma);
         ViewBag.fechaDespacho = Session["FechaDespacho"].ToString();


         EPedidoOperacion EPediOpe = new EPedidoOperacion();
         EPediOpe.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
         EPediOpe.CodigoPartner = "";
         DIBOQry.IPedidoOperacion Bo = (DIBOQry.IPedidoOperacion)WCFHelper.GetObject<DIBOQry.IPedidoOperacion>(typeof(DIBOQry.PedidoOperacion));
         ETotalesPedidoOperacion ETotal = new ETotalesPedidoOperacion();
         ETotal = (ETotalesPedidoOperacion)Bo.GetTotalesByIdUser(EPediOpe);

         ViewBag.ImporteFrios = ETotal.ImporteFrios;
         ViewBag.ImporteSecos = ETotal.ImporteSecos;
         ViewBag.PesoFrios = ETotal.PesoFrios;
         ViewBag.PesoSecos = ETotal.PesoSecos;
         ViewBag.TotalImporte = ETotal.TotalImporte;
         ViewBag.TotalPeso = ETotal.TotalPeso;

         return PartialView("GetPlanDespacho");
      }


      [HttpPost]
      public JsonResult GetDataGrdPeConso(FlexigridParamSamNet Param)
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.PedidoConsolidado));
         EPedidoConsolidado objE = new EPedidoConsolidado();
         var ActProy = objBO.GetByCriteria<EPedidoConsolidado>(objE);
         JsonSamNet jsonR = new JsonSamNet();
         jsonR.rows = jsonR.resultArray<EPedidoConsolidado>(objE.ColumnSet(), ActProy);

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdPeFrios(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.PedidoOperacion));
            EPedidoOperacion objE = new EPedidoOperacion();
            objE.IdRuta = int.Parse(values[0]);
            objE.CodigoPartner = values[1];
            objE.TipoCarga = values[2];
            if (values[3] != "null")
               objE.Stpo = Boolean.Parse(values[3]);
            objE.IsUpdate = Boolean.Parse(values[4]);
            objE.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();

            var ActProy = objBO.GetByCriteria<EPedidoOperacion>(objE);
            jsonR.rows = jsonR.resultArray<EPedidoOperacion>(objE.ColumnSet(), ActProy);
         }

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdPeSecos(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.PedidoOperacion));
            EPedidoOperacion objE = new EPedidoOperacion();
            objE.IdRuta = int.Parse(values[0]);
            objE.CodigoPartner = values[1];
            objE.TipoCarga = values[2];
            if (values[3] != "null")
               objE.Stpo = Boolean.Parse(values[3]);
            objE.IsUpdate = Boolean.Parse(values[4]);
            objE.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();

            var ActProy = objBO.GetByCriteria<EPedidoOperacion>(objE);
            jsonR.rows = jsonR.resultArray<EPedidoOperacion>(objE.ColumnSet(), ActProy);
         }

         return Json(jsonR);
      }
      
      [HttpPost]
      public JsonResult GetDataGrdApertura(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            DIBOQry.IPedidoOperacion objBO = (DIBOQry.IPedidoOperacion)WCFHelper.GetObject<DIBOQry.IPedidoOperacion>(typeof(DIBOQry.PedidoOperacion));
            EPedidoOperacion objE = new EPedidoOperacion();
            objE.IdRuta = int.Parse(values[0]);
            objE.CodigoPartner = values[1];
            objE.TipoCarga = values[2];
            objE.CodigoArticulo = values[3];
            objE.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
            var ActProy = objBO.GetApertura<EPedidoOperacion>(objE);
            jsonR.rows = jsonR.resultArray<EPedidoOperacion>(objE.ColumnSetApertura(), ActProy);
         }

         return Json(jsonR);
      }
      
      [HttpPost]
      public JsonResult GetDataGrdCaProgra(FlexigridParamSamNet Param)
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.CargaUnidad));
         ECargaUnidad objE = new ECargaUnidad();
         objE.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
         objE.Estado = ConstEstadoUnidadCarga.PROGRAMADO;
         var ActProy = objBO.GetByCriteria<ECargaUnidad>(objE);
         JsonSamNet jsonR = new JsonSamNet();

         jsonR.rows = jsonR.resultArray<ECargaUnidad>(objE.ColumnSet(), ActProy);

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdCaCerrado(FlexigridParamSamNet Param)
      {
         DIBOQry.ICargaUnidad objBO = (DIBOQry.ICargaUnidad)WCFHelper.GetObject<DIBOQry.ICargaUnidad>(typeof(DIBOQry.CargaUnidad));
         ECargaUnidad objE = new ECargaUnidad();
         objE.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
         objE.Estado = ConstEstadoUnidadCarga.CERRADO;
         var ActProy = objBO.GetCamionCerrado<ECargaUnidad>(objE);
         JsonSamNet jsonR = new JsonSamNet();

         jsonR.rows = jsonR.resultArray<ECargaUnidad>(objE.ColumnSetCerrado(), ActProy);

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdCaConso(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            DIBOQry.IPedidoConsolidado objBO = (DIBOQry.IPedidoConsolidado)WCFHelper.GetObject<DIBOQry.IPedidoConsolidado>(typeof(DIBOQry.PedidoConsolidado));
            EPedidoConsolidado objE = new EPedidoConsolidado();
            var CaConso = objBO.CamConsoXIdCargaUnidad<EPedidoConsolidado>(int.Parse(Param.query));
            jsonR.rows = jsonR.resultArray<EPedidoConsolidado>(objE.ColumnSetForCamionConsolidado(), CaConso);

         }

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdCaFrios(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            DIBOQry.ICargaUnidadOperacion objBO = (DIBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOQry.ICargaUnidadOperacion>(typeof(DIBOQry.CargaUnidadOperacion));
            ECargaUnidadOperacion objE = new ECargaUnidadOperacion();
            objE.IdCargaUnidad = int.Parse(values[0]);
            objE.CodigoPartner = values[1];
            objE.TipoCarga = ConstTipoCarga.FRIOS;

            var CaConso = objBO.CaUnidOpeXUnidadXPartner<ECargaUnidadOperacion>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadOperacion>(objE.ColumnSet(), CaConso);

         }

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdCaSecos(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            DIBOQry.ICargaUnidadOperacion objBO = (DIBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOQry.ICargaUnidadOperacion>(typeof(DIBOQry.CargaUnidadOperacion));
            ECargaUnidadOperacion objE = new ECargaUnidadOperacion();
            objE.IdCargaUnidad = int.Parse(values[0]);
            objE.CodigoPartner = values[1];
            objE.TipoCarga = ConstTipoCarga.SECOS;

            var CaConso = objBO.CaUnidOpeXUnidadXPartner<ECargaUnidadOperacion>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadOperacion>(objE.ColumnSet(), CaConso);

         }

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdFacturas(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            DIBOQry.ICargaUnidadOperacion objBO = (DIBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOQry.ICargaUnidadOperacion>(typeof(DIBOQry.CargaUnidadOperacion));
            ECargaUnidadFactura objE = new ECargaUnidadFactura();
            objE.IdCargaUnidad = int.Parse(values[0]);

            var varFacturas = objBO.GetFacturasXCargaUnidad<ECargaUnidadFactura>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadFactura>(objE.ColumnSet(), varFacturas);

         }

         return Json(jsonR);
      }
      
      [HttpPost]
      public JsonResult GetDataUnidadesDisponibles(FlexigridParamSamNet Param)
      {

         DIBOQry.IUnidad objBO = (DIBOQry.IUnidad)WCFHelper.GetObject<DIBOQry.IUnidad>(typeof(DIBOQry.Unidad));
         EUnidad objE = new EUnidad();
         objE.FechaDespacho = DateTime.Parse(Session["FechaDespacho"].ToString());

         var ActProy = objBO.GetUnidadDisponible<EUnidad>(objE);
         JsonSamNet jsonR = new JsonSamNet();

         jsonR.rows = jsonR.resultArray<EUnidad>(objE.ColumnSetUnidadDisponible(), ActProy);

         return Json(jsonR);
      }


      [HttpPost]
      public JsonResult GetDataPlantillaCamion(FlexigridParamSamNet Param)
      {

         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Plantilla));
         EPlantilla objE = new EPlantilla();
         var ActProy = objBO.GetByCriteria<EPlantilla>(objE);
         JsonSamNet jsonR = new JsonSamNet();
         jsonR.rows = jsonR.resultArray<EPlantilla>(objE.ColumnSet(), ActProy);

         jsonR.total = jsonR.total != 0 ? jsonR.total : 1;

         return Json(jsonR);
      }

      [HttpPost]
      public int UpdateAddCamion(string IdTrans, string IdUnidad, string IdRuta, decimal MtFrio, decimal MtSeco)
      {
         DateTime FechaDespacho = DateTime.Parse(Session["FechaDespacho"].ToString());
         DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));
         return objBO.UpdateAddCamion(IdTrans, IdUnidad, FechaDespacho, int.Parse(IdRuta), MtFrio, MtSeco);
      }

      [HttpPost]
      public int CargarMercaderia(int idCargaUnidad)
      {
         DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
         ECargaUnidad Eobj = new ECargaUnidad();
         Eobj.IdCargaUnidad = idCargaUnidad;
         Eobj.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();

         objBO.CargarCamion(Eobj);

         return 0;
      }

      [HttpPost]
      public int RetirarCamion(int idCargaUnidad)
      {
         DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
         objBO.RetirarCamion(idCargaUnidad);
         return 0;
      }

      [HttpPost]
      public int CerrarCamion(string idCargaUnidad)
      {

         string[] values = idCargaUnidad.Split(';');

         foreach (string value in values)
         {
            DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
            objBO.CerrarCamion(Convert.ToInt32(value));
         }
         return 0;
      }

      [HttpPost]
      public int OpenCamion(int idCargaUnidad)
      {
         DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
         objBO.OpenCamion(idCargaUnidad);
         return 0;
      }


      [HttpPost]
      public JsonResult UpdateTurnoBox(int IdCargaUnidad, int IdTurnoSeco, int IdTurnoFrio, int IdBoxSeco, int IdBoxFrio)
      {

          JsonMessage message = new JsonMessage();
          try
          {
              DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));
              ECargaUnidad eCUni = new ECargaUnidad();

              eCUni.IdCargaUnidad = IdCargaUnidad;
              eCUni.IdTurno_Seco = IdTurnoSeco;
              eCUni.IdTurno_Frio = IdTurnoFrio;
              eCUni.IdBox_Seco = IdBoxSeco;
              eCUni.IdBox_Frio = IdBoxFrio;
              eCUni.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());

              DIBOQry.ICargaUnidad objBOQry = (DIBOQry.ICargaUnidad)WCFHelper.GetObject<DIBOQry.ICargaUnidad>(typeof(DIBOQry.CargaUnidad));

              if (IdTurnoFrio != 0 && IdBoxFrio != 0 && objBOQry.ExistsTurnoBoxFrio(eCUni))
              {
                  message.Status = JsonMessageStatus.INFORMATION;
                  message.Message = "El turno box para Frios ya fue asignado a otro camion.";
              }
              else if (IdTurnoSeco != 0 && IdBoxSeco != 0 && objBOQry.ExistsTurnoBoxSeco(eCUni))
              {
                  message.Status = JsonMessageStatus.INFORMATION;
                  message.Message = "El turno box para Secos ya fue asignado a otro camion.";
              }
              else
              {
                  objBO.UpdateTurnoBox(eCUni);
                  message.Status = JsonMessageStatus.SUCCESS;
              }
          }
          catch (Exception e)
          {
              message.Status = JsonMessageStatus.INVALID;
              message.Message = e.Message;
          }

          return Json(message);

      }

      [HttpGet]
      public JsonResult UpdateStpo(EPedidoOperacion EPediOpe)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         EPediOpe.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
         objBO.UpdateStpo(EPediOpe);
               
         return Json("",JsonRequestBehavior.AllowGet);
      }

      [HttpGet]
      public JsonResult UpdateStpoApertura(EPedidoOperacion EPediOpe)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         EPediOpe.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
         objBO.UpdateStpoApertura(EPediOpe);
         
         return Json("", JsonRequestBehavior.AllowGet);
      }



      [HttpPost]
      public JsonResult GetTotalesPedidoConsolidado(string Partner)
      {
         EPedidoOperacion EPediOpe = new EPedidoOperacion();
         EPediOpe.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
         EPediOpe.CodigoPartner = Partner;
         DIBOQry.IPedidoOperacion Bo = (DIBOQry.IPedidoOperacion)WCFHelper.GetObject<DIBOQry.IPedidoOperacion>(typeof(DIBOQry.PedidoOperacion));
         ETotalesPedidoOperacion ETotal = new ETotalesPedidoOperacion();
         ETotal = (ETotalesPedidoOperacion)Bo.GetTotalesByIdUser(EPediOpe);




         return Json(ETotal);
      }

      [HttpPost]
      public int UpdateMarcarSelec(List<EPedidoOperacion> EPediOpe)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         foreach (EPedidoOperacion objE in EPediOpe)
         {
            objE.IdUserTkCarga = Session[ConstSessionVar.USERID].ToString();
         }

         return objBO.UpdateMarcarSelec(EPediOpe);
      }

      [HttpPost]
      public string ImportarOrdenVenta(string IdAlmacen, string IdOrdenDesde, string IdOrdenHasta)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         EAlmacen eAlmacen = new EAlmacen();
         eAlmacen.CodigoAlmacen = IdAlmacen;
         eAlmacen.IdOrdenDesde = IdOrdenDesde;
         eAlmacen.IdOrdenHasta = IdOrdenHasta;
         eAlmacen.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
         objBO.ImportarOrdenVenta(eAlmacen);

         IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         ViewBag.ListAlmacen = listAlma;
         var jsonSerialiser = new JavaScriptSerializer();


         return jsonSerialiser.Serialize(listAlma);
      }

      public FileStreamResult DownloadPDF(string IdCargaUnidad)
      {
         DIBORpt.CargaUnidad BORpt = new DIBORpt.CargaUnidad();

         DataTable dt = BORpt.GetRptConsolidado(IdCargaUnidad.Replace("_", ","));

         ReportDocument objRpt = new ReportDocument();

         //string path = System.Web.HttpContext.Current.Request.MapPath(ConstSistema.ROOT_FOLDER_PATH + "/DI_CargaUnidad_Rpt01.rpt");
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "DI_CargaUnidad_Rpt01.rpt");
         objRpt.Load(path);
         objRpt.SetDataSource(dt);

         MemoryStream ms = new MemoryStream();
         ms = (MemoryStream)objRpt.ExportToStream(ExportFormatType.PortableDocFormat);
         objRpt.Dispose();
         objRpt = null;


         return File(ms, "application/pdf", "RptConsolidado.pdf");
      }

      public FileStreamResult DownloadPDFDetalle(string IdCargaUnidad)
      {
         DIBORpt.CargaUnidad BORpt = new DIBORpt.CargaUnidad();

         DataTable dt = BORpt.GetRptDetalle(IdCargaUnidad.Replace("_", ","));

         ReportDocument objRpt = new ReportDocument();

         //string path = System.Web.HttpContext.Current.Request.MapPath(ConstSistema.ROOT_FOLDER_PATH + "/DI_CargaUnidad_Rpt01.rpt");
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "DI_CargaUnidad_Rpt02.rpt");
         objRpt.Load(path);
         objRpt.SetDataSource(dt);

         MemoryStream ms = new MemoryStream();
         ms = (MemoryStream)objRpt.ExportToStream(ExportFormatType.PortableDocFormat);
         objRpt.Dispose();
         objRpt = null;


         return File(ms, "application/pdf", "RptDetalle.pdf");
      }

      public FileStreamResult DownloadPDFPackinLC(string IdCargaUnidad)
      {
         DIBORpt.CargaUnidad BORpt = new DIBORpt.CargaUnidad();

         DataTable dt = BORpt.GetRptPackingListConsolidado(IdCargaUnidad.Replace("_", ","));

         ReportDocument objRpt = new ReportDocument();

         //string path = System.Web.HttpContext.Current.Request.MapPath(ConstSistema.ROOT_FOLDER_PATH + "/DI_CargaUnidad_Rpt01.rpt");
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "DI_CargaUnidad_Rpt03.rpt");
         objRpt.Load(path);
         objRpt.SetDataSource(dt);

         MemoryStream ms = new MemoryStream();
         ms = (MemoryStream)objRpt.ExportToStream(ExportFormatType.PortableDocFormat);
         objRpt.Dispose();
         objRpt = null;


         return File(ms, "application/pdf", "RptPackingListConsolidado.pdf");
      }

      public FileStreamResult DownloadPDFPackinLD(string IdCargaUnidad)
      {
         DIBORpt.CargaUnidad BORpt = new DIBORpt.CargaUnidad();

         DataTable dt = BORpt.GetRptPackingListDetallado(IdCargaUnidad.Replace("_", ","));

         ReportDocument objRpt = new ReportDocument();

         //string path = System.Web.HttpContext.Current.Request.MapPath(ConstSistema.ROOT_FOLDER_PATH + "/DI_CargaUnidad_Rpt01.rpt");
         string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "DI_CargaUnidad_Rpt04.rpt");
         objRpt.Load(path);
         objRpt.SetDataSource(dt);

         MemoryStream ms = new MemoryStream();
         ms = (MemoryStream)objRpt.ExportToStream(ExportFormatType.PortableDocFormat);
         objRpt.Dispose();
         objRpt = null;


         return File(ms, "application/pdf", "RptPackingListDetallado.pdf");
      }

      [HttpPost]
      public int UpdateFactura()
      {
         DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));
         ECargaUnidad eCargaUnidad = new ECargaUnidad();
         eCargaUnidad.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());

         return objBO.UpdateFactura(eCargaUnidad);
      }

      [HttpPost]
      public int DividirLinea(List<EPedidoOperacion> EObj)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         return objBO.DividirLinea(EObj); ;
      }

      [HttpPost]
      public int RetirarCaXPartner(int IdCargoUnidad, string CodigoPartner)
      {
         DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
         objBO.RetirarCaXPartner(IdCargoUnidad, CodigoPartner);
         return 0;
      }

      [HttpPost]
      public int RetirarCaXFrioPorOrden(int IdCargoUnidad, string Orden)
      {
          DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
          objBO.RetirarCaXFrioPorOrden(IdCargoUnidad, Orden);
          return 0;
      }

      [HttpPost]
      public int RetirarCaXFrio(int IdCargoUnidad, string Orden, int Linea, int Sublinea)
      {
         DIBOMnt.ICargaUnidadOperacion objBO = (DIBOMnt.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOMnt.ICargaUnidadOperacion>(typeof(DIBOMnt.CargaUnidadOperacion));
         objBO.RetirarCaXFrio(IdCargoUnidad, Orden, Linea, Sublinea);
         return 0;
      }

      [HttpPost]
      public JsonResult GenerateDataXml()
      {
         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.CargaUnidad BOMnt = new DIBOMnt.CargaUnidad();
            ICollection<EDatosXml> eXml = BOMnt.GenerateXML(DateTime.Parse(Session["FechaDespacho"].ToString()), this.GetParametroSistemaString(ConstParametroSistema.RUTA_XML_DISTRIBUCION), this.GetParametroSistemaString(ConstParametroSistema.RUTA_XML_DISTRIBUCION_BACKUP));
            if (eXml.Count > 0)
            {
               //CreateZipFile(eXml);

               message.Status = JsonMessageStatus.SUCCESS;
               message.Message = "Datos Generados Correctamente.";
            }
            else
            {
               message.Status = JsonMessageStatus.WARNING;
               message.Message = "No se encontraron nuevas Ordenes.";
            }
         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;

         }

         return Json(message);
      }

      [HttpGet]
      public JsonResult GetBuscarCliente(string DsBusqueda)
      {
         ECargaUnidad eCargaUnidad = new ECargaUnidad();
         eCargaUnidad.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
         eCargaUnidad.EntityFilter = DsBusqueda;
         DIBOQry.ICargaUnidadOperacion Bo = (DIBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<DIBOQry.ICargaUnidadOperacion>(typeof(DIBOQry.CargaUnidadOperacion));

         ICollection<ECargaUnidad> list = Bo.GetBuscarCliente<ECargaUnidad>(eCargaUnidad);

         var JsonList = from a in list.AsEnumerable()
                        select new { IdCargaUnidad = a.IdCargaUnidad };
         return Json(JsonList, JsonRequestBehavior.AllowGet);
      }

      [HttpPost]
      public JsonResult CambiarPartnerToCamion(List<ECargaUnidadChangePartner> listCargaUnidad)
      {

         JsonMessage message = new JsonMessage();
         try
         { 
            DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));

            objBO.CambiarPartnerToCamion(listCargaUnidad);

         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;
         }

         return Json(message);
      }

      [HttpPost]
      public JsonResult CambiarCamion(int idCargaUnidad, int newIdCargaUnidad)
      {

         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));
            objBO.CambiarCamion(idCargaUnidad,newIdCargaUnidad);

         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;
         }

         return Json(message);
      }

      [HttpPost]
      public JsonResult CreatePlantilla(string nombre)
      {

         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.IPlantilla objBO = (DIBOMnt.IPlantilla)WCFHelper.GetObject<DIBOMnt.IPlantilla>(typeof(DIBOMnt.Plantilla));
            objBO.CreatePlantilla(nombre, DateTime.Parse(Session["FechaDespacho"].ToString()));
            message.Status = JsonMessageStatus.SUCCESS;
            message.Message = "Plantilla Creada con Exito";

         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;
         }

         return Json(message);
      }

      [HttpPost]
      public JsonResult CargarPlantilla(int codigoPlantilla)
      {

         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.IPlantilla objBO = (DIBOMnt.IPlantilla)WCFHelper.GetObject<DIBOMnt.IPlantilla>(typeof(DIBOMnt.Plantilla));
            objBO.CargarPlantilla(codigoPlantilla,DateTime.Parse(Session["FechaDespacho"].ToString()));
            message.Status = JsonMessageStatus.SUCCESS;
            message.Message = "La Plantilla se cargo con Exito";

         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;
         }

         return Json(message);
      }
      
      [HttpPost]
      public JsonResult RetirarPedidoConsolidado(int idRuta, string codigoPartner, string tipoCarga)
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
            EOrdenVenta objE = new EOrdenVenta();
            objE.IdRuta = idRuta;
            objE.CodigoPartner = codigoPartner;
            objE.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
            objBO.RetirarPedidoConsolidado(objE);

            messageJson.Message = "Datos Retirados Correctamente.";
            messageJson.Status = JsonMessageStatus.SUCCESS;
            return Json(messageJson);
         }
         catch (Exception ex)
         {
            messageJson.Message = ex.Message;
            messageJson.Status = JsonMessageStatus.INVALID;
            return Json(messageJson);
         }
      
      
      }

      [HttpPost]
      public JsonResult ExpedirCamion(string idCargaUnidad)
      {

         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.ICargaUnidad objBO = (DIBOMnt.ICargaUnidad)WCFHelper.GetObject<DIBOMnt.ICargaUnidad>(typeof(DIBOMnt.CargaUnidad));
            objBO.ExpedirCamion(idCargaUnidad);

            message.Status = JsonMessageStatus.SUCCESS;
            message.Message = "El camion fue expedido con exito.";

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
