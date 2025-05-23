using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using Laive.Entity.Bi;
using Laive.Entity.Di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BIBOQry = Laive.BOQry.Bi;
using BIBOMnt = Laive.BOMnt.Bi;

namespace LAIVE.V1.Areas.BI.Controllers
{
    public class CanalComercialController : Controller
    {
        
       [HttpGet]
       public PartialViewResult Index()
        {
           BIBOQry.ICanalComercial objBOCanalComercial = (BIBOQry.ICanalComercial)WCFHelper.GetObject<BIBOQry.ICanalComercial>(typeof(BIBOQry.CanalComercial));
           ECanalComercial eCanalComercial = new ECanalComercial();

           ICollection<ECanalComercial> canalComercialLista = objBOCanalComercial.GetListNivel1<ECanalComercial>(eCanalComercial);
           string JsonCanalComercial = "";
           foreach (ECanalComercial eSel in canalComercialLista)
           {
              if (JsonCanalComercial != "")
                 JsonCanalComercial = string.Concat(JsonCanalComercial, ",");
              JsonCanalComercial = string.Concat(JsonCanalComercial, "{text: '", string.Concat(eSel.Codigo, " - ", eSel.Glosa), "', value: '", eSel.IdCanalModerno, "'}");
           }
           ViewBag.ListaCanalComercial = JsonCanalComercial;
         

            return PartialView();
        }


       [HttpPost]
       public JsonResult GetBandeja(FlexigridParamSamNet Param)
       {
          JsonSamNet jsonR = new JsonSamNet();
          IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.CanalComercial));
          ECanalComercial eCanalComercial = new ECanalComercial();
          eCanalComercial.EntityFilter = "";
          FilterSearch filterSearch = new FilterSearch();
          List<FilterOperator> filtro = new List<FilterOperator>();

          if (Param.query != null && Param.query != "[]" && Param.query != "")
          {
             JavaScriptSerializer ser = new JavaScriptSerializer();
             filtro = ser.Deserialize<List<FilterOperator>>(Param.query);
             eCanalComercial.EntityFilter = filterSearch.Create(filtro, eCanalComercial.ColumnSet());
          }
                    
          jsonR.rows = jsonR.resultArray<ECanalComercial>(eCanalComercial.ColumnSet(), objBO.GetByCriteria<ECanalComercial>(eCanalComercial));

          return Json(jsonR);
       }

       [HttpPost]
       public JsonResult GetCanalNivel2(string idCanalNivel1)
       {
          BIBOQry.ICanalComercial objBOCanalComercial = (BIBOQry.ICanalComercial)WCFHelper.GetObject<BIBOQry.ICanalComercial>(typeof(BIBOQry.CanalComercial));
          ECanalComercial eCanalComercial = new ECanalComercial();
          eCanalComercial.Padre = Convert.ToInt32(idCanalNivel1);
          ICollection<ECanalComercial> canalComercialLista = objBOCanalComercial.GetListNivel2<ECanalComercial>(eCanalComercial);

          var data = from f in canalComercialLista.AsEnumerable()
                     select new
                     {
                        text = string.Concat(f.Codigo," - ",f.Glosa),
                        value = f.IdCanalModerno.ToString()
                     };

          return Json(data);
       }

       
       [HttpPost]
       public JsonResult UpdateModel(ECanalComercial eCanalComercial)
       {
           JsonMessage jmessage = new JsonMessage();
           try
           {
               //if (eCanalComercial.EntityState == EntityState.Added)
              // {
                   IBOQuery objBOQry = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.CanalComercial));
                   if (!objBOQry.Exists(eCanalComercial))
                   {
                       jmessage.Status = JsonMessageStatus.INFORMATION;
                       jmessage.Message = "El Codigo del partner ingresado no es correcto.";
                       return Json(jmessage);
                   }
                   BIBOQry.ICanalComercial objBOCanalComercial = (BIBOQry.ICanalComercial)WCFHelper.GetObject<BIBOQry.ICanalComercial>(typeof(BIBOQry.CanalComercial));
                   if (!objBOCanalComercial.ExistsDB(eCanalComercial))
                   {
                       if (eCanalComercial.EntityState == EntityState.Added)
                       {
                           jmessage.Status = JsonMessageStatus.INFORMATION;
                           jmessage.Message = "El Codigo del partner ingresado ya existe.";
                           return Json(jmessage);
                       }
                       
                   }

               //}
              


               IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(BIBOMnt.CanalComercial));
               objBO.UpdateData(eCanalComercial);
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
