using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Entity.Fi;
using Laive.Core.Entity;
using Laive.Core.Data;
using LGBOQry = Laive.BOQry.Fi;
using MGBOMnt = Laive.BOMnt.Mg;
using DIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using Laive.Core.Common;
using System.Web.Script.Serialization;
using LAIVE.V1.Controllers;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using System.Data.SqlClient;
using System.Web.UI;

//using Microsoft.Office.Interop.Excel;
namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ImportarDetraccionController : SamcontrollerBase
    {
        private string _fileName;
        private int inthtmlEjercicio;
        private string inthtmlNumeroOperacion;
        private string strhtmlConstanciaSunat;
        private string strhtmlFechaConstancia;
        private string strhtmlDocumentoProveedor;
        private string strhtmlPreImpreso;
        private string strhtmlImporteDeposito;
        private string strhtmlPeriodoTributario;

        private HtmlTextWriter tw;
        private StringWriter sw;
        private StringBuilder sb;

        private object m_objOpt = System.Reflection.Missing.Value;

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetBandeja()
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
            EDELotePago objE = new EDELotePago();
            objE.EjercicioLote = DateTime.Now.Year;
            var EjercicioLote = objBO.GetByCriteria<EDELotePago>(objE);

            jsonR.rows = jsonR.resultArray<EDELotePago>(objE.ColumnSet(), EjercicioLote);

            return Json(jsonR);

        }

        [HttpPost]
        public JsonResult GetBandejaEjercicio(int Ejercicio)
        {
            JsonSamNet jsonR = new JsonSamNet();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
            EDELotePago objE = new EDELotePago();
            objE.EjercicioLote = Ejercicio;
            var EjercicioLote = objBO.GetByCriteria<EDELotePago>(objE);

            jsonR.rows = jsonR.resultArray<EDELotePago>(objE.ColumnSet(), EjercicioLote);

            return Json(jsonR);

        }


        [HttpPost]
        public JsonResult GenerarPagoSunat(int EjercicioLote, int NumeroLote, int IdLoteDetraccion, string estadoLote)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                string strRuc = "D20100095450";
                string strPeriodo = Convert.ToString(EjercicioLote).Substring(2, 2);
                string strNumeroLote = Convert.ToString(NumeroLote);
                string strNombreArchivo = strRuc + strPeriodo + strNumeroLote;
                string ruta = Server.MapPath(@"~\FileTemp");
                string archivo = ruta + "\\" + strNombreArchivo + ".txt";

                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
                EDELotePago objE = new EDELotePago();
                objE.IdLoteDetraccion = IdLoteDetraccion;
                objE.EjercicioLote = EjercicioLote;
                objE.NumeroLote = NumeroLote;
                objE.EstadoLote = ConstLotePagoEstado.GENERAR_PAGO_SUNAT;
                objE.ArchivoDeposito = strNombreArchivo + ".txt";

                ICollection<EDELotePago> listLotePago = objBO.GetList<EDELotePago>(objE);

                if (estadoLote != ConstLotePagoEstado.CONCILIAR_PAGO)
                {
                    FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
                    objBOMnt.UpdateGenerarPagoSunat(objE);

                }
                //Generar archivo de pago sunat
                //El archivo se crea en la carpera FileTemp para que despues sea descargado.
                FileInfo info = new FileInfo(archivo);
                info.Delete();


                if (!info.Exists)
                {
                    using (StreamWriter writer = info.CreateText())
                    {
                        foreach (EDELotePago eSel in listLotePago)
                        {
                            writer.WriteLine(eSel.Registro);

                        }

                        writer.Close();
                        //aca escribir archivo de texto creado.
                    }
                }



                message.Status = JsonMessageStatus.SUCCESS;
                message.Message = "El Archivo Pago Sunat se genero satisfactoriamente.";

            }
            catch (Exception e)
            {
                message.Status = JsonMessageStatus.INVALID;
                message.Message = e.Message;
            }

            return Json(message);

        }

        [HttpPost]
        public JsonResult GenerarArchivoSunat(int IdLoteDetraccion, int NumeroLote, int EjercicioLote, string TraBaanBco, int NroBaanBco, int LoteContable, int NroFinalizacion)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
                EDELotePago objE = new EDELotePago();
                objE.IdLoteDetraccion = IdLoteDetraccion;
                ICollection<EDELotePago> listLotePago = objBO.GetList<EDELotePago>(objE);


                DIBOQry.IDeLotePago objBOBaan = (DIBOQry.IDeLotePago)WCFHelper.GetObject<DIBOQry.IDeLotePago>(typeof(DIBOQry.DELotePago));
                objE.EjercicioLote = EjercicioLote;
                objE.TraBaanBco = TraBaanBco;
                objE.NroBaanBco = NroBaanBco;
                objE.LoteContable = LoteContable;
                objE.NroFinalizacion = NroFinalizacion;
                objE.EstadoLote = ConstLotePagoEstado.ACTUALIZAR_PAGO;


                if (objBOBaan.ExistsTrabaan(objE))
                {
                    message.Status = JsonMessageStatus.INFORMATION;
                    message.Message = "Los datos ya se encuentran asiganados en otro Lote.";
                }
                else if (!objBOBaan.ExistsCuentaCaja(objE))
                {
                    message.Status = JsonMessageStatus.INFORMATION;
                    message.Message = "El importe de la cuenta Caja no es igual al importe de deposito.";
                }
                else if (!objBOBaan.ExistsCuentaIgv(objE))
                {
                    message.Status = JsonMessageStatus.INFORMATION;
                    message.Message = "El importe de la cuenta IGV no es igual al importe de lote.";
                }
                else
                {

                    string strRuc = "D20100095450";
                    string strPeriodo = Convert.ToString(EjercicioLote).Substring(2, 2);
                    string strNumeroLote = Convert.ToString(NumeroLote);
                    string strNombreArchivo = strRuc + strPeriodo + strNumeroLote;
                    string ruta = Server.MapPath(@"~\FileTemp");
                    string archivo = ruta + "\\" + strNombreArchivo + ".txt";

                    objE.ArchivoDeposito = strNombreArchivo;
                    //Actualizar datos en la tabla FI_DELotePago
                    FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
                    objBOMnt.UpdateTraBaanLotPago(objE);
                    //**********************************************************************************************************************

                    message.Status = JsonMessageStatus.SUCCESS;
                    message.Message = "Los datos se actualizaron satisfactoriamente.";

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
        public JsonResult UpdateConcilacion(int Ejercicio, int NumeroLote)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                EDELotePago objE = new EDELotePago();
                objE.EjercicioLote = Ejercicio;
                objE.NumeroLoteIni = NumeroLote;
                objE.NumeroLoteFin = NumeroLote;

                FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
                objBOMnt.UpdateConcilacionPago(objE);
                message.Status = JsonMessageStatus.SUCCESS;
            }
            catch (Exception e)
            {
                message.Status = JsonMessageStatus.INVALID;
                message.Message = e.Message;
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult ImportarLotePago(int Ejercicio, int NumeroLoteIni)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
                EDELotePago objE = new EDELotePago();
                objE.EjercicioLote = Ejercicio;
                //objE.NumeroLote = NumeroLote;
                objE.NumeroLoteIni = NumeroLoteIni;
                objE.EjercicioLote = Ejercicio;
                //objE.NumeroLoteFin = NumeroLoteFin;

                FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));

                DIBOQry.IDeLotePago objBOLP = (DIBOQry.IDeLotePago)WCFHelper.GetObject<DIBOQry.IDeLotePago>(typeof(DIBOQry.DELotePago));

                if (Ejercicio != 0 && !objBO.Exists(objE))
                {
                    message.Status = JsonMessageStatus.INFORMATION;
                    message.Message = "El Lote ingresado no se encuentra registrado.";
                }
                else if (objBOLP.ExistsIdLotePago(objE))
                {
                    message.Status = JsonMessageStatus.INFORMATION;
                    message.Message = "El Lote de Pago ya se encuentra registrado.";
                }
                else
                {
                    objBOMnt.UpdateImportarLotePago(objE);
                    message.Status = JsonMessageStatus.SUCCESS;
                    message.Message = "Se Importo Satisfactoriamente";
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
        public JsonResult DeleteLoteDetraccion(int IdLoteDetraccion)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                EDELotePago objE = new EDELotePago();
                objE.IdLoteDetraccion = IdLoteDetraccion;
                IBOUpdate objBOMnt = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(FIBOMnt.DELotePago));
                objBOMnt.DeleteData(objE);
                message.Status = JsonMessageStatus.SUCCESS;
                message.Message = "El Lote de Pago se elimino satisfactoriamente.";
            }
            catch (Exception e)
            {
                message.Status = JsonMessageStatus.INVALID;
                message.Message = e.Message;
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult UploadFile(int EjercicioLote, int NumeroLote, string Ruta)
        {
            JsonMessage message = new JsonMessage();
            FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
            
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    var extension = Path.GetExtension(file.FileName);

                    var strrutah = System.IO.Directory.GetParent(file.FileName).ToString();
                    


                    //variable locales
                    List<string> lines = new List<string>();
                    System.Net.WebClient client = new System.Net.WebClient();

                    int inthtmlLote;
                
                    inthtmlLote =int.Parse(fileName.Trim().Substring(18, 4));
                    StreamReader r;
                    string line;
                    int posicion = 0;

                    if (extension == ".html")
                    {
                        Stream file3 = Request.Files[i].InputStream;
                        
                        //Stream d;
                       
                        //d = client.OpenRead("D:\\Detraccion\\Constancia Detraccion\\ConstDetr2015\\2015\\Octubre\\ConsDetr-44986836-2995.html");
                        //d = client.OpenRead(file3.ToString());

                        r = new StreamReader(file3);
                        line = r.ReadLine();

                        using (StreamReader reader = new StreamReader(file3))
                        {
                            while (!reader.EndOfStream)
                            {
                                lines.Add(reader.ReadLine());
                            }
                        }

                        //while (line != null)
                        //{
                        //    line = r.ReadLine();

                        //    sb = new StringBuilder(line);
                        //    sw = new StringWriter(sb);
                        //    tw = new HtmlTextWriter(sw);


                        //    lines.Add(r.ReadLine());

                        //    posicion++;
                        //}

                        var varLineConstanciaNumero = lines.Where(s => s.Contains("N�mero de constancia")).FirstOrDefault();
                        //string[] valueLineConstanciaNumero = varLineConstanciaNumero.Split('\t');

                        if (varLineConstanciaNumero == null) 
                        {
                            string[] valuestrhtmlConstanciaSunat = lines[59].Split('\t');
                            strhtmlConstanciaSunat = valuestrhtmlConstanciaSunat[1].ToString().Trim().Substring(4, 8);

                            string[] valuestrhtmlDocumentoProveedor = lines[79].Split('\t');
                            strhtmlDocumentoProveedor = valuestrhtmlDocumentoProveedor[1].ToString().Trim().Substring(4, 11);

                            int montoIni = lines[107].Trim().IndexOf("</td");
                            string[] valuestrhtmlImporteDeposito = lines[107].Split('\t');
                            strhtmlImporteDeposito = valuestrhtmlImporteDeposito[1].ToString().Trim().Substring(7, montoIni - 7);

                            string[] valuestrhtmlFechaConstancia = lines[111].Split('\t');
                            strhtmlFechaConstancia = valuestrhtmlFechaConstancia[1].Trim().Substring(4, 22);

                            string[] valueinthtmlEjercicio = lines[115].Split('\t');
                            inthtmlEjercicio = int.Parse(valueinthtmlEjercicio[1].Trim().Substring(4, 4));

                            string[] valuestrhtmlPreImpreso = lines[123].Split('\t');
                            strhtmlPreImpreso = valuestrhtmlPreImpreso[1].Trim().Substring(4, 13);

                            string[] valueinthtmlNumeroOperacion = lines[127].Split('\t');
                            inthtmlNumeroOperacion = valueinthtmlNumeroOperacion[1].Trim().Substring(4, 9);

                            string[] valueinthtmlPeriodoTributario = lines[115].Split('\t');
                            strhtmlPeriodoTributario = valueinthtmlPeriodoTributario[1].Trim().Substring(4, 6);

                        }
                        else
                        {
                            string[] valuestrhtmlConstanciaSunat = lines[61].Split('<');
                            strhtmlConstanciaSunat = valuestrhtmlConstanciaSunat[1].ToString().Trim().Substring(3, 8);

                            string[] valuestrhtmlDocumentoProveedor = lines[73].Split('<');
                            strhtmlDocumentoProveedor = valuestrhtmlDocumentoProveedor[1].ToString().Trim().Substring(3, 11);

                            int montoIni = lines[94].Trim().IndexOf("</TD");
                            string[] valuestrhtmlImporteDeposito = lines[94].Split('<');
                            strhtmlImporteDeposito = valuestrhtmlImporteDeposito[1].ToString().Trim().Substring(6, montoIni - 7);

                            string[] valuestrhtmlFechaConstancia = lines[97].Split('<');
                            strhtmlFechaConstancia = valuestrhtmlFechaConstancia[1].Trim().Substring(3, 22);

                            string[] valueinthtmlEjercicio = lines[100].Split('<');
                            inthtmlEjercicio = int.Parse(valueinthtmlEjercicio[1].Trim().Substring(3, 4));

                            string[] valuestrhtmlPreImpreso = lines[106].Split('<');
                            strhtmlPreImpreso = valuestrhtmlPreImpreso[1].Trim().Substring(3, 13);

                            string[] valueinthtmlNumeroOperacion = lines[109].Split('<');
                            inthtmlNumeroOperacion = valueinthtmlNumeroOperacion[1].Trim().Substring(3, 9);

                            string[] valueinthtmlPeriodoTributario = lines[100].Split('<');
                            strhtmlPeriodoTributario = valueinthtmlPeriodoTributario[1].ToString().Trim().Substring(3, 6);
                        }
                        
                        //d.Close();
                    }
                    else
                    {
                        Stream file2 = Request.Files[i].InputStream;

                        
                        using (StreamReader reader = new StreamReader(file2))
                        {
                            while (!reader.EndOfStream)
                            {
                                lines.Add(reader.ReadLine());
                            }
                        }

                    }
                    
                    //string[] lines = System.IO.File.ReadAllLines(path);
                    
                    DIBOQry.IDeLotePago objBOLPago = (DIBOQry.IDeLotePago)WCFHelper.GetObject<DIBOQry.IDeLotePago>(typeof(DIBOQry.DELotePago));
                    EDELotePago eDELotePago = new EDELotePago();
                    eDELotePago.EjercicioLote = EjercicioLote;
                    eDELotePago.NumeroLote = NumeroLote;
                    eDELotePago = (EDELotePago)objBOLPago.GetByEjercicioLote(eDELotePago);

                    if (eDELotePago == null)
                    {
                        message.Status = JsonMessageStatus.INFORMATION;
                        message.Message = "No se encontro el Ejercicio - Lote";
                        return Json(message);
                    }
                    eDELotePago.EstadoLote = ConstConciliado.CONCILIADO;

                    //*************************************************************************************************************************
                   
                    if (extension == ".html")
                    {
                       // if (inthtmlEjercicio != eDELotePago.EjercicioLote || inthtmlLote != eDELotePago.NumeroLote)
                        if (inthtmlLote != eDELotePago.NumeroLote)
                        {
                            message.Status = JsonMessageStatus.INFORMATION;
                            message.Message = "El número de Lote del Archivo no corresponte al número de lote del registro seleccionado.";
                            return Json(message);
                        }
                        else {
                            eDELotePago.OperacionDeposito = inthtmlNumeroOperacion;
                            eDELotePago.ArchivoDeposito = "D20100095450" + inthtmlEjercicio.ToString().Trim().Substring(2, 2) + inthtmlLote.ToString().Trim() + ".txt";
                            eDELotePago.ArchivoSunat = fileName;
                            eDELotePago.ConstanciaSunat = strhtmlConstanciaSunat;
                            eDELotePago.FechaConstancia = strhtmlFechaConstancia;

                            
                            objBOMnt.UpdateLotePago(eDELotePago);
                        }
                        
                    }
                    else {

                        var varLine = lines.Where(s => s.Contains("Lote")).FirstOrDefault();
                        string[] valueLine = varLine.Split('\t');

                        if (varLine == null)
                        {
                            message.Status = JsonMessageStatus.INFORMATION;
                            message.Message = "No se encontro el Dato \"Lote\" en el archivo.";
                            return Json(message);
                        }

                        if (valueLine[1].Substring(0, 2) != eDELotePago.EjercicioLote.ToString().Substring(2) || valueLine[1].Substring(2) != eDELotePago.NumeroLote.ToString())
                        {
                            message.Status = JsonMessageStatus.INFORMATION;
                            message.Message = "El número de Lote del Archivo no corresponte al número de lote del registro seleccionado.";
                            return Json(message);

                        }
                        else
                        {

                            //variables para de la tabla FI_DELotePago
                            string[] valueLineNumeroOperacion = lines[5].Split('\t');
                            string[] valueLineFechaConstancia = lines[6].Split('\t');
                            string[] valueLineArchivoDeposito = lines[7].Split('\t');
                            string[] valuePosicionConstanciaSunat = fileName.Split('-');

                            eDELotePago.OperacionDeposito = valueLineNumeroOperacion[1].ToString().Trim();
                            eDELotePago.ArchivoDeposito = valueLineArchivoDeposito[1].ToString().Trim();
                            eDELotePago.ArchivoSunat = fileName;
                            eDELotePago.ConstanciaSunat = valuePosicionConstanciaSunat[1].ToString().Trim();
                            eDELotePago.FechaConstancia = valueLineFechaConstancia[1].ToString().Trim();
                            //Actualizar en la tabla FI_DELotePago

                          
                            objBOMnt.UpdateLotePago(eDELotePago);

                        }
                    }

                    

                    DIBOQry.IDEPagoComprobante objBOPCompro = (DIBOQry.IDEPagoComprobante)WCFHelper.GetObject<DIBOQry.IDEPagoComprobante>(typeof(DIBOQry.DEPagoComprobante));
                    EDEPagoComprobanteConcilia eDEPagoComprobanteConcilia = new EDEPagoComprobanteConcilia();
                    eDEPagoComprobanteConcilia.IdLoteDetraccion = eDELotePago.IdLoteDetraccion;
                    ICollection<EDEPagoComprobanteConcilia> listCConcilia = objBOPCompro.GetComprobanteDetraForConsiliacion<EDEPagoComprobanteConcilia>(eDEPagoComprobanteConcilia);
                    ICollection<EDEPagoComprobanteConciliaMonto> listCConciliaMonto = objBOPCompro.GetComprobanteDetraForConsiliacionMonto<EDEPagoComprobanteConciliaMonto>(eDEPagoComprobanteConcilia);

                    if (listCConcilia == null || listCConcilia.Count() == 0)
                    {
                        message.Status = JsonMessageStatus.INFORMATION;
                        message.Message = "No se encontraron comprobantes para el numero de Lote seleccionado.";
                        return Json(message);
                    }

                    //index 17 inicia el detalle
                    int indNumDoc = 2; //indice de ubicacion de Numero de Doc
                    int indMonto = 8; //indice de ubicacion del Monto
                    int indComprobante = 11; //indice de ubicacion del Comprobante
                    int lenNewData = 14; //numero de lineas para iniciar un nuevo bloque de datos
                    int intNumeroConstancia = 0;//numero de lineas para iniciar un nuevo bloque de datos

                    if (extension == ".html")
                    {
                        EDEPagoComprobanteConcilia comprobante = listCConcilia.Where(x => x.NroDocIdentidad == strhtmlDocumentoProveedor && x.PreImpreso == strhtmlPreImpreso).FirstOrDefault();

                        EDEPagoComprobanteConciliaMonto comprobantemonto = listCConciliaMonto.Where(x => x.NroDocIdentidad == strhtmlDocumentoProveedor && x.PreImpreso == strhtmlPreImpreso).FirstOrDefault();

                        decimal dcImpDeposito = decimal.Parse(strhtmlImporteDeposito);

                        if (comprobantemonto != null)
                        {
                            if (comprobantemonto.ImpDeposito == Convert.ToDecimal(dcImpDeposito))
                            {
                                comprobante.Conciliado = ConstConciliado.CONCILIADO;
                                //comprobantemonto.Conciliado = ConstConciliado.CONCILIADO;
                                comprobante.ConstanciaSunat = strhtmlConstanciaSunat;
                                comprobante.PeriodoTributario = strhtmlPeriodoTributario;
                            }
                            else
                            {
                                comprobante.Conciliado = ConstConciliado.ERROR;
                                eDELotePago.EstadoLote = ConstConciliado.ERROR;
                                eDELotePago.ConstanciaSunat = "";
                            }
                            objBOMnt.UpdateConcilacionPagoComprobante(comprobante);
                            
                        }
                    }
                    else
                    {
                        for (int index = 17; index < lines.Count() - 14; index += lenNewData) //-14 para evitar desbordamiento
                        {
                            string[] valueLineNumDoc = lines[index + indNumDoc].Split('\t');
                            string[] valueLineComprobante = lines[index + indComprobante].Split('\t');
                            string[] valueLineMonto = lines[index + indMonto].Split('\t');
                            string[] valueConstanciaSunat = lines[index + intNumeroConstancia].Split('\t');
                            string[] valuePeriodoTributario = lines[index + 9].Split('\t');

                            EDEPagoComprobanteConcilia comprobante = listCConcilia.Where(x => x.NroDocIdentidad == valueLineNumDoc[1].Trim() && x.PreImpreso == valueLineComprobante[1].Trim()).FirstOrDefault();

                            EDEPagoComprobanteConciliaMonto comprobantemonto = listCConciliaMonto.Where(x => x.NroDocIdentidad == valueLineNumDoc[1].Trim() && x.PreImpreso == valueLineComprobante[1].Trim()).FirstOrDefault();

                            if (comprobantemonto != null)
                            {
                                if (comprobantemonto.ImpDeposito == Convert.ToDecimal(valueLineMonto[1].Trim()))
                                {
                                    comprobante.Conciliado = ConstConciliado.CONCILIADO;
                                    //comprobantemonto.Conciliado = ConstConciliado.CONCILIADO;
                                    comprobante.ConstanciaSunat = valueConstanciaSunat[1].Trim();
                                    comprobante.PeriodoTributario = valuePeriodoTributario[1].Trim();
                                   
                                }
                                else
                                {
                                    comprobante.Conciliado = ConstConciliado.ERROR;

                                    eDELotePago.EstadoLote = ConstConciliado.ERROR;
                                    comprobante.ConstanciaSunat = "";
                                }
                                //Actualiza constancia sunat aca comprobante (detalle)
                                objBOMnt.UpdateConcilacionPagoComprobante(comprobante);
                            }
                        }
                    }

                    
                    //actualiza el estadolote de detraccion - cabecera
                    objBOMnt.UpdateConcilacionPago(eDELotePago);
                    if (eDELotePago.EstadoLote == ConstConciliado.CONCILIADO)
                    {
                        message.Status = JsonMessageStatus.SUCCESS;
                        message.Message = "Conciliacion Existosa.";
                    }
                    else {
                        message.Status = JsonMessageStatus.INFORMATION;
                        message.Message = "Algunos registros presentan errores. (estado 5)";
                    }
                }

            }
            catch (Exception e)
            {

                message.Status = JsonMessageStatus.INVALID;
                message.Message = e.Message;
            }

            return Json(message);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public FileContentResult GetGenerarPagoSunat(int EjercicioLote, int NumeroLote, int IdLoteDetraccion, string EstadoLote)
        {

            string strRuc = "D20100095450";
            string strPeriodo = Convert.ToString(EjercicioLote).Substring(2, 2);
            string strNumeroLote = Convert.ToString(NumeroLote);
            string strNombreArchivo = strRuc + strPeriodo + strNumeroLote;
            string ruta = Server.MapPath(@"~\FileTemp");
            string archivo = ruta + "\\" + strNombreArchivo + ".txt";
            string archivoPlantilla = ruta + "\\" + "PlantillaSunat.txt";

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(DIBOQry.DELotePago));
            EDELotePago objE = new EDELotePago();
            objE.IdLoteDetraccion = IdLoteDetraccion;
            objE.EjercicioLote = EjercicioLote;
            objE.NumeroLote = NumeroLote;
            objE.EstadoLote = ConstLotePagoEstado.GENERAR_PAGO_SUNAT;
            objE.ArchivoDeposito = strNombreArchivo + ".txt";

            ICollection<EDELotePago> listLotePago = objBO.GetList<EDELotePago>(objE);

            //if (EstadoLote )

            if (EstadoLote == ConstLotePagoEstado.ACTUALIZAR_PAGO)
            {
                FIBOMnt.IDELotePago objBOMnt = (FIBOMnt.IDELotePago)WCFHelper.GetObject<FIBOMnt.IDELotePago>(typeof(FIBOMnt.DELotePago));
                objBOMnt.UpdateGenerarPagoSunat(objE);

            }

            StringWriter sw = new StringWriter();

            if (Convert.ToInt32(EstadoLote) >= Convert.ToInt32(ConstLotePagoEstado.ACTUALIZAR_PAGO))
            {
                FileInfo info = new FileInfo(archivoPlantilla);
                using (sw)
                {
                    foreach (EDELotePago eSel in listLotePago)
                    {
                        sw.WriteLine(eSel.Registro);
                    }

                }
            }

            String contenido = sw.ToString();
            String NombreArchivo = strNombreArchivo;
            String ExtensionArchivo = "txt";
            return File(new System.Text.UTF8Encoding().GetBytes(contenido), "text/" + ExtensionArchivo, objE.ArchivoDeposito);
        }




    }
}
