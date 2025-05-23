using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Bi;
using Laive.Core.Entity;
using Laive.Core.Data;
using BIBOQry = Laive.BOQry.Bi;
using BIBOMnt = Laive.BOMnt.Bi;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using Newtonsoft.Json;


namespace LAIVE.V1.Areas.BI.Controllers
{
   public class SolidoLecheController : SamcontrollerBase
    {
       [HttpGet]
       public PartialViewResult Index()
       {
          IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.Area));
          EArea eArea = new EArea();
          ViewBag.ListaArea = objBO.GetListForSelect(eArea);
          
          return PartialView("Index");
       }

       [HttpPost]
       public JsonResult GetBandeja(FlexigridParamSamNet Param)
       {
          JsonSamNet jsonR = new JsonSamNet();
          IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.SolidoLeche));
          ESolidoLeche eSolidoLeche = new ESolidoLeche();
          eSolidoLeche.EntityFilter = "";
          FilterSearch filterSearch = new FilterSearch();
          List<FilterOperator> filtro = new List<FilterOperator>();

          if (Param.query != null && Param.query != "[]" && Param.query != "")
          {
             JavaScriptSerializer ser = new JavaScriptSerializer();
             filtro = ser.Deserialize<List<FilterOperator>>(Param.query); 
          }

          filtro.Add(new FilterOperator("Estado", EnumConectorFilter.IGUAL, ConstFlagEstado.ACTIVADO));
          eSolidoLeche.EntityFilter = filterSearch.Create(filtro, eSolidoLeche.ColumnSet());
          jsonR.rows = jsonR.resultArray<ESolidoLeche>(eSolidoLeche.ColumnSet(), objBO.GetByCriteria<ESolidoLeche>(eSolidoLeche));
          
          return Json(jsonR);
       }


       [HttpPost]
       public JsonResult UpdateModel(ESolidoLeche eSolidoLeche)
       {
          JsonMessage jmessage = new JsonMessage();

          try
          {
             if (eSolidoLeche.EntityState == EntityState.Added)
             {
                IBOQuery objBOQry = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.SolidoLeche));
                if (!objBOQry.Exists(eSolidoLeche))
                {
                       jmessage.Status = JsonMessageStatus.INFORMATION;
                       jmessage.Message = "El Codigo del articulo ingresado no es correcto.";
                       return Json(jmessage);
                }

                BIBOQry.ISolidoLeche objBOSolidoLeche = (BIBOQry.ISolidoLeche)WCFHelper.GetObject<BIBOQry.ISolidoLeche>(typeof(BIBOQry.SolidoLeche));
                 if (!objBOSolidoLeche.ExistsDB(eSolidoLeche))
                 {
                     jmessage.Status = JsonMessageStatus.INFORMATION;
                     jmessage.Message = "El Codigo del articulos ingresado ya existe.";
                     return Json(jmessage); 

                 }

             }

             IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(BIBOMnt.SolidoLeche));
             eSolidoLeche.IdUserCreacion = Session[ConstSessionVar.USERID].ToString();
             eSolidoLeche.FechaCreacion = DateTime.Now;
             eSolidoLeche.IdUserModifica = Session[ConstSessionVar.USERID].ToString();
             eSolidoLeche.FechaModifica = DateTime.Now;
             eSolidoLeche.Estado = ConstFlagEstado.ACTIVADO;
             objBO.UpdateData(eSolidoLeche);
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
