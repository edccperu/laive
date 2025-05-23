using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using LAIVE.V1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIBOQry = Laive.BOQry.Di;
using BIBOQry = Laive.BOQry.Bi;
using Laive.Entity.Di;
using Laive.Entity.Bi;
using System.Web.Script.Serialization;
using DIBOMnt = Laive.BOMnt.Di;
using Newtonsoft.Json;

namespace LAIVE.V1.Areas.DI.Controllers
{
   public class AsignacionPedidoController : SamcontrollerBase
   {
      [HttpGet]
      public PartialViewResult Index()
      {
         return PartialView("Index");
      }

      [HttpGet]
      public PartialViewResult GetAsignacionPedido(string fechaAsignacion, int tipoAsignacion)
      {
         IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         EAlmacen eAlmacen = new EAlmacen();
         ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         ViewBag.ListAlmacen = listAlma;
         ViewBag.TipoAsignacion = tipoAsignacion;
         var jsonSerialiser = new JavaScriptSerializer();
         ViewBag.ListAlmacenString = jsonSerialiser.Serialize(listAlma);
         Session["FechaAsignacion"] = fechaAsignacion;
         Session["TipoAsignacion"] = tipoAsignacion;
         ViewBag.fechaDespacho = fechaAsignacion;
         
         IBOQuery objBOCanalComercial = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.CanalComercial));
         ECanalComercial eCanalComercial = new ECanalComercial();
         ICollection<ECanalComercial> canalComercialLista = objBOCanalComercial.GetList<ECanalComercial>(eCanalComercial);
         string JsonCanalComercial = "";
         foreach (ECanalComercial eSel in canalComercialLista)
         {
            if (JsonCanalComercial != "")
               JsonCanalComercial = string.Concat(JsonCanalComercial, ",");
            JsonCanalComercial = string.Concat(JsonCanalComercial, "{text: '", string.Concat(eSel.Codigo, " - ", eSel.Glosa), "', value: '", eSel.Codigo, "'}");
         }
         ViewBag.ListaCanalComercial = JsonCanalComercial;
         

         IBOQuery BOtipoResultadoAsignacion = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.TipoResultadoAsignacion));
         ETipoResultadoAsignacion eTipoResultadoAsignacion = new ETipoResultadoAsignacion();
         ICollection<ETipoResultadoAsignacion> listTipoResultadoAsignacion = BOtipoResultadoAsignacion.GetList<ETipoResultadoAsignacion>(eTipoResultadoAsignacion);
         string JsonTipoResultadoAsignacion = "";
         foreach (ETipoResultadoAsignacion eSel in listTipoResultadoAsignacion)
         {
            if (JsonTipoResultadoAsignacion != "")
               JsonTipoResultadoAsignacion = string.Concat(JsonTipoResultadoAsignacion, ",");
            JsonTipoResultadoAsignacion = string.Concat(JsonTipoResultadoAsignacion, "{text: '", string.Concat(eSel.CodigoResultado, " - ", eSel.GlosaResultado), "', value: '", eSel.CodigoResultado, "'}");
         }
         ViewBag.TipoResultados = JsonTipoResultadoAsignacion;


         IBOQuery objBOCanalBaan = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanCanal));
         EBaanCanal eBaanCanal = new EBaanCanal();
         ICollection<EBaanCanal> listCanalBaan = objBOCanalBaan.GetList<EBaanCanal>(eBaanCanal);
         string JsonCanalBaan = "";
         foreach (EBaanCanal eSel in listCanalBaan)
         {
            if (JsonCanalBaan != "")
               JsonCanalBaan = string.Concat(JsonCanalBaan, ",");
            JsonCanalBaan = string.Concat(JsonCanalBaan, "{text: '", eSel.GlosaCanal, "', value: '", eSel.CodigoCanal, "'}");
         }
         ViewBag.CanalBaan = JsonCanalBaan;

         IBOQuery objBOPartner = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanPartner));
         EBaanPartner eBaanPartner = new EBaanPartner();
         ICollection<EBaanPartner> partnerLista = objBOPartner.GetList<EBaanPartner>(eBaanPartner);
         var JsonPartner = from partner in partnerLista select new { text = String.Concat(partner.CodigoPartner.Trim(), " - ", partner.ClavePartner1.Trim()), value = partner.CodigoPartner.Trim() };
         ViewBag.ListaPartner = JsonConvert.SerializeObject(JsonPartner);


         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanCategoria));
         EBaanCategoria eBaanCategoria = new EBaanCategoria();
         ICollection<EBaanCategoria> listCategoria = objBO.GetList<EBaanCategoria>(eBaanCategoria);
         string JsonCategoria = "";
         foreach (EBaanCategoria eSel in listCategoria)
         {
            if (JsonCategoria != "")
               JsonCategoria = string.Concat(JsonCategoria, ",");
            JsonCategoria = string.Concat(JsonCategoria, "{text: '", string.Concat(eSel.CodigoCategoria, " - ", eSel.GlosaCategoria), "', value: '", eSel.CodigoCategoria, "'}");
         }
         ViewBag.Categorias = JsonCategoria;


         IBOQuery objBOMarca = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanMarca));
         EBaanMarca eBaanMarca = new EBaanMarca();
         ICollection<EBaanMarca> listMarca = objBOMarca.GetList<EBaanMarca>(eBaanMarca);
         string JsonMarca = "";
         foreach (EBaanMarca eSel in listMarca)
         {
            if (JsonMarca != "")
               JsonMarca = string.Concat(JsonMarca, ",");
            JsonMarca = string.Concat(JsonMarca, "{text: '", string.Concat(eSel.CodigoMarca, " - ", eSel.GlosaMarca), "', value: '", eSel.CodigoMarca, "'}");
         }
         ViewBag.Marcas = JsonMarca;


         IBOQuery objBOSubMarca = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanSubMarca));
         EBaanSubMarca eBaanSubMarca = new EBaanSubMarca();
         ICollection<EBaanSubMarca> listSubMarca = objBOSubMarca.GetList<EBaanSubMarca>(eBaanSubMarca);
         string JsonSubMarca = "";
         foreach (EBaanSubMarca eSel in listSubMarca)
         {
            if (JsonSubMarca != "")
               JsonSubMarca = string.Concat(JsonSubMarca, ",");
            JsonSubMarca = string.Concat(JsonSubMarca, "{text: '", string.Concat(eSel.CodigoSubMarca, " - ", eSel.GlosaSubMarca), "', value: '", eSel.CodigoSubMarca, "'}");
         }
         ViewBag.SubMarcas = JsonSubMarca;


         IBOQuery objBOPresentacion = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanPresentacion));
         EBaanPresentacion eBaanPresentacion = new EBaanPresentacion();
         ICollection<EBaanPresentacion> listPresentacion = objBOPresentacion.GetList<EBaanPresentacion>(eBaanPresentacion);
         string JsonPresentacion = "";
         foreach (EBaanPresentacion eSel in listPresentacion)
         {
            if (JsonPresentacion != "")
               JsonPresentacion = string.Concat(JsonPresentacion, ",");
            JsonPresentacion = string.Concat(JsonPresentacion, "{text: '", string.Concat(eSel.CodigoPresentacion, " - ", eSel.GlosaPresentacion), "', value: '", eSel.CodigoPresentacion, "'}");
         }
         ViewBag.Presentaciones = JsonPresentacion;

         IBOQuery objBOBaanArticulo = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanArticulo));
         EBaanArticulo eBaanArticulo = new EBaanArticulo();
         ICollection<EBaanArticulo> articuloLista = objBOBaanArticulo.GetList<EBaanArticulo>(eBaanArticulo);
         string JsonArticulo = "";
         foreach (EBaanArticulo eSel in articuloLista)
         {
             if (JsonArticulo != "")
                 JsonArticulo = string.Concat(JsonArticulo, ",");
             JsonArticulo = string.Concat(JsonArticulo, "{text: '", string.Concat(eSel.CodigoArticulo, " - ", eSel.GlosaArticulo), "', value: '", eSel.CodigoArticulo, "'}");
         }
         ViewBag.ListaArticulo = JsonArticulo;

         return PartialView();
      }

      [HttpPost]
      public JsonResult GetDataArticulos(FlexigridParamSamNet Param)
      {
         DIBOQry.IOrdenVenta objBO = (DIBOQry.IOrdenVenta)WCFHelper.GetObject<DIBOQry.IOrdenVenta>(typeof(DIBOQry.OrdenVenta));
         EOrdenVentaArticulo objE = new EOrdenVentaArticulo();
         objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
         objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());

         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<FilterOperator> filtros = ser.Deserialize<List<FilterOperator>>(Param.query).OrderBy(x => x.fcampo).ToList();

            int countGroupWhere = 0;
            string pivotCampo = "";
            string where = "AND ";
            string whereGroup = "";


            foreach (FilterOperator item in filtros)
            {
               if (pivotCampo != item.fcampo)
               {
                  if (countGroupWhere != 0)
                  {
                     where = string.Concat(where, "( ", whereGroup, " ) AND");
                     whereGroup = "";
                  }

                  whereGroup = string.Concat(item.fcampo, " ", item.fconector, " '", item.fvalue,"' ");
                  countGroupWhere = 1;
                  pivotCampo = item.fcampo;
               }
               else
               {
                  whereGroup = string.Concat(whereGroup, " OR ", item.fcampo, " ", item.fconector, " '", item.fvalue,"' ");
                  countGroupWhere++;
               }

            }

            if (countGroupWhere != 0)
            {
               where = string.Concat(where, "( ", whereGroup, " )");
            }
         
            objE.EntityFilter = where;

         }
         
         var ActProy = objBO.GetOrdenVentaArticulos<EOrdenVentaArticulo>(objE);

         JsonSamNet jsonR = new JsonSamNet();
         jsonR.rows = jsonR.resultArray<EOrdenVentaArticulo>(objE.ColumnSet(), ActProy);

         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataPartner(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();

         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(';');

            DIBOQry.IOrdenVenta objBO = (DIBOQry.IOrdenVenta)WCFHelper.GetObject<DIBOQry.IOrdenVenta>(typeof(DIBOQry.OrdenVenta));
            EOrdenVentaPartner objE = new EOrdenVentaPartner();
            objE.CodigoArticulo = values[0];
            objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
            objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());


            if (values[1] != "[]")
            {
               JavaScriptSerializer ser = new JavaScriptSerializer();
               List<FilterOperator> filtros = ser.Deserialize<List<FilterOperator>>(values[1]).OrderBy(x => x.fcampo).ToList();

               int countGroupWhere = 0;
               string pivotCampo = "";
               string where = "AND ";
               string whereGroup = "";


               foreach (FilterOperator item in filtros)
               {
                  if (pivotCampo != item.fcampo)
                  {
                     if (countGroupWhere != 0)
                     {
                        where = string.Concat(where, "( ", whereGroup, " ) AND");
                        whereGroup = "";
                     }

                     whereGroup = string.Concat(item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere = 1;
                     pivotCampo = item.fcampo;
                  }
                  else
                  {
                     whereGroup = string.Concat(whereGroup, " OR ", item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere++;
                  }

               }

               if (countGroupWhere != 0)
               {
                  where = string.Concat(where, "( ", whereGroup, " )");
               }

               objE.EntityFilter = where;

            }


            ICollection<EOrdenVentaPartner> listOVPartner = objBO.GetOrdenVentaPartners<EOrdenVentaPartner>(objE);

            jsonR.rows = jsonR.resultArray<EOrdenVentaPartner>(objE.ColumnSet(), listOVPartner, Param);

         }
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataStock(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();

         if (Param.query != null && Param.query != "")
         {
            string[] values = Param.query.Split(',');

            DIBOQry.IOrdenVenta objBO = (DIBOQry.IOrdenVenta)WCFHelper.GetObject<DIBOQry.IOrdenVenta>(typeof(DIBOQry.OrdenVenta));
            EOrdenVentaStock objE = new EOrdenVentaStock();
            objE.CodigoArticulo = values[0];
            objE.TipoProducto = values[1];
            ICollection<EOrdenVentaStock> ActProy = objBO.GetOrdenVentaStock<EOrdenVentaStock>(objE);
            jsonR.rows = jsonR.resultArray<EOrdenVentaStock>(objE.ColumnSet(), ActProy, Param);

         }
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataPriorizacion(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();

         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.PrioridadAtencion));
         EPrioridadAtencion objE = new EPrioridadAtencion();
         objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
         objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());
         var Orden = objBO.GetByCriteria<EPrioridadAtencion>(objE);
         jsonR.rows = jsonR.resultArray<EPrioridadAtencion>(objE.ColumnSet(), Orden);
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetDataResultado(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();

         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.ResultadoAsignacion));
         EResultadoAsignacion objE = new EResultadoAsignacion();
         objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
         objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());

         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {
             JavaScriptSerializer ser = new JavaScriptSerializer();
             List<FilterOperator> filtros = ser.Deserialize<List<FilterOperator>>(Param.query).OrderBy(x => x.fcampo).ToList();

             int countGroupWhere = 0;
             string pivotCampo = "";
             string where = "AND ";
             string whereGroup = "";


             foreach (FilterOperator item in filtros)
             {
                 if (pivotCampo != item.fcampo)
                 {
                     if (countGroupWhere != 0)
                     {
                         where = string.Concat(where, "( ", whereGroup, " ) AND");
                         whereGroup = "";
                     }

                     whereGroup = string.Concat(item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere = 1;
                     pivotCampo = item.fcampo;
                 }
                 else
                 {
                     whereGroup = string.Concat(whereGroup, " OR ", item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere++;
                 }

             }

             if (countGroupWhere != 0)
             {
                 where = string.Concat(where, "( ", whereGroup, " )");
             }

             objE.EntityFilter = where;

         }

         var Orden = objBO.GetByCriteria<EResultadoAsignacion>(objE);
         jsonR.rows = jsonR.resultArray<EResultadoAsignacion>(objE.ColumnSet(), Orden);
         return Json(jsonR);

      }

      [HttpPost]
      public string ImportarOrdenVenta(string IdAlmacen, string IdAlmacenSerie, string IdOrdenDesde, string IdOrdenHasta)
      {
         DIBOMnt.IPedidoOperacion objBO = (DIBOMnt.IPedidoOperacion)WCFHelper.GetObject<DIBOMnt.IPedidoOperacion>(typeof(DIBOMnt.PedidoOperacion));
         EAlmacen eAlmacen = new EAlmacen();
         eAlmacen.CodigoAlmacen = IdAlmacen;
         eAlmacen.CodigoAlmacenSerie = IdAlmacenSerie;
         eAlmacen.IdOrdenDesde = IdOrdenDesde;
         eAlmacen.IdOrdenHasta = IdOrdenHasta;
         eAlmacen.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString()); ;
         objBO.ImportarOrdenVenta(eAlmacen);

         IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         ViewBag.ListAlmacen = listAlma;
         var jsonSerialiser = new JavaScriptSerializer();


         return jsonSerialiser.Serialize(listAlma);
      }

      [HttpPost]
      public JsonResult AsignarPrioridadPedido(List<EPrioridadAtencion> data)
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.PrioridadAtencion));
            EPrioridadAtencionSet objESet = new EPrioridadAtencionSet();
            objESet.EPrioridadAtencionList = data;

            foreach (EPrioridadAtencion objE in data)
            {
               objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
               objE.Prioridad = 0;
               objE.EntityState = EntityState.Added;
               objE.StAnulado = ConstFlagEstado.DESACTIVADO;
            }

            objBO.UpdateData(objESet);

            messageJson.Message = "Datos Grabados Correctamente.";
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
      public JsonResult AsignarPedidos()
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            DIBOMnt.IOrdenVenta objBO = (DIBOMnt.IOrdenVenta)WCFHelper.GetObject<DIBOMnt.IOrdenVenta>(typeof(DIBOMnt.OrdenVenta));
            EOrdenVenta objE = new EOrdenVenta();
            objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
            objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());
            objE.IdUserProceso = Session[ConstSessionVar.USERID].ToString();
            objBO.AsignacionAutomatica(objE);

            messageJson.Message = "Datos Grabados Correctamente.";
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
      public JsonResult EliminarArticulo(string[] _data)
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            DIBOMnt.IOrdenVenta objBO = (DIBOMnt.IOrdenVenta)WCFHelper.GetObject<DIBOMnt.IOrdenVenta>(typeof(DIBOMnt.OrdenVenta));
            DIBOQry.IOrdenVenta objBOQry = (DIBOQry.IOrdenVenta)WCFHelper.GetObject<DIBOQry.IOrdenVenta>(typeof(DIBOQry.OrdenVenta));
          
            EOrdenVenta objE = new EOrdenVenta();
            objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
            objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());
            int numParterNoElimandos = 0;
            foreach (string codigoArticulo in _data)
            {
               objE.CodigoArticulo = codigoArticulo;
               objBO.EliminarArticulo(objE);
               if (numParterNoElimandos == 0)
                  numParterNoElimandos = objBOQry.CantidadOrdenXArticuloNoEliminados(objE);
            }

            if (numParterNoElimandos > 0)
               messageJson.Message = "Algunos Registros se encuentran en el modulo de programación y no fueron eliminados.";
            else
               messageJson.Message = "Datos Eliminados Correctamente.";

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
      public JsonResult EliminarPartner(List<EOrdenVenta> _data)
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            DIBOMnt.IOrdenVenta objBO = (DIBOMnt.IOrdenVenta)WCFHelper.GetObject<DIBOMnt.IOrdenVenta>(typeof(DIBOMnt.OrdenVenta));
            DIBOQry.IOrdenVenta objBOQry = (DIBOQry.IOrdenVenta)WCFHelper.GetObject<DIBOQry.IOrdenVenta>(typeof(DIBOQry.OrdenVenta));
            int numParterNoElimandos = 0;
            foreach (EOrdenVenta objE in _data)
            {
               objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
               objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());
               objBO.EliminarPartner(objE);
               if (numParterNoElimandos == 0)
                  numParterNoElimandos = objBOQry.CantidadOrdenXPartnerNoEliminados(objE);
            }

            if (numParterNoElimandos > 0)
               messageJson.Message = "Algunos Registros se encuentran en el modulo de programación y no fueron eliminados.";
            else
               messageJson.Message = "Datos Eliminados Correctamente.";

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
      public JsonResult EliminarPriorizacion(List<EOrdenVenta> _data)
      {
         JsonMessage messageJson = new JsonMessage();

         try
         {
            DIBOMnt.IPrioridadAtencion objBO = (DIBOMnt.IPrioridadAtencion)WCFHelper.GetObject<DIBOMnt.IPrioridadAtencion>(typeof(DIBOMnt.PrioridadAtencion));
            objBO.EliminarPriorizacion(_data.ToList<IEntityBase>());
            messageJson.Message = "Datos Eliminados Correctamente.";
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
      public JsonResult PriorizarPedido(string filter) {

         JsonMessage messageJson = new JsonMessage();

         DIBOMnt.IPrioridadAtencion objBO = (DIBOMnt.IPrioridadAtencion)WCFHelper.GetObject<DIBOMnt.IPrioridadAtencion>(typeof(DIBOMnt.PrioridadAtencion));
         EOrdenVenta objE = new EOrdenVenta();
         objE.FechaPrograma = DateTime.Parse(Session["FechaAsignacion"].ToString());
         objE.TipoAsignacion = Int32.Parse(Session["TipoAsignacion"].ToString());

         try
         {
            if (filter != "[]")
            {
               JavaScriptSerializer ser = new JavaScriptSerializer();
               List<FilterOperator> filtros = ser.Deserialize<List<FilterOperator>>(filter).OrderBy(x => x.fcampo).ToList();

               int countGroupWhere = 0;
               string pivotCampo = "";
               string where = "AND ";
               string whereGroup = "";


               foreach (FilterOperator item in filtros)
               {
                  if (pivotCampo != item.fcampo)
                  {
                     if (countGroupWhere != 0)
                     {
                        where = string.Concat(where, "( ", whereGroup, " ) AND");
                        whereGroup = "";
                     }

                     whereGroup = string.Concat(item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere = 1;
                     pivotCampo = item.fcampo;
                  }
                  else
                  {
                     whereGroup = string.Concat(whereGroup, " OR ", item.fcampo, " ", item.fconector, " '", item.fvalue, "' ");
                     countGroupWhere++;
                  }

               }

               if (countGroupWhere != 0)
               {
                  where = string.Concat(where, "( ", whereGroup, " )");
               }

               objE.EntityFilter = where;

               objBO.PriorizarFiltro((IEntityBase)objE);
               
               messageJson.Message = "Filtro Priorizado con exito.";
               messageJson.Status = JsonMessageStatus.SUCCESS;
               return Json(messageJson);

            }
            else
            {

               messageJson.Message = "No existen Filtros";
               messageJson.Status = JsonMessageStatus.INVALID;
               return Json(messageJson);

            }

         }
         catch (Exception ex)
         {
            messageJson.Message = ex.Message;
            messageJson.Status = JsonMessageStatus.INVALID;
            return Json(messageJson);
         }

      }

      [HttpPost]
      public JsonResult GetAlmacenSerie(string idAlmacen) {

         IBOQuery objBOAlmacenSerie = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.AlmacenSerie));
         EAlmacenSerie eAlmacenSerie = new EAlmacenSerie();
         eAlmacenSerie.CodigoAlmacen = idAlmacen;
         ICollection<EAlmacenSerie> listAlma = objBOAlmacenSerie.GetByParentKey<EAlmacenSerie>(eAlmacenSerie);

         var data = from f in listAlma.AsEnumerable()
                    select new
                    {
                       text = f.CodigoSerie,
                       value = f.CodigoSerie,
                       primerOrden = f.PrimeraOrden,
                       ultimaOrden = f.UltimaOrden
                    };

         return Json(data);
      }
   }
}
