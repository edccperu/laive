using Laive.Core.Common;
using Laive.Core.Data;
using Laive.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Co;
using System.Web.Script.Serialization;
using COBOQry = Laive.BOQry.Co;
using COBOMnt = Laive.BOMnt.Co;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.OleDb;
using Excel;
using LAIVE.V1.Controllers;

namespace LAIVE.V1.Areas.CO.Controllers
{
    public class KardexMaucController : SamcontrollerBase
    {
        //
        // GET: /KardexMauc/
        #region KardexProceso
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetDataGrdKdxActual(FlexigridParamSamNet Param)
        {

            JsonSamNet jsonR = new JsonSamNet();
            if (Param.query != null && Param.query != "")
            {
                string[] values = Param.query.Split(',');

                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(COBOQry.KardexTemp));
                EKardexAuto objE = new EKardexAuto();
                objE.Periodo = values[0];
                objE.Mes = values[1];
                objE.CodigoArticulo = values[2];

                ICollection<EKardexAuto> list = objBO.GetByCriteria<EKardexAuto>(objE);

                jsonR.rows = jsonR.resultArray<EKardexAuto>(objE.ColumnSet(), list);

            }

            return Json(jsonR);
        }

        public JsonResult GetDataGrdKdxDCA(FlexigridParamSamNet Param)
        {

            JsonSamNet jsonR = new JsonSamNet();
            if (Param.query != null && Param.query != "")
            {
                string[] values = Param.query.Split(',');

                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(COBOQry.KardexDca));

                EKardexDca objE = new EKardexDca();
                objE.Periodo = values[0];
                objE.Mes = values[1];
                objE.CodigoArticulo = values[2];

                ICollection<EKardexDca> list = objBO.GetByCriteria<EKardexDca>(objE);
                TempData["_tempListDCA"] = list;
                jsonR.rows = jsonR.resultArray<EKardexDca>(objE.ColumnSet(), list);

            }

            return Json(jsonR);
        }

        [HttpPost]
        public JsonResult GetDataGrdKdxCalculado(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            EKardexAuto objE = new EKardexAuto();
            ICollection<EKardexAuto> list;

            if (Param.query != null && Param.query != "")
            {
                string[] values = Param.query.Split(',');

                IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(COBOQry.KardexTemp));

                objE.Periodo = values[0];
                objE.Mes = values[1];
                objE.CodigoArticulo = values[2];

                list = objBO.GetByCriteria<EKardexAuto>(objE);
                TempData["_tempListKardex"] = list;

                jsonR.rows = jsonR.resultArray<EKardexAuto>(objE.ColumnSetCalculado(), list);

            }
            else
            {
                list = TempData["_tempListKardex"] as ICollection<EKardexAuto>;
                TempData.Keep("_tempListKardex");
                if (list != null)
                    jsonR.rows = jsonR.resultArray<EKardexAuto>(objE.ColumnSetCalculado(), list);
            }

            return Json(jsonR);

        }

        [HttpPost]
        public JsonResult GetDataGrdKdxDiferencia(FlexigridParamSamNet Param)
        {
            JsonSamNet jsonR = new JsonSamNet();
            EKardexAuto objE = new EKardexAuto();
            EKardexDiferencia objEDife = new EKardexDiferencia();
            ICollection<EKardexAuto> list;
            ICollection<EKardexDca> listDCA;


            list = TempData["_tempListKardex"] as ICollection<EKardexAuto>;
            TempData.Keep("_tempListKardex");

            listDCA = TempData["_tempListDCA"] as ICollection<EKardexDca>;
            TempData.Keep("_tempListDCA");

            if (list != null && list.Count > 0 && listDCA != null && listDCA.Count > 0)
            {
                var query = from tblmodi in list
                            join tbldca in listDCA on
                            new { tblmodi.Periodo, tblmodi.Mes, tblmodi.CodigoArticulo, tblmodi.FechaTransaccion, tblmodi.CodigoAlmacen, tblmodi.TipoOperacion, tblmodi.Orden }
                            equals new { tbldca.Periodo, tbldca.Mes, tbldca.CodigoArticulo, tbldca.FechaTransaccion, tbldca.CodigoAlmacen, tbldca.TipoOperacion, tbldca.Orden }
                            select new EKardexDiferencia
                            {
                                RowNumber = tblmodi.RowNumber,
                                Periodo = tblmodi.Periodo,
                                Mes = tblmodi.Mes,
                                CodigoArticulo = tblmodi.CodigoArticulo,
                                FechaTransaccion = tblmodi.FechaTransaccion,
                                CodigoAlmacen = tblmodi.CodigoAlmacen,
                                TipoOperacion = tblmodi.TipoOperacion,
                                Orden = tblmodi.Orden,
                                Secuencia = tblmodi.Secuencia,
                                MaucModificado = tblmodi.Mauc_OK,
                                IngresoCantidadMod = tblmodi.CantidadIngreso_OK,
                                IngresoUnitarioMod = tblmodi.UnitarioIngreso_OK,
                                IngresoCostoMod = tblmodi.CostoIngreso_OK,
                                EgresoCantidadMod = tblmodi.CantidadEgreso_OK,
                                EgresoUnitarioMod = tblmodi.UnitarioEgreso_OK,
                                EgresoCostoMod = tblmodi.CostoEgreso_OK,
                                CantidadSaldoModificado = tblmodi.CantidadSaldo_OK,
                                CostoSaldoModificado = tblmodi.CostoSaldo_OK,
                                MaucDCA = tbldca.Mauc,
                                IngresoCantidadDCA = tbldca.CantidadIngreso,
                                IngresoUnitarioDCA = tbldca.UnitarioIngreso,
                                IngresoCostoDCA = tbldca.CostoIngreso,
                                EgresoCantidadDCA = tbldca.CantidadEgreso,
                                EgresoUnitarioDCA = tbldca.UnitarioEgreso,
                                EgresoCostoDCA = tbldca.CostoEgreso,
                                CantidadSaldoDCA = tbldca.CantidadSaldo,
                                CostoSaldoDCA = tbldca.CostoSaldo,
                                DiferenciaCantidadSaldo = (tbldca.CantidadSaldo - tblmodi.CantidadSaldo_OK),
                                DiferenciaCostoSaldo = (tbldca.CostoSaldo - tblmodi.CostoSaldo_OK),
                                CodigoMovimiento = tblmodi.CodigoMovimiento,
                                GlosaMovimiento = tblmodi.GlosaMovimiento,
                                CodigoTransaccion = tblmodi.CodigoTransaccion,
                                GlosaTransaccion = tblmodi.GlosaTransaccion
                            };

                if (query != null && query.Count() > 0)
                {
                    jsonR.rows = jsonR.resultArray<EKardexDiferencia>(objEDife.ColumnSet(), query.ToList());
                }
            }

            return Json(jsonR);

        }

        [HttpPost]
        public JsonResult UpdateKardex(EKardexAuto Ekardex)
        {

            ICollection<EKardexAuto> list = TempData["_tempListKardex"] as ICollection<EKardexAuto>;
            TempData.Keep("_tempListKardex");
            var objE = (from a in list
                        where a.RowNumber == Ekardex.RowNumber
                        select a
                        ).First();

            switch (objE.TipoOperacion)
            {
                case ConstTipoMovimiento.EGRESO:
                    objE.CantidadEgreso = Ekardex.CantidadEgreso;
                    objE.UnitarioEgreso = Ekardex.UnitarioEgreso;
                    objE.CostoEgreso = Ekardex.CostoEgreso;
                    break;
                case ConstTipoMovimiento.INGRESO:
                    objE.CantidadIngreso = Ekardex.CantidadIngreso;
                    objE.UnitarioIngreso = Ekardex.UnitarioIngreso;
                    objE.CostoIngreso = Ekardex.CostoIngreso;
                    break;
            }

            objE.State = ConstFlagEstado.ACTIVADO;

            list = ProcesarKardex(list);

            TempData["_tempListKardex"] = list;
            TempData.Keep("_tempListKardex");

            return Json("");
        }

        [HttpPost]
        public JsonResult SaveKardex()
        {
            try
            {
                ICollection<EKardexAuto> list = TempData["_tempListKardex"] as ICollection<EKardexAuto>;
                TempData.Keep("_tempListKardex");

                foreach (EKardexAuto Ekdx in list)
                {
                    switch (Ekdx.TipoOperacion)
                    {
                        case ConstTipoMovimiento.EGRESO:
                            Ekdx.Cantidad_OK = Ekdx.CantidadEgreso_OK;
                            Ekdx.Unitario_OK = Ekdx.UnitarioEgreso_OK;
                            Ekdx.Costo_OK = Ekdx.CostoEgreso_OK;
                            break;
                        case ConstTipoMovimiento.INGRESO:
                            Ekdx.Cantidad_OK = Ekdx.CantidadIngreso_OK;
                            Ekdx.Unitario_OK = Ekdx.UnitarioIngreso_OK;
                            Ekdx.Costo_OK = Ekdx.CostoIngreso_OK;
                            break;
                    }
                }

                IBOUpdate DO = (IBOUpdate)new COBOMnt.KardexAuto();

                EKardexAutoSet eSet = new EKardexAutoSet();
                eSet.listKardex = list;
                DO.UpdateData(eSet);
                return Json("Datos Guardados Correctamente");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        public ICollection<EKardexAuto> ProcesarKardex(ICollection<EKardexAuto> list)
        {
            decimal _mauc = 0;
            decimal _SaldoCosto = 0;
            decimal _SaldoCantidad = 0;

            decimal _CostoProduccion = 0;
            decimal _CantidadProduccion = 0;

            Dictionary<string, decimal> listAlmCosto;
            Dictionary<string, decimal> listAlmCantidad;


            _mauc = list.First().Mauc;

            listAlmCosto = (from lA in list
                            where lA.TipoOperacion == ConstTipoMovimiento.SALDO
                            select new { lA.CodigoAlmacen, lA.CostoSaldo }).ToDictionary(lA => lA.CodigoAlmacen, lA => lA.CostoSaldo);

            listAlmCantidad = (from lA in list
                               where lA.TipoOperacion == ConstTipoMovimiento.SALDO
                               select new { lA.CodigoAlmacen, lA.CantidadSaldo }).ToDictionary(lA => lA.CodigoAlmacen, lA => lA.CantidadSaldo);



            _SaldoCosto = listAlmCosto.Sum(x => x.Value);
            _SaldoCantidad = listAlmCantidad.Sum(x => x.Value);

            if (list.First().TypoArticulo == 2)
            {
                _CostoProduccion = list.Where(x => x.CodigoMovimiento == 8 && x.CodigoTransaccion == 1).Sum(x => x.CostoIngreso);
                _CantidadProduccion = list.Where(x => x.CodigoMovimiento == 8 && x.CodigoTransaccion == 1).Sum(x => x.CantidadIngreso);

                _mauc = Math.Round((_CostoProduccion + _SaldoCosto) / (_CantidadProduccion + _SaldoCantidad), 4);

            }


            foreach (EKardexAuto EKar in list)
            {
                switch (EKar.TipoOperacion)
                {
                    case ConstTipoMovimiento.INGRESO:

                        if (EKar.TypoArticulo == 1)
                        {
                            var objEAnt = (from a in list
                                           where a.Orden == EKar.Orden && a.RowNumber < EKar.RowNumber && a.TipoOperacion == ConstTipoMovimiento.EGRESO
                                           select a
                            ).OrderByDescending(x => x.RowNumber).FirstOrDefault();

                            if (objEAnt != null)
                            {
                                EKar.UnitarioIngreso = objEAnt.UnitarioEgreso;
                            }

                            EKar.CostoIngreso = Math.Round(EKar.CantidadIngreso * EKar.UnitarioIngreso, 4);
                            if (EKar.UnitarioIngreso != _mauc)
                            {
                                _mauc = Math.Round((EKar.CostoIngreso + listAlmCosto.Sum(x => x.Value)) / (EKar.CantidadIngreso + listAlmCantidad.Sum(x => x.Value)), 4);
                            }
                        }
                        else
                        {
                            if (EKar.CodigoMovimiento != 8 && EKar.CodigoTransaccion != 1)
                            {
                                EKar.UnitarioIngreso = _mauc;
                                EKar.CostoIngreso = Math.Round(EKar.CantidadIngreso * EKar.UnitarioIngreso, 4);
                            }
                        }

                        EKar.CantidadIngreso_OK = EKar.CantidadIngreso;
                        EKar.UnitarioIngreso_OK = EKar.UnitarioIngreso;
                        EKar.CostoIngreso_OK = EKar.CostoIngreso;

                        break;
                    case ConstTipoMovimiento.EGRESO:
                        if (EKar.TypoArticulo == 1)
                        {
                            EKar.UnitarioEgreso = _mauc;
                            EKar.CostoEgreso = Math.Round(EKar.CantidadEgreso * EKar.UnitarioEgreso, 4);
                        }
                        else
                        {
                            if (EKar.CodigoMovimiento != 8 && EKar.CodigoTransaccion != 1)
                            {
                                EKar.UnitarioEgreso = _mauc;
                                EKar.CostoEgreso = Math.Round(EKar.CantidadEgreso * EKar.UnitarioEgreso, 4);
                            }

                        }
                        EKar.CantidadEgreso_OK = EKar.CantidadEgreso;
                        EKar.UnitarioEgreso_OK = EKar.UnitarioEgreso;
                        EKar.CostoEgreso_OK = EKar.CostoEgreso;

                        break;
                }


                if (EKar.TipoOperacion != ConstTipoMovimiento.SALDO)
                {
                    _SaldoCosto = Math.Round(_SaldoCosto + EKar.CostoIngreso - EKar.CostoEgreso, 4);
                    _SaldoCantidad = Math.Round(_SaldoCantidad + EKar.CantidadIngreso - EKar.CantidadEgreso, 4);

                    listAlmCosto[EKar.CodigoAlmacen] = Math.Round(listAlmCosto[EKar.CodigoAlmacen] + EKar.CostoIngreso - EKar.CostoEgreso, 4);
                    listAlmCantidad[EKar.CodigoAlmacen] = Math.Round(listAlmCantidad[EKar.CodigoAlmacen] + EKar.CantidadIngreso - EKar.CantidadEgreso, 4);

                    EKar.CostoSaldo = _SaldoCosto;
                    EKar.CantidadSaldo = _SaldoCantidad;
                }


                EKar.CostoSaldo_OK = EKar.CostoSaldo;
                EKar.CantidadSaldo_OK = EKar.CantidadSaldo;
                EKar.Mauc = _mauc;
                EKar.Mauc_OK = _mauc;

            }


            return list;
        }


        [HttpPost]
        public JsonResult UploadFile()
        {

           JsonMessage message = new JsonMessage();
           try
           {


              for (int i = 0; i < Request.Files.Count; i++)
              {
                 var file = Request.Files[i];

                 var fileName = Path.GetFileName(file.FileName);
                 var extension = Path.GetExtension(file.FileName);

                 var path = Path.Combine(Server.MapPath("~/FileTemp/"), "PlantillaOF" + extension);
                 file.SaveAs(path);

                 ICollection<EKardexAuto> list;
                 list = TempData["_tempListKardex"] as ICollection<EKardexAuto>;
                 TempData.Keep("_tempListKardex");

                 FileStream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read);
                 IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                 excelReader.IsFirstRowAsColumnNames = true;

                 DataSet result = excelReader.AsDataSet();
                 if (result.Tables.Count > 0)
                 {
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {

                       ICollection<EKardexAuto> objEAnt = (from a in list
                                                           where a.Orden == dr[5].ToString().Trim()
                                                           select a
                                     ).ToList();

                       foreach (EKardexAuto ekar in objEAnt)
                       {
                          ekar.UnitarioIngreso = Math.Round(decimal.Parse(dr[7].ToString()) / decimal.Parse(dr[6].ToString()), 4); ;
                          ekar.CostoIngreso = Math.Round(ekar.CantidadIngreso * decimal.Parse(dr[7].ToString()) / decimal.Parse(dr[6].ToString()), 2);
                          ekar.CantidadIngreso = ekar.CantidadIngreso;
                          ekar.State = ConstFlagEstado.ACTIVADO;
                       }

                       if (objEAnt.Sum(x => x.CostoIngreso) < decimal.Parse(dr[7].ToString()))
                       {
                          objEAnt.Last().CostoIngreso = objEAnt.Last().CostoIngreso + (decimal.Parse(dr[7].ToString()) - objEAnt.Sum(x => x.CostoIngreso));
                       }

                    }
                 }

                 excelReader.Close();
                 list = ProcesarKardex(list);

                 TempData["_tempListKardex"] = list;
                 TempData.Keep("_tempListKardex");

              }

                  message.Status = JsonMessageStatus.SUCCESS;
                  message.Message = "Carga Correcta";
           }
           catch(Exception e){

              message.Status = JsonMessageStatus.INVALID;
              message.Message = e.Message;
           }

           return Json(message);
        }


        #endregion

        #region KardexImportacion

        [HttpGet]
        public PartialViewResult ImportarKardex()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult ImportarKardexBaan(string Anio, string Mes, string CodigoArticulo)
        {
            JsonMessage jmessage = new JsonMessage();

            try
            {
                COBOQry.IKardexTemp objBO = (COBOQry.IKardexTemp)WCFHelper.GetObject<COBOQry.IKardexTemp>(typeof(COBOQry.KardexTemp));
                EKardexAuto objE = new EKardexAuto();
                objE.Periodo = Anio;
                objE.Mes = Mes;
                objE.CodigoArticulo = CodigoArticulo;

                objBO.ImportarKardex<EKardexAuto>(objE);

                IBOQuery objBONew = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(COBOQry.KardexTemp));
                ICollection<EKardexAuto> list = objBONew.GetByCriteria<EKardexAuto>(objE);

                if (list.Count > 0)
                {
                    list = ProcesarKardex(list);
                }

                COBOMnt.IKardexAuto objDO = (COBOMnt.IKardexAuto)WCFHelper.GetObject<COBOMnt.IKardexAuto>(typeof(COBOMnt.KardexAuto));
                objDO.UpdateValues(list);

                jmessage.Message = "IMPORTACIÓN CON EXITO";
                jmessage.Status = JsonMessageStatus.SUCCESS;
                return Json(jmessage);
            }
            catch (Exception e)
            {
                jmessage.Message = e.Message;
                jmessage.Status = JsonMessageStatus.INVALID;
                return Json(jmessage);
            }

        }

        [HttpPost]
        public JsonResult ImportarKardexDCA(string Anio, string Mes, string CodigoArticulo)
        {
           JsonMessage jmessage = new JsonMessage();

           try
           {
              COBOQry.IKardexTemp objBO = (COBOQry.IKardexTemp)WCFHelper.GetObject<COBOQry.IKardexTemp>(typeof(COBOQry.KardexTemp));
              EKardexAuto objE = new EKardexAuto();
              objE.Periodo = Anio;
              objE.Mes = Mes;
              objE.CodigoArticulo = CodigoArticulo;

              objBO.ImportarKardexDCA<EKardexAuto>(objE);
              jmessage.Message = "IMPORTACIÓN CON EXITO";
              jmessage.Status = JsonMessageStatus.SUCCESS;
              return Json(jmessage);
           }
           catch (Exception e)
           {
              jmessage.Message = e.Message;
              jmessage.Status = JsonMessageStatus.INVALID;
              return Json(jmessage);
           }

        }

        [HttpPost]
        public JsonResult GetDataGrdArticulosImportados(FlexigridParamSamNet Param)
        {

            JsonSamNet jsonR = new JsonSamNet();

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(COBOQry.ArticuloImportacion));
            EArticuloImportacion objE = new EArticuloImportacion();
            ICollection<EArticuloImportacion> list = objBO.GetByCriteria<EArticuloImportacion>(objE);
            jsonR.rows = jsonR.resultArray<EArticuloImportacion>(objE.ColumnSet(), list);

            return Json(jsonR);
        }


        #endregion
    }
}