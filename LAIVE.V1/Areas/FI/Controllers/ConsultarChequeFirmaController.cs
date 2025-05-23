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
    public class ConsultarChequeFirmaController : SamcontrollerBase
    {
        //
        // GET: /FI/ConsultarChequeFirma/
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetDataGrdCheques() 
        {
            FIBOQry.ICheque objBO = (FIBOQry.ICheque)WCFHelper.GetObject<FIBOQry.ICheque>(typeof(FIBOQry.Cheque));
            ECheque objE = new ECheque();
            objE.Login = HttpContext.Session[ConstSessionVar.USERLOGON].ToString();
            ICollection<ECheque> listCheque = objBO.GetConsultaChequeFirma(objE);
            var listJson = from lc in listCheque
                           select new
                           {
                               RowNumber = lc.RowNumber,
                               FechaRegistro = lc.FechaRegistro,
                               CodigoBanco = lc.CodigoBanco,
                               GlosaBanco = lc.GlosaBanco,
                               TotalCheques = lc.TotalCheques,
                               Moneda = lc.Moneda,
                               ImporteTotal = Convert.ToDecimal(lc.ImporteTotal).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                               ListResumen = from lcr in lc.ListResumen
                                             select new
                                             {
                                                 IdCheque = lcr.IdCheque,
                                                 CodigoPoder = lcr.CodigoPoder,
                                                 RowNumber = lcr.RowNumber,
                                                 GlosaPoder = lcr.GlosaPoder,
                                                 NumCheque = lcr.NumCheque,
                                                 CodigoPartner = lcr.CodigoPartner,
                                                 Beneficiario = lcr.Beneficiario,
                                                 FechaPago = Convert.ToDateTime(lcr.FechaPago).ToString("dd/MM/yyyy"),
                                                 TipoTransaccion = lcr.TipoTransaccion,
                                                 NroTransaccion = lcr.NroTransaccion,
                                                 NroAsiento = lcr.NroAsiento,
                                                 LotePago = lcr.LotePago,
                                                 Moneda = lcr.Moneda,
                                                 ImporteCheque = Convert.ToDecimal(lcr.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                                                 CodigoEstado = lcr.CodigoEstado,
                                                 GlosaEstado = lcr.GlosaEstado,
                                                 Nombre1erFirmante = lcr.Nombre1erFirmante,
                                                 Nombre2doFirmante = lcr.Nombre2doFirmante,
                                                 ListComprobantes = from lcc in lcr.ListComprobantes
                                                                    select new
                                                                    {
                                                                        GlosaTipoSugerencia = lcc.GlosaTipoSugerencia,
                                                                        Transaccion = lcc.Transaccion,
                                                                        NumComprobante = lcc.NumComprobante,
                                                                        Referencia = lcc.Referencia,
                                                                        Moneda = lcc.Moneda,
                                                                        Importe = lcc.Importe.ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))
                                                                    },
                                                 ListVoucher = from lcv in lcr.ListVoucher
                                                              select new
                                                              {
                                                                  CuentaContable = lcv.CuentaContable,
                                                                  GlosaCuentaContable = lcv.GlosaCuentaContable,
                                                                  ImporteSoles = Convert.ToDecimal(lcv.ImporteSoles).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                                                                  CargoAbono = lcv.CargoAbono
                                                              }
                                 
                                             }
                           };
            return Json(listJson);

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

    }
}
