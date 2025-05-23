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
using LGBOQry = Laive.BOQry.Di;
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
   public class ConsultaProgramacionController : SamcontrollerBase
   {
      [HttpGet]
      public PartialViewResult Index()
      {
         return PartialView("Index");
      }

      [HttpGet]
      public PartialViewResult GetConsultaProgramacion(string FechaDespacho)
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
         LGBOQry.IPedidoOperacion Bo = (LGBOQry.IPedidoOperacion)WCFHelper.GetObject<LGBOQry.IPedidoOperacion>(typeof(LGBOQry.PedidoOperacion));
         ETotalesPedidoOperacion ETotal = new ETotalesPedidoOperacion();
         ETotal = (ETotalesPedidoOperacion)Bo.GetTotalesByIdUser(EPediOpe);

         ViewBag.ImporteFrios = ETotal.ImporteFrios;
         ViewBag.ImporteSecos = ETotal.ImporteSecos;
         ViewBag.PesoFrios = ETotal.PesoFrios;
         ViewBag.PesoSecos = ETotal.PesoSecos;
         ViewBag.TotalImporte = ETotal.TotalImporte;
         ViewBag.TotalPeso = ETotal.TotalPeso;

         return PartialView("GetConsultaProgramacion");
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
            LGBOQry.IPedidoConsolidado objBO = (LGBOQry.IPedidoConsolidado)WCFHelper.GetObject<LGBOQry.IPedidoConsolidado>(typeof(LGBOQry.PedidoConsolidado));
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

            LGBOQry.ICargaUnidadOperacion objBO = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));
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

            LGBOQry.ICargaUnidadOperacion objBO = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));
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

            LGBOQry.ICargaUnidadOperacion objBO = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));
            ECargaUnidadFactura objE = new ECargaUnidadFactura();
            objE.IdCargaUnidad = int.Parse(values[0]);

            var varFacturas = objBO.GetFacturasXCargaUnidad<ECargaUnidadFactura>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadFactura>(objE.ColumnSet(), varFacturas);

         }

         return Json(jsonR);
      }
         
      [HttpPost]
      public JsonResult GetDataGrdSFacturas(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            LGBOQry.ICargaUnidadOperacion objBO = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));
            ECargaUnidadFactura objE = new ECargaUnidadFactura();
            objE.IdCargaUnidad = int.Parse(values[0]);

            var varFacturas = objBO.GetSFacturasXCargaUnidad<ECargaUnidadFactura>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadFactura>(objE.ColumnSetSFactura(), varFacturas);

         }

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataGrdOrdenesWMS(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            LGBOQry.ICargaUnidadOperacion objBO = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));
            ECargaUnidadFactura objE = new ECargaUnidadFactura();
            objE.IdCargaUnidad = int.Parse(values[0]);

            var varFacturas = objBO.GetOrdenesWMS<ECargaUnidadFactura>(objE);
            jsonR.rows = jsonR.resultArray<ECargaUnidadFactura>(objE.ColumnSetOrdenesWMS(), varFacturas);

         }

         return Json(jsonR);
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

      [HttpPost]
      public JsonResult GenerateDataXml()
      {
         JsonMessage message = new JsonMessage();
         try
         {
            string lcRutaWMS = this.GetParametroSistemaString(ConstParametroSistema.RUTA_XML_DISTRIBUCION);
            string lcRutaWMSBackup = this.GetParametroSistemaString(ConstParametroSistema.RUTA_XML_DISTRIBUCION_BACKUP);

            DIBOMnt.CargaUnidad BOMnt = new DIBOMnt.CargaUnidad();
            ICollection<EDatosXml> eXml = BOMnt.GenerateXML(DateTime.Parse(Session["FechaDespacho"].ToString()), lcRutaWMS, lcRutaWMSBackup);
            if (eXml.Count > 0)
            {
               TempData["_tempLisXML"] = eXml;
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

      [HttpPost]
      public JsonResult ReGenerateDataXml(int correlativo)
      {
         JsonMessage message = new JsonMessage();
         try
         {
            DIBOMnt.CargaUnidad BOMnt = new DIBOMnt.CargaUnidad();
            ICollection<EDatosXml> eXml = BOMnt.ReGenerateXML<EDatosXml>(DateTime.Parse(Session["FechaDespacho"].ToString()), correlativo);
            if (eXml.Count > 0)
            {
               TempData["_tempLisXML"] = eXml;
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

      [HttpPost]
      public JsonResult GetListZipFile()
      {
         JsonMessage message = new JsonMessage();
         try
         {
            DIBOQry.OrdenCorrelativoXml boQry = new DIBOQry.OrdenCorrelativoXml();
            EOrdenCorrelativoXml objE = new EOrdenCorrelativoXml();
            objE.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());

            ICollection<EOrdenCorrelativoXml> eXml = boQry.GetByCriteria<EOrdenCorrelativoXml>(objE);
            if (eXml.Count > 0)
            {
               message.Status = JsonMessageStatus.SUCCESS;
               message.Message = "Archivos Generados Correctamente.";
               List<object> objList = new List<object>();
               foreach (EOrdenCorrelativoXml eOrden in eXml)
               {
                  objList.Add(new { fileName = string.Concat(eOrden.FechaPrograma.ToString("dd_MM_yyyy"), "_", eOrden.CorrelativoFile.ToString("000"), ".zip"), llave = eOrden.CorrelativoFile });
               }
               message.Data = objList;

            }
            else
            {

               message.Status = JsonMessageStatus.WARNING;
               message.Message = "No se encontraron archivos.";
            }
         }
         catch (Exception e)
         {
            message.Status = JsonMessageStatus.INVALID;
            message.Message = e.Message;

         }

         return Json(message);



      }

      public FileStreamResult GenerarZipXML()
      {
         ICollection<EDatosXml> eXml = TempData["_tempLisXML"] as ICollection<EDatosXml>;
         MemoryStream zipStream = CreateZipFile(eXml);
         return File(zipStream, "application/octet-stream", string.Concat(DateTime.Parse(Session["FechaDespacho"].ToString()).ToString("dd_MM_yyyy"), "_", eXml.FirstOrDefault().NumberFile.ToString("000"), ".zip"));
      }

      private MemoryStream CreateZipFile(ICollection<EDatosXml> eXml)
      {

         ICollection<EDatosXml> eXmlHeader = (from eHeader in eXml
                                              group eHeader by new
                                              {
                                                 eHeader.Orden,
                                                 eHeader.Sporden,
                                                 eHeader.CodigoPartner,
                                                 eHeader.ClavePartner,
                                                 eHeader.Turno,
                                                 eHeader.Locacion,
                                                 eHeader.Entidad,
												 eHeader.IdBox,
                                                 eHeader.CodigoBox,
                                                 eHeader.CodigoGrupo
                                              }
                                                 into grupo
                                                 select new EDatosXml
                                                 {
                                                    Orden = grupo.Key.Orden,
                                                    Sporden = grupo.Key.Sporden,
                                                    CodigoPartner = grupo.Key.CodigoPartner,
                                                    ClavePartner = grupo.Key.ClavePartner,
                                                    Turno = grupo.Key.Turno,
                                                    Locacion = grupo.Key.Locacion,
                                                    Entidad = grupo.Key.Entidad,
                                                    CodigoBox = grupo.Key.CodigoBox,
                                                    CodigoGrupo = grupo.Key.CodigoGrupo
                                                 }).ToList();

         MemoryStream zipStream = new MemoryStream();
         ZipFile zipfile = new ZipFile();


         foreach (EDatosXml obje in eXmlHeader)
         {


            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "iso-8859-1", null);
            xmlDoc.AppendChild(declaration);

            XmlNode rootNode = xmlDoc.CreateElement("ProcessShipment");
            xmlDoc.AppendChild(rootNode);
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "xmlns", "http://schema.infor.com/InforOAGIS/2"));
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "releaseID", "9.2"));
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "versionID", "2.8.0"));

            /*ApplicationArea*/

            XmlNode apliArea = xmlDoc.CreateElement("ApplicationArea");
            XmlNode sender = xmlDoc.CreateElement("Sender");
            XmlNode logicalID = xmlDoc.CreateElement("LogicalID");
            logicalID.InnerText = "lid://infor.baan.conex-bann";
            sender.AppendChild(logicalID);
            XmlNode ComponentID = xmlDoc.CreateElement("ComponentID");
            ComponentID.InnerText = "erp";
            sender.AppendChild(ComponentID);
            XmlNode ConfirmationCode = xmlDoc.CreateElement("ConfirmationCode");
            ConfirmationCode.InnerText = "OnError";
            sender.AppendChild(ConfirmationCode);
            apliArea.AppendChild(sender);

            XmlNode CreationDateTime = xmlDoc.CreateElement("CreationDateTime");
            CreationDateTime.InnerText = DateTime.Now.ToString().Replace("/", "-");
            apliArea.AppendChild(CreationDateTime);

            XmlNode BODID = xmlDoc.CreateElement("BODID");
            BODID.InnerText = "infor-nid:INFOR:AE1:08:0000000007:1?Shipment&verb=Process";
            apliArea.AppendChild(BODID);

            rootNode.AppendChild(apliArea);

            /*DataArea*/

            XmlNode DataArea = xmlDoc.CreateElement("DataArea");
            XmlNode Process = xmlDoc.CreateElement("Process");

            XmlNode TenantID = xmlDoc.CreateElement("TenantID");
            TenantID.InnerText = "INFOR";
            Process.AppendChild(TenantID);

            XmlNode AccountingEntityID = xmlDoc.CreateElement("AccountingEntityID");
            AccountingEntityID.InnerText = "LAIVE";
            Process.AppendChild(AccountingEntityID);

            XmlNode LocationID = xmlDoc.CreateElement("LocationID");
            LocationID.InnerText = obje.Locacion.Trim();
            Process.AppendChild(LocationID);

            XmlNode ActionCriteria = xmlDoc.CreateElement("ActionCriteria");

            XmlNode ActionExpression = xmlDoc.CreateElement("ActionExpression");
            ActionExpression.Attributes.Append(CreateAttribute(xmlDoc, "actionCode", "Add"));
            ActionCriteria.AppendChild(ActionExpression);
            Process.AppendChild(ActionCriteria);
            DataArea.AppendChild(Process);

            XmlNode Shipment = xmlDoc.CreateElement("Shipment");

            XmlNode ShipmentHeader = xmlDoc.CreateElement("ShipmentHeader");
            XmlNode DocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode ID = xmlDoc.CreateElement("ID");
            ID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", "LAIVE"));
            ID.Attributes.Append(CreateAttribute(xmlDoc, "location", obje.Locacion.Trim()));
            ID.Attributes.Append(CreateAttribute(xmlDoc, "variationID", "1"));
            ID.InnerText = obje.Sporden;
            DocumentID.AppendChild(ID);
            ShipmentHeader.AppendChild(DocumentID);

            XmlNode Note = xmlDoc.CreateElement("Note");
            Note.InnerText = obje.Orden;
            ShipmentHeader.AppendChild(Note);
            XmlNode DockID = xmlDoc.CreateElement("DockID");
            DockID.InnerText = obje.CodigoBox;
            ShipmentHeader.AppendChild(DockID);

            XmlNode CarrierRouteReference = xmlDoc.CreateElement("CarrierRouteReference");
            XmlNode RouteStop = xmlDoc.CreateElement("RouteStop");
            XmlNode RouteStopID = xmlDoc.CreateElement("ID");
            RouteStopID.InnerText = obje.CodigoPartner;
            RouteStop.AppendChild(RouteStopID);
            CarrierRouteReference.AppendChild(RouteStop);
            ShipmentHeader.AppendChild(CarrierRouteReference);

            XmlNode DocumentReference = xmlDoc.CreateElement("DocumentReference");
            DocumentReference.Attributes.Append(CreateAttribute(xmlDoc, "type", "SalesOrder"));
            XmlNode DocRefDocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode DocRefDocumentIDID = xmlDoc.CreateElement("ID");
            DocRefDocumentIDID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", obje.ClavePartner.Trim()));
            DocRefDocumentIDID.Attributes.Append(CreateAttribute(xmlDoc, "location", obje.CodigoPartner));
            DocRefDocumentIDID.InnerText = obje.Turno;
            DocRefDocumentID.AppendChild(DocRefDocumentIDID);
            DocumentReference.AppendChild(DocRefDocumentID);
            ShipmentHeader.AppendChild(DocumentReference);

            XmlNode AlternateDocumentID = xmlDoc.CreateElement("AlternateDocumentID");
            XmlNode AlternateDocumentIDID = xmlDoc.CreateElement("ID");
            AlternateDocumentIDID.InnerText = obje.Sporden;
            AlternateDocumentID.AppendChild(AlternateDocumentIDID);
            ShipmentHeader.AppendChild(AlternateDocumentID);

            XmlNode DocumentDateTime = xmlDoc.CreateElement("DocumentDateTime");
            DocumentDateTime.InnerText = DateTime.Now.ToString().Replace("/", "-");
            ShipmentHeader.AppendChild(DocumentDateTime);

            XmlNode Status = xmlDoc.CreateElement("Status");
            XmlNode Code = xmlDoc.CreateElement("Code");
            Code.Attributes.Append(CreateAttribute(xmlDoc, "listID", "ShipmentStatus"));
            Code.InnerText = "Open";
            Status.AppendChild(Code);
            ShipmentHeader.AppendChild(Status);

            XmlNode WarehouseLocation = xmlDoc.CreateElement("WarehouseLocation");
            XmlNode WarehouseLocationID = xmlDoc.CreateElement("ID");
            WarehouseLocationID.InnerText = obje.Entidad.Trim();
            WarehouseLocation.AppendChild(WarehouseLocationID);
            XmlNode Name = xmlDoc.CreateElement("Name");
            Name.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
            Name.InnerText = "LAIVE";
            WarehouseLocation.AppendChild(Name);
            ShipmentHeader.AppendChild(WarehouseLocation);

            XmlNode ShipFromParty = xmlDoc.CreateElement("ShipFromParty");
            XmlNode Location = xmlDoc.CreateElement("Location");
            Location.Attributes.Append(CreateAttribute(xmlDoc, "type", "Warehouse"));
            XmlNode varLocationID = xmlDoc.CreateElement("ID");
            varLocationID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", obje.Locacion.Trim()));
            varLocationID.InnerText = obje.Entidad.Trim();
            Location.AppendChild(varLocationID);
            XmlNode LocationName = xmlDoc.CreateElement("Name");
            LocationName.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
            LocationName.InnerText = "LAIVE";
            Location.AppendChild(LocationName);
            ShipFromParty.AppendChild(Location);
            ShipmentHeader.AppendChild(ShipFromParty);

            //Se comeneto por el correo de Elizabeth
            //XmlNode ShipToParty = xmlDoc.CreateElement("ShipToParty");
            //XmlNode PartyIDs = xmlDoc.CreateElement("PartyIDs");
            //XmlNode PartyIDsID = xmlDoc.CreateElement("ID");
            //PartyIDsID.InnerText = obje.CodigoGrupo;
            //PartyIDs.AppendChild(PartyIDsID);
            //ShipToParty.AppendChild(PartyIDs);
            //ShipmentHeader.AppendChild(ShipToParty);

            XmlNode varCarrierRouteReference = xmlDoc.CreateElement("CarrierRouteReference");
            XmlNode varDocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode varDocumentIDID = xmlDoc.CreateElement("ID");
            varDocumentIDID.InnerText = obje.Turno;
            varDocumentID.AppendChild(varDocumentIDID);
            varCarrierRouteReference.AppendChild(varDocumentID);
            ShipmentHeader.AppendChild(varCarrierRouteReference);

            XmlNode PartialShipmentAllowedIndicator = xmlDoc.CreateElement("PartialShipmentAllowedIndicator");
            PartialShipmentAllowedIndicator.InnerText = "true";
            ShipmentHeader.AppendChild(PartialShipmentAllowedIndicator);

            XmlNode PriorityCode = xmlDoc.CreateElement("PriorityCode");
            PriorityCode.InnerText = "5";
            ShipmentHeader.AppendChild(PriorityCode);
            Shipment.AppendChild(ShipmentHeader);

            ICollection<EDatosXml> eXmlDetails = eXml.Where(x => x.Sporden == obje.Sporden).ToList();

            foreach (EDatosXml objDet in eXmlDetails)
            {
               XmlNode ShipmentItem = xmlDoc.CreateElement("ShipmentItem");
               XmlNode ItemID = xmlDoc.CreateElement("ItemID");
               XmlNode ItemIDID = xmlDoc.CreateElement("ID");
               ItemIDID.InnerText = objDet.CodigoArticulo.Trim();
               ItemID.AppendChild(ItemIDID);
               ShipmentItem.AppendChild(ItemID);

               XmlNode ServiceIndicator = xmlDoc.CreateElement("ServiceIndicator");
               ServiceIndicator.InnerText = "false";
               ShipmentItem.AppendChild(ServiceIndicator);

               XmlNode Description = xmlDoc.CreateElement("Description");
               Description.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
               Description.InnerText = objDet.GlosaArticulo.Trim();
               ShipmentItem.AppendChild(Description);

               XmlNode OrderQuantity = xmlDoc.CreateElement("OrderQuantity");
               //Se comeneto por el correo de Elizabeth
               //OrderQuantity.Attributes.Append(CreateAttribute(xmlDoc, "unitCode", objDet.UnidadPedido.Trim()));
               OrderQuantity.InnerText = objDet.cantidadPedido.ToString().Trim().Replace(",", ".");
               ShipmentItem.AppendChild(OrderQuantity);

               XmlNode LineNumber = xmlDoc.CreateElement("LineNumber");
               LineNumber.InnerText = objDet.Linea.ToString();
               ShipmentItem.AppendChild(LineNumber);

               XmlNode HoldCodes = xmlDoc.CreateElement("HoldCodes");
               XmlNode HoldCodesCode = xmlDoc.CreateElement("Code");
               HoldCodesCode.Attributes.Append(CreateAttribute(xmlDoc, "listID", "Hold Reason Codes"));
               HoldCodes.AppendChild(HoldCodesCode);
               ShipmentItem.AppendChild(HoldCodes);
               Shipment.AppendChild(ShipmentItem);

            }

            DataArea.AppendChild(Shipment);
            rootNode.AppendChild(DataArea);
            xmlDoc.AppendChild(rootNode);

            Stream stream = new MemoryStream();
            //st.Position = 0;
            xmlDoc.Save(stream);
            stream.Flush();
            stream.Position = 0;
            zipfile.AddEntry(String.Concat("SalesOrder", obje.Sporden, ".xml"), stream);

         }


         zipfile.Save(zipStream);

         zipStream.Seek(0, 0);

         return zipStream;

      }

      private XmlAttribute CreateAttribute(XmlDocument xmlDoc, string nodo, string value)
      {
         XmlAttribute attribute = xmlDoc.CreateAttribute(nodo);
         attribute.Value = value;
         return attribute;
      }

      [HttpGet]
      public JsonResult GetBuscarCliente(string DsBusqueda)
      {
         ECargaUnidad eCargaUnidad = new ECargaUnidad();
         eCargaUnidad.FechaPrograma = DateTime.Parse(Session["FechaDespacho"].ToString());
         eCargaUnidad.EntityFilter = DsBusqueda;
         LGBOQry.ICargaUnidadOperacion Bo = (LGBOQry.ICargaUnidadOperacion)WCFHelper.GetObject<LGBOQry.ICargaUnidadOperacion>(typeof(LGBOQry.CargaUnidadOperacion));

         ICollection<ECargaUnidad> list = Bo.GetBuscarCliente<ECargaUnidad>(eCargaUnidad);

         var JsonList = from a in list.AsEnumerable()
                        select new { IdCargaUnidad = a.IdCargaUnidad };
         return Json(JsonList, JsonRequestBehavior.AllowGet);
      }

   }
}
