using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Core.Data;
using Laive.Core.Common;
using FIBOQry = Laive.BOQry.Fi;
using FIBOMnt = Laive.BOMnt.Fi;
using Laive.Entity.Fi;
using System.Web.Security;
using Laive.Core.Entity;
using LAIVE.V1.Controllers;
using System.Web.UI;

//using Microsoft.Office.Interop.Excel;


using System.Text;
using System.Text.RegularExpressions;


namespace LAIVE.V1.Areas.FI.Controllers
{
    public class ConstanciaSunatController : SamcontrollerBase
    {
        private string _fileName;
       
        //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //Microsoft.Office.Interop.Excel.Application m_objExcel;
        //Microsoft.Office.Interop.Excel.Workbooks m_objBooks;
        //Microsoft.Office.Interop.Excel._Workbook m_objBook;
        //Microsoft.Office.Interop.Excel.Sheets m_objSheets;
        //Microsoft.Office.Interop.Excel._Worksheet m_objSheet;
        //Microsoft.Office.Interop.Excel.Range m_objRange;
        //Microsoft.Office.Interop.Excel.Font m_objFont;
        //Microsoft.Office.Interop.Excel.QueryTables m_objQryTables;
        //Microsoft.Office.Interop.Excel._QueryTable m_objQryTable;
        //Microsoft.Office.Interop.Excel.Worksheet objHojaExcel;
        //Microsoft.Office.Interop.Excel.Range range;
       

        private object m_objOpt = System.Reflection.Missing.Value;

        //
        // GET: /FI/ConstanciaSunat/
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult UploadFile()

        {
            JsonMessage message = new JsonMessage();
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    //var file = Request.Files[i];
                   
                    //var fileName = Path.GetFileName(file.FileName);
                    //var extension = Path.GetExtension(file.FileName);
                    //var fileNombre = fileName.Substring(0, (fileName.Length - extension.Length));
                    
                    //var path = Path.Combine(Server.MapPath("~/FileTemp/"), fileName);
                    //file.SaveAs(path);

                    //FileStream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read);
                    //stream.Close();
                    //var pathTxt = stream.Name.Substring(0, (stream.Name.Length - extension.Length));
                    
                   
                    ////========================================================================================================
                    ////Recorrer archivo de excel.
                    ////========================================================================================================

                    //m_objExcel = null;
                    //m_objBooks = null;
                    //m_objBook = null;
                    //m_objSheets = null;
                    //m_objSheet = null;
                    //m_objRange = null;
                    //m_objFont = null;
                    //m_objQryTables = null;
                    //m_objQryTable = null;

                    //m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                    //m_objBooks  = (Microsoft.Office.Interop.Excel.Workbooks)m_objExcel.Workbooks;
                    //m_objBooks.OpenText(path, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, 1, Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited, Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierDoubleQuote, false, true, false, false, false, false, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    //m_objBook = m_objExcel.ActiveWorkbook;

                    ////Guardar el archivo de texto a archivo de excel
                    //m_objBook.SaveAs(pathTxt, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    //m_objBook.Close(false, m_objOpt, m_objOpt);
                    //m_objExcel.Quit();

                    ////abre el archivo de excel que ha sido exportado
                    //xlWorkBook = m_objExcel.Workbooks.Open("D:\\Documentos\\Excel\\ConsDetr-18014437 - 3002.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    //objHojaExcel = xlWorkBook.Worksheets.get_Item(1);
                    //range = objHojaExcel.UsedRange;

                    //int rows = range.Rows.Count;
                    //int cols = range.Columns.Count;
                    //FIBOMnt.Cheque objBO = new FIBOMnt.Cheque();
                    ////registros de la cabecera
                    //EConstaciaSunat esunat = new EConstaciaSunat();
                    //esunat.NumeroOperacion = (range.Cells[18, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    //esunat.FechaConstancia = Convert.ToDateTime((range.Cells[7, 2] as Microsoft.Office.Interop.Excel.Range).Value2);
                    //esunat.NombreArchivo = (range.Cells[8, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    //esunat.Lote = (range.Cells[9, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    //esunat.Ruc = (range.Cells[10, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    //esunat.RazonAdquiriente = (range.Cells[11, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    //esunat.NumeroDeposito = Convert.ToInt32((range.Cells[12, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString());
                    //esunat.Importe = Convert.ToDecimal((range.Cells[13, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString());

                    ////insertar los registros del archivo de excel a la tabla cabecera.
                    //objBO.ImportarDetraccionCabArchivo(esunat);
                    ////==========================================================================================================================
                    //int contar = 0;
                    //string strCadenaRow = "";
           
                    //var sentence = new List<String>();
                    //String[] elements=null;
                    //for (int row = 18; row <= rows; row++)
                    //{
                    //    if ((range.Cells[row, 2] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                    //    {
                    //        strCadenaRow += (range.Cells[row, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString().Trim() + "@";
                    //        elements = Regex.Split(strCadenaRow, "@");
                    //    }
                    //    else
                    //    {
                    //        contar += contar;
                    //    }
                    //    if (contar == 3)
                    //    {
                    //        break;
                    //    }
                        
                    //}

                    ////cargar entidades ..
                    //if (contar < 3)
                    //{
                    //    esunat.NumeroConstancia = elements[0].ToString();
                    //    esunat.TipoProveedor = elements[1].ToString();
                    //    esunat.RucProveedor = elements[2].ToString();
                    //    esunat.RazonSocialProveedor = elements[3].ToString();
                    //    esunat.CodigoOperador = elements[4].ToString();
                    //    esunat.GlosaOperacion = elements[5].ToString();
                    //    esunat.CodigoBien = elements[6].ToString();
                    //    esunat.GlosaBienServicio = elements[7].ToString();
                    //    esunat.ImporteDeposito = Convert.ToDecimal(elements[8]);
                    //    esunat.PeriodoTributario = elements[9].ToString();
                    //    esunat.TipoComprobante = elements[10].ToString();
                    //    esunat.NumeroComprobante = elements[11].ToString();

                    //    //insertar los registros del archivo de excel a la tabla detalle.
                    //    objBO.ImportarDetraccionDetArchivo(esunat);
                    //}
                    
                }

                message.Status = JsonMessageStatus.SUCCESS;
                message.Message = "Carga Correcta";

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
