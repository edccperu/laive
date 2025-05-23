using Laive.Core.Common;
using Laive.Core.Data;
using LAIVE.V1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIBOQry = Laive.BOQry.Di;
using DIBOMnt = Laive.BOMnt.Di;
using Laive.Entity.Di;
using Laive.Core.Entity;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace LAIVE.V1.Areas.DI.Controllers
{
   public class ShelfLifeAdicionalController : SamcontrollerBase
   {
      [HttpGet]
      public PartialViewResult Index()
      {
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanPartner));
         EBaanPartner eBaanPartner = new EBaanPartner();
         ICollection<EBaanPartner> partnerLista = objBO.GetList<EBaanPartner>(eBaanPartner);
         var JsonPartner = from partner in partnerLista select new { text = String.Concat(partner.CodigoPartner.Trim(), " - ", partner.ClavePartner1.Trim()), value = partner.CodigoPartner.Trim() };
         ViewBag.ListaPartner = JsonConvert.SerializeObject(JsonPartner);

         IBOQuery objBOBaanArticulo = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanArticulo));
         EBaanArticulo eBaanArticulo = new EBaanArticulo();
         ICollection<EBaanArticulo> articuloLista = objBOBaanArticulo.GetList<EBaanArticulo>(eBaanArticulo);
         var JsonArticulo = from articulo in articuloLista select new { text = String.Concat(articulo.CodigoArticulo.Trim(), " - ", articulo.GlosaArticulo.Trim()), value = articulo.CodigoArticulo.Trim() };
         ViewBag.ListaArticulo = JsonConvert.SerializeObject(JsonArticulo);

         IBOQuery objBOBaanGrpPartner = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.BaanGrpPartner));
         EBaanGrpPartner eBaanGrpPartner = new EBaanGrpPartner();
         ICollection<EBaanGrpPartner> baanGrpPartnerLista = objBOBaanGrpPartner.GetList<EBaanGrpPartner>(eBaanGrpPartner);
         var JsonGrupoPartner = from grupoPartner in baanGrpPartnerLista select new { text = String.Concat(grupoPartner.CodigoGrpPartner.Trim(), " - ", grupoPartner.GlosaGrpPartner.Trim()), value = grupoPartner.CodigoGrpPartner.Trim() };
         ViewBag.ListaGrupo = JsonConvert.SerializeObject(JsonGrupoPartner);

         //IBOQuery objBOAlmacen = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.Almacen));
         //EAlmacen eAlmacen = new EAlmacen();
         //ICollection<EAlmacen> listAlma = objBOAlmacen.GetList<EAlmacen>(eAlmacen);
         //ViewBag.ListAlmacen = listAlma;

         return PartialView("Index");
      }

      [HttpPost]
      public JsonResult GetBandeja(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.ShelfLifeAdicional));
         EShelfLifeAdicional eShelfLifeAdicional = new EShelfLifeAdicional();
         eShelfLifeAdicional.EntityFilter = "";
         if (Param.query != null && Param.query != "[]" && Param.query != "")
         {

            FilterSearch filterSearch = new FilterSearch();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<FilterOperator> filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
            eShelfLifeAdicional.EntityFilter = filterSearch.Create(filtro, eShelfLifeAdicional.ColumnSet());
         }

         jsonR.rows = jsonR.resultArray<EShelfLifeAdicional>(eShelfLifeAdicional.ColumnSet(), objBO.GetByCriteria<EShelfLifeAdicional>(eShelfLifeAdicional));
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult UpdateModel(EShelfLifeAdicional eShelfLifeAdicional)
      {
         JsonMessage jmessage = new JsonMessage();

         try
         {
            IBOQuery objBOQry = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.ShelfLifeAdicional));
            if (!objBOQry.Exists(eShelfLifeAdicional))
            {
                jmessage.Status = JsonMessageStatus.INFORMATION;
                jmessage.Message = "El registro se encuentra dublicado.";
                return Json(jmessage);
            }
             
            IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(DIBOMnt.ShelfLifeAdicional));
            eShelfLifeAdicional.IdUserTk = Session[ConstSessionVar.USERID].ToString();


            if (eShelfLifeAdicional.TipoRegistro == "001")
            {
               eShelfLifeAdicional.CodigoGrupo = string.Empty;
            }
            else
            { 
               eShelfLifeAdicional.CodigoPartner = string.Empty;
            }
           
            eShelfLifeAdicional.CodigoAlmacen = string.Empty;

            objBO.UpdateData(eShelfLifeAdicional);
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

      [HttpPost]
      public JsonResult GetShelfLife(string tipoRegistro,string codigoArticulo,string codigoPartner,string codigoGrupo)
      { 
       JsonMessage jmessage = new JsonMessage();

         try
         {
            DIBOQry.IShelfLifeAdicional objBO = (DIBOQry.IShelfLifeAdicional)WCFHelper.GetObject<DIBOQry.IShelfLifeAdicional>(typeof(DIBOQry.ShelfLifeAdicional));
            EShelfLifeAdicional eShelfLifeAdicional = new EShelfLifeAdicional();
            eShelfLifeAdicional.TipoRegistro = tipoRegistro;
            eShelfLifeAdicional.CodigoArticulo = codigoArticulo;
            eShelfLifeAdicional.CodigoPartner = codigoPartner;
            eShelfLifeAdicional.CodigoGrupo = codigoGrupo;

            jmessage.Data = objBO.GetShelfLife(eShelfLifeAdicional);
            jmessage.Status = JsonMessageStatus.SUCCESS;
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
