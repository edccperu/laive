using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYBOQry = Laive.BOQry.Sy;
using SYBOMnt = Laive.BOMnt.Sy;
using Laive.Core.Data;
using Laive.Core.Common;
using Laive.Core.Entity;
using Laive.Entity.Sy;
using System.DirectoryServices;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace LAIVE.V1.Controllers.SY
{
   public class RolesController : SamcontrollerBase
   {
      //private static ICollection<ETablaGenDet> _dataProvider;
      private NodeTreeView _nodeTreeView = new NodeTreeView();

      [HttpGet]
      public PartialViewResult Index()
      {
         //_dataProvider = null;
         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Rol));
         ERol eRol = new ERol();
         var Rol = objBO.GetList<ERol>(eRol);
         ViewBag.TotalRows = Rol.Count;
         return PartialView("Index", Rol);
      }

      [HttpGet]
      public PartialViewResult GetEditModel(int IdRol, EntityState entityState)
      {
         List<EMenuPage> listMenu;

         EMenuPage eMenuPage = new EMenuPage();
         ERol eRol = new ERol();
         eRol.IdRol = IdRol;
         IBOQuery objBOUser = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Rol));
         eRol = (ERol)objBOUser.GetByKey(eRol);

         if (eRol != null)
         {
            SYBOQry.IMenuPage objIMenuPage = (SYBOQry.IMenuPage)WCFHelper.GetObject<SYBOQry.IMenuPage>(typeof(SYBOQry.MenuPage));
            listMenu = objIMenuPage.GetListXidRol<EMenuPage>(eRol.IdRol).ToList();

 
         }
         else {
            eRol = new ERol();
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.MenuPage));
            listMenu = objBO.GetList<EMenuPage>(eMenuPage).ToList();

         }

            ViewBag.EntityState = (int)entityState;
            eRol.EntityState = entityState;
            NodeTreeView nodeTreeView = new NodeTreeView();

            nodeTreeView.id = ConstDefaultValue.ROOTMENU;
            nodeTreeView.text = "SAMNET";
            nodeTreeView.value = ConstDefaultValue.ROOTMENU;
            nodeTreeView.ChildNodes = GetTreeView(listMenu, ConstDefaultValue.ROOTMENU);
            nodeTreeView.showcheck = false;
            nodeTreeView.checkstate = 0;
            nodeTreeView.hasChildren = true;
            nodeTreeView.isexpand = true;
            nodeTreeView.complete = true;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.JsonMenuList = serializer.Serialize(nodeTreeView);
            ViewBag.BackPage = "Index";


         return PartialView("GetEditModel", eRol);
      }

      public List<NodeTreeView> GetTreeView(List<EMenuPage> list, string idPadre)
      {
         List<Laive.Entity.Sy.EMenuPage> query = list.Where(fruit => (fruit.IdPadre == idPadre)).OrderBy(fruit => fruit.NuOrden).ToList();
         if (query.Count == 0)
            return null;

         List<NodeTreeView> listNode = new List<NodeTreeView>();

         foreach (EMenuPage eMenuPage in query)
         {
            NodeTreeView nodeTreeView = new NodeTreeView();

            nodeTreeView.id = eMenuPage.IdMenuPage;
            nodeTreeView.text = eMenuPage.DsMenuPage;
            nodeTreeView.value = eMenuPage.IdMenuPage;
            nodeTreeView.ChildNodes = GetTreeView(list, eMenuPage.IdMenuPage);
            nodeTreeView.showcheck = true;
            nodeTreeView.checkstate = eMenuPage.StateCheck;
            nodeTreeView.hasChildren = eMenuPage.DsController == "";
            nodeTreeView.isexpand = true;
            nodeTreeView.complete = true;

            listNode.Add(nodeTreeView);
         }

         return listNode;
      }

      [HttpPost]
      public JsonResult GetUsuarioXRol(FlexigridParamSamNet Param)
      {
         JsonSamNet jsonR = new JsonSamNet();

         SYBOQry.IRol objBO = (SYBOQry.IRol)WCFHelper.GetObject<SYBOQry.IRol>(typeof(SYBOQry.Rol));
         EUsuario eRol = new EUsuario();
         ICollection<EUsuario> listUsuario = objBO.GetUsuariosXRol<EUsuario>(Convert.ToInt32(Param.query));

         jsonR.rows = jsonR.resultArray<EUsuario>(eRol.ColumnSet(), listUsuario);
         return Json(jsonR);
      }

      [HttpPost]
      public JsonResult GetUsuarios()
      {
         JsonSamNet jsonR = new JsonSamNet();

         IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Usuario));
         EUsuario eUsuario = new EUsuario();
         ICollection<EUsuario> listUsuario = objBO.GetList<EUsuario>(eUsuario);

         jsonR.rows = jsonR.resultArray<EUsuario>(eUsuario.ColumnSetAddUsuario(), listUsuario);
         return Json(jsonR);
      }

      [HttpPost]
      public String UpdateModel(ERol eRol)
      {
         string mensaje = "";
         try
         {
            IBOUpdate objBOU = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(SYBOMnt.Rol));

            eRol.IdPc = Session[ConstSessionVar.NAMEPCCLIENT].ToString();
            eRol.IdUserTk = Session[ConstSessionVar.USERID].ToString();
            eRol.FeRegistro = DateTime.Now;
            eRol.DsDescripcionRol = eRol.DsDescripcionRol == null ? string.Empty : eRol.DsDescripcionRol; 
           
            if (eRol.EntityState == EntityState.Deleted)
            {
               eRol.StAnulado = ConstFlagEstado.ACTIVADO;
               objBOU.DeleteData(eRol);
               mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Eliminados Correctamente", eRol.IdRol.ToString());
            }
            else
            {
               eRol.StAnulado = ConstFlagEstado.DESACTIVADO;
               string[] coderesult = objBOU.UpdateData(eRol);

               mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Guardados Correctamente", coderesult != null ? coderesult[0] : eRol.IdRol.ToString());
            }

         }
         catch
         {
            mensaje = CreateMessage(ConstTipoMessage.ERROR, "Ocurrio un Error durante la operación, Consulte con su Administrador.", eRol.IdRol.ToString());
         }

         return mensaje;
      }

   }
}
