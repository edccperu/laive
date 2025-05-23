using Laive.Entity.Fi;
using Laive.Core.Common;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using LAIVE.V1.Controllers;
using Laive.Core.Data;
using System.Web.Script.Serialization;
using System.Globalization;

namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ConsultarChequeController : SamcontrollerBase
    {
       [HttpGet]
       public PartialViewResult Index()
       {
          IBOQuery boAlcancePoder = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.AlcancePoder));
          EAlcancePoder eAlcancePoder = new EAlcancePoder();
          ICollection<EAlcancePoder> listAlcancePoder = boAlcancePoder.GetList<EAlcancePoder>(eAlcancePoder);
          string JsonAlcancePoder = "";
          foreach (EAlcancePoder eSel in listAlcancePoder)
          {
             if (JsonAlcancePoder != "")
                JsonAlcancePoder = string.Concat(JsonAlcancePoder, ",");
             JsonAlcancePoder = string.Concat(JsonAlcancePoder, "{text: '", eSel.GlosaPoder, "', value: '", eSel.CodigoPoder, "'}");
          }
          ViewBag.AlcancePoder = JsonAlcancePoder;

          return PartialView();
       }
      
       [HttpPost]
       public JsonResult GetDataGrdCheques(string filtro)
       {
          FIBOQry.ICheque objBO = (FIBOQry.ICheque)WCFHelper.GetObject<FIBOQry.ICheque>(typeof(FIBOQry.Cheque));
          ECheque objE = new ECheque();
          List<FilterOperator> filtros = new List<FilterOperator>();
          if (filtro != null && filtro != "[]" && filtro != "")
          {
             JavaScriptSerializer ser = new JavaScriptSerializer();
             filtros = ser.Deserialize<List<FilterOperator>>(filtro).OrderBy(x => x.fcampo).ToList();
          }

      
          filtros.Add(new FilterOperator("a.codigoPoder", EnumConectorFilter.DIFERENTE, ""));
          filtros.Add(new FilterOperator("a.estadoLoteContable", EnumConectorFilter.IGUAL, "6"));

          objE.EntityFilter = JsonLaiveLib.GetWhere(filtros);

          ICollection<ECheque> listCheque = objBO.GetChequeXAsignar(objE);

          var listJson = from lc in listCheque
                         select new
                         {
                             IdCheque = lc.IdCheque,
                             CodigoPoder = lc.CodigoPoder,
                             RowNumber = lc.RowNumber,
                             GlosaPoder = lc.GlosaPoder,
                             NumCheque = lc.NumCheque,
                             CodigoPartner = lc.CodigoPartner,
                             Beneficiario = lc.Beneficiario,
                             FechaPago = Convert.ToDateTime(lc.FechaPago).ToString("dd/MM/yyyy"),
                             TipoTransaccion = lc.TipoTransaccion,
                             NroTransaccion = lc.NroTransaccion,
                             NroAsiento = lc.NroAsiento,
                             LotePago = lc.LotePago,
                             Moneda = lc.Moneda,
                             ImporteCheque = Convert.ToDecimal(lc.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                             CodigoEstado = lc.CodigoEstado,
                             GlosaEstado = lc.GlosaEstado,
                             Nombre1erFirmante = lc.Nombre1erFirmante,
                             Nombre2doFirmante = lc.Nombre2doFirmante,
                             ListComprobantes = from lcc in lc.ListComprobantes
                                                select new
                                                {
                                                    GlosaTipoSugerencia = lcc.GlosaTipoSugerencia,
                                                    Transaccion = lcc.Transaccion,
                                                    NumComprobante = lcc.NumComprobante,
                                                    Referencia = lcc.Referencia,
                                                    Moneda = lcc.Moneda,
                                                    Importe = lcc.Importe.ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))
                                                },
                             ListVoucher = from lcv in lc.ListVoucher
                                           select new {
                                               CuentaContable = lcv.CuentaContable,
                                               GlosaCuentaContable = lcv.GlosaCuentaContable,
                                               ImporteSoles = Convert.ToDecimal(lcv.ImporteSoles).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                                               CargoAbono = lcv.CargoAbono
                                           }
                         };

          return Json(listJson);
       }

       [HttpPost]
       public JsonResult GetFirmanteXPoder(string codigoPoder)
       {
          JsonMessage jMessage = new JsonMessage();

          try
          {
             FIBOQry.IFirmante objBO = (FIBOQry.IFirmante)WCFHelper.GetObject<FIBOQry.IFirmante>(typeof(FIBOQry.Firmante));
             EFirmante eTrans = new EFirmante();
             eTrans.CodigoPoder = codigoPoder;
             ICollection<EFirmante> ListaFirmantes = objBO.GetFirmantesXPoder<EFirmante>(eTrans);

             jMessage.Data = from a in ListaFirmantes
                             select new
                             {
                                text = string.Concat(a.CodigoFirmante, " - ", a.NombreFirmante),
                                value = a.CodigoFirmante
                             };
             jMessage.Status = JsonMessageStatus.SUCCESS;
             return Json(jMessage);

          }
          catch (Exception e)
          {
             jMessage.Status = JsonMessageStatus.INVALID;
             jMessage.Message = e.Message;
             return Json(jMessage);
          }
          
       }

       [HttpPost]
       public JsonResult AsignarFirmantes(string[] chequeIds, string primerFirmante, string segundoFirmante, bool esFirmaManual)
       { 
            JsonMessage jMessage = new JsonMessage();
            try
            {
               FIBOMnt.Cheque BOCheque = new FIBOMnt.Cheque();

               foreach (string idCheque in chequeIds)
               {
                  ECheque eCheque = new ECheque();
                  eCheque.IdCheque = Convert.ToInt32(idCheque);
                  eCheque.Codigo1erFirmante = primerFirmante;
                  eCheque.Codigo2doFirmante = segundoFirmante;
                  if (esFirmaManual)
                     eCheque.CodigoEstado = ConstEstadoCheque.FIRMA_MANUAL;
                  else
                     eCheque.CodigoEstado = ConstEstadoCheque.ASIGANDO;

                  eCheque.Login = HttpContext.Session[ConstSessionVar.USERLOGON].ToString();
                  BOCheque.AsignarFirmante(eCheque);
               }
               jMessage.Status = JsonMessageStatus.SUCCESS;
               return Json(jMessage);
            }
            catch (Exception e) {
               jMessage.Status = JsonMessageStatus.INVALID;
               jMessage.Message = e.Message;
               return Json(jMessage);
            }
       }


       [HttpPost]
       public JsonResult GetHistorial(int idCheque)
       {
          JsonMessage jMessage = new JsonMessage();
          try
          {

             IBOQuery boChequeLog = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.ChequeLog));
             EChequeLog eChequeLog = new EChequeLog();
             eChequeLog.IdCheque = idCheque;
             ICollection<EChequeLog> listChequeLog = boChequeLog.GetList<EChequeLog>(eChequeLog);

             jMessage.Data = from a in listChequeLog
                             select new
                             {
                                time = a.FechaRegistro.ToString("dd/MM/yyyy HH:mm tt"),
                                content = string.Concat("<div class=\"history-estado\">", a.GlosaEstado, "</div>", "<div class=\"history-firmante\">", a.NombreFirmante, "</div>", "<div class=\"history-obs\">", a.Observacion, "</div>"),
                                color = LaiveFunctions.GetColorXEstadoCheque(a.CodigoEstado)
                             };
             
             jMessage.Status = JsonMessageStatus.SUCCESS;
             return Json(jMessage);
          }
          catch (Exception e)
          {
             jMessage.Status = JsonMessageStatus.INVALID;
             jMessage.Message = e.Message;
             return Json(jMessage);
          }
       }

       [HttpPost]
       public JsonResult GetBanco()
       {
           JsonMessage jMessage = new JsonMessage();
           try
           {
               IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.BaanBanco));
               EBaanBanco eBaanBanco = new EBaanBanco();
               ICollection<EBaanBanco> listBancos = objBO.GetList<EBaanBanco>(eBaanBanco);

               jMessage.Data = from b in listBancos
                               select new
                               {
                                   text = b.GlosaBanco,
                                   value = b.CodigoBanco
                               };
               jMessage.Status = JsonMessageStatus.SUCCESS;
               return Json(jMessage);

           }
           catch (Exception e)
           {
               jMessage.Status = JsonMessageStatus.INVALID;
               jMessage.Message = e.Message;
               return Json(jMessage);
           }
       }
      
    }
}
