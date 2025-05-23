using Laive.Entity.Fi;
using Laive.Core.Common;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIBOQry = Laive.BOQry.Fi;
using LAIVE.V1.Controllers;
using System.Web.Script.Serialization;
using Laive.Core.Data;
using System.Globalization;
using iTextSharp;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace LAIVE.V1.Areas.FI.Controllers
{
   public class ImprimirChequeController : SamcontrollerBase
   {
      //
      // GET: /ChequeFirmado/

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
         objE.EntityFilter = JsonLaiveLib.GetWhere(filtros);

         ICollection<ECheque> listCheque = objBO.GetImprimirCheque(objE);

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
                                         select new
                                         {
                                            CuentaContable = lcv.CuentaContable,
                                            GlosaCuentaContable = lcv.GlosaCuentaContable,
                                            ImporteSoles = Convert.ToDecimal(lcv.ImporteSoles).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")),
                                            CargoAbono = lcv.CargoAbono
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

      [AcceptVerbs(HttpVerbs.Get)]
      public FileResult GetPdfCheque(string idCheque)
      {

         string[] listChequeId = idCheque.Split('_');

         /*Rectangle :: los parapetros son pixeles a 72 dpi (calculadora en http://www.hdri.at/dpirechner/dpirechner_en.htm) */
         Rectangle rPaperSize = new Rectangle(797, 612);
         Document pdfDoc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);

         MemoryStream ms = new MemoryStream();
         PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, ms);
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.Cheque));
         FIBOQry.ICheque objBOI = (FIBOQry.ICheque)WCFHelper.GetObject<FIBOQry.ICheque>(typeof(FIBOQry.Cheque));
         IBOQuery objBOCompro = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.ChequeComprobante));
         IBOQuery objBOVoucher = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.ChequeVoucher));

         pdfDoc.Open();

         foreach (string chequeId in listChequeId)
         {
            if (string.IsNullOrEmpty(chequeId))
               continue;


            /*---- GET DATA ----*/
            ECheque objE = new ECheque();
            objE.IdCheque = Convert.ToInt32(chequeId);
            objE = (ECheque)objBO.GetByKey(objE);
            EChequeComprobante eChequeCompro = new EChequeComprobante();
            eChequeCompro.IdCheque = objE.IdCheque;
            EChequeVoucher eVoucher = new EChequeVoucher();
            eVoucher.IdCheque = objE.IdCheque;
            ICollection<EChequeComprobante> listEChequeCompro = objBOCompro.GetByParentKey<EChequeComprobante>(eChequeCompro);
            ICollection<EChequeVoucher> listEChequeVoucher = objBOVoucher.GetByParentKey<EChequeVoucher>(eVoucher);

            /*---- PRINT PDF ----*/
            /*-- N de VOUCHER --*/
            Font fdefault = FontFactory.GetFont("Courier", 8, Font.NORMAL, BaseColor.BLACK);
            Paragraph pa = new Paragraph(54, string.Concat(objE.TipoTransaccion, " / ", objE.NroTransaccion), fdefault);
            pa.IndentationLeft = 140;
            pdfDoc.Add(pa);

            /*-- MES Año --*/
            pa = new Paragraph(0, Convert.ToDateTime(objE.FechaPago).ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("es-PE")), fdefault);
            pa.IndentationLeft = 280;
            pdfDoc.Add(pa);

            /*-- BANCO --*/
            pa = new Paragraph(25, objE.DsBanco, fdefault);
            pa.IndentationLeft = 60;
            pdfDoc.Add(pa);

            /*-- IMPORTE --*/
            pa = new Paragraph(0, string.Concat("S/.   ", Convert.ToInt32(objE.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))), fdefault);
            pa.Alignment = Element.ALIGN_LEFT;
            pa.IndentationLeft = 480;
            pdfDoc.Add(pa);

            /*-- FECHA DE EMISION --*/
            pa = new Paragraph(40, Convert.ToDateTime(objE.FechaPago).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-PE")), fdefault);
            pa.IndentationLeft = 250;
            pdfDoc.Add(pa);

            /*-- METODO PAGO --*/
            pa = new Paragraph(0, string.Concat(objE.TipoTransaccion, " ", objE.CodigoMetodoPago, " ", objE.NumCheque.Trim()), fdefault);
            pa.IndentationLeft = 480;
            pdfDoc.Add(pa);

            /*-- TIPO OPERACIóN --*/
            pa = new Paragraph(25, "PENDIENTE", fdefault);
            pa.IndentationLeft = 250;
            pdfDoc.Add(pa);

            /*-- PROVEEDOR BENEFICIARIO --*/
            pa = new Paragraph(25, objE.Beneficiario.Trim(), fdefault);
            pa.IndentationLeft = 250;
            pdfDoc.Add(pa);

            int numRow = 0;
            /*-- COMPROBANTES ESPACIO 120 , distancia para iniciar 27pt + 10pt por linea, total de row 12 aprox --*/
            foreach (EChequeComprobante objECompro in listEChequeCompro)
            {
               numRow++;

               pa = new Paragraph(numRow == 1 ? 25 : 10, objECompro.Transaccion, fdefault);
               pa.IndentationLeft = 31;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, objECompro.NumComprobante.ToString(), fdefault);
               pa.IndentationLeft = 68;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, objECompro.Referencia, fdefault);
               pa.IndentationLeft = 106;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, objECompro.Moneda, fdefault);
               pa.IndentationLeft = 418;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, objECompro.Importe.ToString("N2", CultureInfo.CreateSpecificCulture("en-US")), fdefault);
               pa.Alignment = Element.ALIGN_LEFT;
               pa.IndentationLeft = 450;
               pdfDoc.Add(pa);

            }

            int numRowVoucher = 0;
            /*-- VOUCHER ESPACIO 100 , distancia para iniciar 38pt + (120pt - (10 * numRow)) , total de row 10 aprox --*/
            foreach (EChequeVoucher objEVoucher in listEChequeVoucher)
            {

               numRowVoucher++;

               pa = new Paragraph(numRowVoucher == 1 ? 158 - (10 * numRow) : 10, objEVoucher.GlosaCuentaContable, fdefault);
               pa.IndentationLeft = 31;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, objEVoucher.CuentaContable.ToString(), fdefault);
               pa.IndentationLeft = 338;
               pdfDoc.Add(pa);

               pa = new Paragraph(0, Convert.ToDecimal(objEVoucher.ImporteSoles).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")), fdefault);
               pa.Alignment = Element.ALIGN_RIGHT;
               pa.IndentationRight = objEVoucher.CargoAbono == ConstCargoAbono.DEBE ? 106 : 20;
               pdfDoc.Add(pa);

            }


            /*-- DATOS CHEQUE --*/

            /*-- FECHA --*/
            pa = new Paragraph(265 - (numRowVoucher * 10), Convert.ToDateTime(objE.FechaPago).ToString("dd  MM  yyyy"), fdefault);
            pa.IndentationLeft = 163;
            pdfDoc.Add(pa);

            /*-- IMPORTE + asteriscos --*/
            pa = new Paragraph(0, string.Concat(new string('*', 16 - objE.ImporteCheque.ToString().Length), Convert.ToDecimal(objE.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))), fdefault);
            pa.IndentationLeft = 305;
            pdfDoc.Add(pa);


            /*-- IMPORTE EN LETRAS --*/
            string impLetras = LaiveFunctions.NumeroToLetras(Convert.ToDecimal(objE.ImporteCheque),true);
            fdefault = FontFactory.GetFont("Courier", 8, Font.BOLD, BaseColor.BLACK);
            pa = new Paragraph(15, string.Concat("***", impLetras, new string('*', 77 - impLetras.Length)), fdefault);
            pa.IndentationLeft = 25;
            pdfDoc.Add(pa);
            
            EChequeFirma eChequeFirma = new EChequeFirma();
            eChequeFirma.IdCheque = objE.IdCheque;
            eChequeFirma = (EChequeFirma)objBOI.GetFirmasFirmante(eChequeFirma);

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(eChequeFirma.Firma1erFirmante);
            float ratio = 66 / image.Height;
            image.ScaleAbsolute(image.Width * ratio, 66);

            Paragraph p = new Paragraph(100);
            p.IndentationLeft = 200;
            p.Add(new Chunk(image, 0, 0));
        
            image = iTextSharp.text.Image.GetInstance(eChequeFirma.Firma2doFirmante);
            ratio = 66 / image.Height;
            image.ScaleAbsolute(image.Width * ratio, 66);
            p.Add(new Chunk(image, 0, 0));

            pdfDoc.Add(p);


            //pdfDoc.NewPage();
         }


         pdfDoc.Close();

         return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf);

      }


      [HttpPost]
      public JsonResult GetResultPrint(List<int> values)
      {
          JsonMessage jMessage = new JsonMessage();
          try
          {

              /*Rectangle :: los parapetros son pixeles a 72 dpi (calculadora en http://www.hdri.at/dpirechner/dpirechner_en.htm) */
              //Rectangle rPaperSize = new Rectangle(797, 612);
              Document pdfDoc = new Document(PageSize.LETTER, 0f, 0f, 48f, 0f);

              MemoryStream ms = new MemoryStream();
              PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, ms);
              IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.Cheque));
              FIBOQry.ICheque objBOI = (FIBOQry.ICheque)WCFHelper.GetObject<FIBOQry.ICheque>(typeof(FIBOQry.Cheque));
              IBOQuery objBOCompro = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.ChequeComprobante));
              IBOQuery objBOVoucher = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(FIBOQry.ChequeVoucher));

              pdfDoc.Open();

              foreach (int chequeId in values)
              {

                  /*---- GET DATA ----*/
                  ECheque objE = new ECheque();
                  objE.IdCheque = chequeId;
                  objE = (ECheque)objBO.GetByKey(objE);
                  EChequeComprobante eChequeCompro = new EChequeComprobante();
                  eChequeCompro.IdCheque = objE.IdCheque;
                  EChequeVoucher eVoucher = new EChequeVoucher();
                  eVoucher.IdCheque = objE.IdCheque;
                  ICollection<EChequeComprobante> listEChequeCompro = objBOCompro.GetByParentKey<EChequeComprobante>(eChequeCompro);
                  ICollection<EChequeVoucher> listEChequeVoucher = objBOVoucher.GetByParentKey<EChequeVoucher>(eVoucher);

                  /*---- PRINTING ----*/
                  /*-- N de VOUCHER --*/
                  Font fdefault = FontFactory.GetFont("Courier", 8, Font.NORMAL, BaseColor.BLACK);
                  Paragraph pa = new Paragraph(54, string.Concat(objE.TipoTransaccion, " / ", objE.NroTransaccion), fdefault);
                  pa.IndentationLeft = 140;
                  pdfDoc.Add(pa);

                  /*-- MES Año --*/
                  pa = new Paragraph(0, Convert.ToDateTime(objE.FechaPago).ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("es-PE")), fdefault);
                  pa.IndentationLeft = 280;
                  pdfDoc.Add(pa);

                  /*-- BANCO --*/
                  pa = new Paragraph(25, objE.DsBanco, fdefault);
                  pa.IndentationLeft = 60;
                  pdfDoc.Add(pa);

                  /*-- IMPORTE --*/
                  pa = new Paragraph(0, string.Concat("S/.   ", Convert.ToInt32(objE.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))), fdefault);
                  pa.Alignment = Element.ALIGN_LEFT;
                  pa.IndentationLeft = 480;
                  pdfDoc.Add(pa);

                  /*-- FECHA DE EMISION --*/
                  pa = new Paragraph(45, Convert.ToDateTime(objE.FechaPago).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-PE")), fdefault);
                  pa.IndentationLeft = 250;
                  pdfDoc.Add(pa);

                  /*-- METODO PAGO --*/
                  pa = new Paragraph(0, string.Concat(objE.TipoTransaccion, " ", objE.CodigoMetodoPago, " ", objE.NumCheque.Trim()), fdefault);
                  pa.IndentationLeft = 480;
                  pdfDoc.Add(pa);

                  /*-- TIPO OPERACIóN --*/
                  pa = new Paragraph(24, "PENDIENTE", fdefault);
                  pa.IndentationLeft = 250;
                  pdfDoc.Add(pa);

                  /*-- PROVEEDOR BENEFICIARIO --*/
                  pa = new Paragraph(20, objE.Beneficiario.Trim(), fdefault);
                  pa.IndentationLeft = 250;
                  pdfDoc.Add(pa);

                  int numRow = 0;
                  /*-- COMPROBANTES ESPACIO 120 , distancia para iniciar 27pt + 10pt por linea, total de row 12 aprox --*/
                  foreach (EChequeComprobante objECompro in listEChequeCompro)
                  {
                      numRow++;

                      pa = new Paragraph(numRow == 1 ? 30 : 10, objECompro.Transaccion, fdefault);
                      pa.IndentationLeft = 31;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, objECompro.NumComprobante.ToString(), fdefault);
                      pa.IndentationLeft = 68;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, objECompro.Referencia, fdefault);
                      pa.IndentationLeft = 106;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, objECompro.Moneda, fdefault);
                      pa.IndentationLeft = 418;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, objECompro.Importe.ToString("N2", CultureInfo.CreateSpecificCulture("en-US")), fdefault);
                      pa.Alignment = Element.ALIGN_LEFT;
                      pa.IndentationLeft = 450;
                      pdfDoc.Add(pa);

                  }

                  int numRowVoucher = 0;
                  /*-- VOUCHER ESPACIO 100 , distancia para iniciar 38pt + (120pt - (10 * numRow)) , total de row 10 aprox --*/
                  foreach (EChequeVoucher objEVoucher in listEChequeVoucher)
                  {

                      numRowVoucher++;

                      pa = new Paragraph(numRowVoucher == 1 ? 152 - (10 * numRow) : 10, objEVoucher.GlosaCuentaContable, fdefault);
                      pa.IndentationLeft = 31;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, objEVoucher.CuentaContable.ToString(), fdefault);
                      pa.IndentationLeft = 338;
                      pdfDoc.Add(pa);

                      pa = new Paragraph(0, Convert.ToDecimal(objEVoucher.ImporteSoles).ToString("N2", CultureInfo.CreateSpecificCulture("en-US")), fdefault);
                      pa.Alignment = Element.ALIGN_RIGHT;
                      pa.IndentationRight = objEVoucher.CargoAbono == ConstCargoAbono.DEBE ? 136 : 25;
                      pdfDoc.Add(pa);

                  }


                  /*-- DATOS CHEQUE --*/

                  /*-- FECHA --*/
                  pa = new Paragraph(258 - (numRowVoucher * 10), Convert.ToDateTime(objE.FechaPago).ToString("dd    MM   yyyy"), fdefault);
                  pa.IndentationLeft = 148;
                  pdfDoc.Add(pa);

                  /*-- IMPORTE + asteriscos --*/
                  pa = new Paragraph(0, string.Concat(new string('*', 16 - objE.ImporteCheque.ToString().Length), Convert.ToDecimal(objE.ImporteCheque).ToString("N2", CultureInfo.CreateSpecificCulture("en-US"))), fdefault);
                  pa.IndentationLeft = 292;
                  pdfDoc.Add(pa);

                  /*-- PROVEEDOR BENEFICIARIO --*/
                  pa = new Paragraph(28, objE.Beneficiario.Trim(), fdefault);
                  pa.IndentationLeft = 150;
                  pdfDoc.Add(pa);

                 
                  /*-- IMPORTE EN LETRAS --*/
                  string impLetras = LaiveFunctions.NumeroToLetras(Convert.ToDecimal(objE.ImporteCheque), true);
                  fdefault = FontFactory.GetFont("Courier", 8, Font.BOLD, BaseColor.BLACK);
                  pa = new Paragraph(18, string.Concat("***", impLetras, new string('*', 74 - impLetras.Length)), fdefault);
                  pa.IndentationLeft = 8;
                  pdfDoc.Add(pa);

                  EChequeFirma eChequeFirma = new EChequeFirma();
                  eChequeFirma.IdCheque = objE.IdCheque;
                  eChequeFirma = (EChequeFirma)objBOI.GetFirmasFirmante(eChequeFirma);

                  float ratio;
                  Paragraph p = new Paragraph(68);
                  iTextSharp.text.Image image;
                  bool rubricaValida = false;
                  try
                  {
                      image = iTextSharp.text.Image.GetInstance(eChequeFirma.Firma1erFirmante);
                      ratio = 66 / image.Height;
                      image.ScaleAbsolute(image.Width * ratio, 66);
                      p.IndentationLeft = 200;
                      p.Add(new Chunk(image, 0, 0));
                      rubricaValida = true;
                  }
                  catch {
                      jMessage.Message = "- No se encontro la rubrica del primer firmante.<br/>";
                  }

                  try
                  {
                      image = iTextSharp.text.Image.GetInstance(eChequeFirma.Firma2doFirmante);
                      ratio = 66 / image.Height;
                      image.ScaleAbsolute(image.Width * ratio, 66);
                      p.Add(new Chunk(image, 0, 0));
                      rubricaValida = true;
                  }
                  catch {
                      jMessage.Message += "- No se encontro la rubrica del segundo firmante.<br/>";
                  }

                  if(rubricaValida)
                    pdfDoc.Add(p);

              }

              pdfDoc.Close();

              Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
              pdfdocument.LoadFromBytes(ms.ToArray());
              pdfdocument.PrinterName = this.GetParametroSistemaString(ConstParametroSistema.NOMBRE_IMPRESORA_CHEQUE);
              pdfdocument.PrintDocument.Print();
              pdfdocument.Dispose();

              jMessage.Message += "Impresión satisfactoria !!!";
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
