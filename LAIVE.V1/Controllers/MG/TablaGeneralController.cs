using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laive.Entity.Mg;
using Laive.Core.Entity;
using Laive.Core.Data;
using MGBOQry = Laive.BOQry.Mg;
using MGBOMnt = Laive.BOMnt.Mg;
using Laive.Core.Common;

namespace LAIVE.V1.Controllers.MG
{
    public class TablaGeneralController : SamcontrollerBase
    {
        private static ICollection<ETablaGenDet> _dataProvider;

        [HttpGet]
        public PartialViewResult Index()
        {
            _dataProvider = null;
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(MGBOQry.TablaGen));
            ETablaGen eTablaGen = new ETablaGen();
            var TablaGen = objBO.GetList<ETablaGen>(eTablaGen);
            return PartialView("Index", TablaGen);
        }

        [HttpPost]
        public JsonResult GetBandeja(List<FilterOperator> filtro)
        {

            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(MGBOQry.TablaGen));
            ETablaGen eTablaGen = new ETablaGen();
            FilterSearch filterSearch = new FilterSearch();
            eTablaGen.EntityFilter = filterSearch.Create(filtro, eTablaGen.ColumnSet());
            JsonSamNet jsonR = new JsonSamNet();
            jsonR.rows = jsonR.resultArray<ETablaGen>(eTablaGen.ColumnSet(), objBO.GetByCriteria<ETablaGen>(eTablaGen));

            return Json(jsonR);
        }

        [HttpGet]
        public PartialViewResult GetEditModel(string idTabla, EntityState entityState)
        {
            ViewBag.EntityState = (int)entityState;
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(MGBOQry.TablaGen));
            ETablaGen eTablaGen = new ETablaGen();
            eTablaGen.IdTabla = idTabla;
            if (idTabla != "")
                eTablaGen = (ETablaGen)objBO.GetByKey(eTablaGen);

            eTablaGen.EntityState = entityState;
            return PartialView("EditModel", eTablaGen);
        }


        [HttpPost]
        public JsonResult GetEditModelDetails(FlexigridParamSamNet Param)
        {
            IBOQuery objBODet = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(MGBOQry.TablaGenDet));
            ETablaGenDet eTablaGenDet = new ETablaGenDet();
            if (Param.query == null || Param.query == "")
                eTablaGenDet.IdTabla = ConstDefaultValue.NOEXITCODE;
            else
                eTablaGenDet.IdTabla = Param.query;
            
            if (_dataProvider == null)
                _dataProvider = objBODet.GetByParentKey<ETablaGenDet>(eTablaGenDet);
            
            JsonSamNet jsonR = new JsonSamNet();
            if (_dataProvider != null)
                jsonR.rows = jsonR.resultArray<ETablaGenDet>(eTablaGenDet.ColumnSet(), _dataProvider);

            return Json(jsonR);
        }

        [HttpPost]
        public String UpdateModel(ETablaGen eTablaGen)
        {
            string mensaje = "";
            try
            {
                IBOUpdate objBOU = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(MGBOMnt.TablaGen));

                eTablaGen.TablaGenDet = _dataProvider;
                eTablaGen.IdPc = Session[ConstSessionVar.NAMEPCCLIENT].ToString();
                eTablaGen.IdUserTk = Session[ConstSessionVar.USERID].ToString();
                eTablaGen.FeRegistro = DateTime.Now;

                if (eTablaGen.EntityState == EntityState.Deleted)
                {
                    eTablaGen.StAnulado = ConstFlagEstado.ACTIVADO;
                    objBOU.DeleteData(eTablaGen);
                    mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Eliminados Correctamente", eTablaGen.IdTabla);
                }
                else
                {
                    eTablaGen.StAnulado = ConstFlagEstado.DESACTIVADO;
                    string[] coderesul = objBOU.UpdateData(eTablaGen);
                    mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Guardados Correctamente", coderesul == null?eTablaGen.IdTabla:coderesul[0]);
                }
            }
            catch (Exception e)
            {
                mensaje = CreateMessage(ConstTipoMessage.ERROR, e.Message, eTablaGen.IdTabla);
            }

            return mensaje;
        }

        [HttpGet]
        public String UpdateModelDetail(ETablaGenDet eTablaGenDet)
        {
            if (eTablaGenDet.IdCodigo != null && eTablaGenDet.IdCodigo != "")
            {
                var element = _dataProvider.FirstOrDefault(p => p.IdCodigo == eTablaGenDet.IdCodigo);
                if (element != null)
                {
                    if (eTablaGenDet.EntityState != EntityState.Deleted)
                    {
                        element.DsDescrip = eTablaGenDet.DsDescrip;
                        element.DsAbrev = eTablaGenDet.DsAbrev;
                        element.IdCodAlter = eTablaGenDet.IdCodAlter;
                        element.MtValor = eTablaGenDet.MtValor;
                    }
                    else
                    {
                        element.StAnulado = ConstFlagEstado.ACTIVADO;
                    }
                    element.EntityState = eTablaGenDet.EntityState;
                    element.IdPc = Session[ConstSessionVar.NAMEPCCLIENT].ToString();
                    element.IdUserTk = Session[ConstSessionVar.USERID].ToString();
                    element.FeRegistro = DateTime.Now;
                }
            }
            else
            {
                var elementId = "";

                if(_dataProvider!=null)
                    elementId = _dataProvider.Max(p => p.IdCodigo);
                else
                    elementId = "001";

                if (elementId == null)
                    eTablaGenDet.IdCodigo = "001";
                else
                    eTablaGenDet.IdCodigo = (int.Parse(elementId) + 1).ToString("000");
                eTablaGenDet.EntityState = EntityState.Added;
                eTablaGenDet.StAnulado = ConstFlagEstado.DESACTIVADO;
                eTablaGenDet.IdPc = Session[ConstSessionVar.NAMEPCCLIENT].ToString();
                eTablaGenDet.IdUserTk = Session[ConstSessionVar.USERID].ToString();
                eTablaGenDet.FeRegistro = DateTime.Now;


                _dataProvider.Add(eTablaGenDet);
            }

            return "";
        }
    }
}
