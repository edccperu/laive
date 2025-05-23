using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Bi;
using System.Web.Script.Serialization;
using BIBOQry = Laive.BOQry.Bi;
using BIBOMnt = Laive.BOMnt.Bi;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.OleDb;
using Excel;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.BI.Controllers
{
    public class CostosUnitariosController : SamcontrollerBase
    {
        //
        // GET: /BI/CostosUnitarios/
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }
            

        [HttpPost]
        public JsonResult GetDataGrdCostosUnitarios()
        {

            JsonSamNet jsonR = new JsonSamNet();

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.CostosUnitarios));
            ECostosUnitarios objE = new ECostosUnitarios();
            objE.Año = DateTime.Now.Year;
            objE.Mes = DateTime.Now.Month;
            var lstEjercicio = objBO.GetByCriteria<ECostosUnitarios>(objE);
            jsonR.rows = jsonR.resultArray<ECostosUnitarios>(objE.ColumnSet(), lstEjercicio);

            return Json(jsonR);
        }

        [HttpPost]
        public JsonResult GetCostosUnitarios(int panio, int pmes)
        {
            JsonSamNet jsonR = new JsonSamNet();

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(BIBOQry.CostosUnitarios));
            ECostosUnitarios objE = new ECostosUnitarios();
            objE.Año = panio; //DateTime.Now.Year;
            objE.Mes = pmes; //  DateTime.Now.Month;
            var lstEjercicio = objBO.GetByCriteria<ECostosUnitarios>(objE);
            jsonR.rows = jsonR.resultArray<ECostosUnitarios>(objE.ColumnSet(), lstEjercicio);

            return Json(jsonR);
        }


        [HttpPost]
        public JsonResult UploadFile(int Anio, int Mes)
        {
            JsonMessage message = new JsonMessage();
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    List<string> lines = new List<string>();

                    var fileName = Path.GetFileName(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                   

                    Stream file3 = Request.Files[i].InputStream;

                    var path = Path.Combine(Server.MapPath("~/FileTemp/"), "Margen" + extension);
                    file.SaveAs(path);

                    ICollection<ECostosUnitarios> list;
                    list = TempData["_tempListKardex"] as ICollection<ECostosUnitarios>;
                    TempData.Keep("_tempListKardex");

                    FileStream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read);

                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    excelReader.IsFirstRowAsColumnNames = true;

                    DataSet result = excelReader.AsDataSet();
                    if (result.Tables.Count > 0)
                    {
                        ECostosUnitarios eCostoUnitario = new ECostosUnitarios();
                        eCostoUnitario.Año = Anio;
                        eCostoUnitario.Mes = Mes;

                        IBOUpdate objBO = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(BIBOMnt.CostosUnitarios));
                        objBO.DeleteData(eCostoUnitario);

                        foreach (DataRow dr in result.Tables[0].Rows)
                        {
                            eCostoUnitario.Fecha = DateTime.Parse(dr[2].ToString());
                            eCostoUnitario.Costo_Unitario = double.Parse(dr[4].ToString());
                            eCostoUnitario.Codigo_Articulo = dr[3].ToString();
                            objBO.UpdateData(eCostoUnitario);
                        }
                    }

                    excelReader.Close();
                    
                
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
