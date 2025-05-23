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
    public class UsuariosController : SamcontrollerBase
    {
        //private static ICollection<ETablaGenDet> _dataProvider;
        private NodeTreeView _nodeTreeView = new NodeTreeView();

        void SetComponetValue()
        {
            IBOQuery objBOGrupo = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Grupo));
            EGrupo eGrupo = new EGrupo();
            ViewBag.listGrupo = objBOGrupo.GetList<EGrupo>(eGrupo);
        }

        [HttpGet]
        public PartialViewResult Index()
        {
            //_dataProvider = null;
            IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Usuario));
            EUsuario eUsuario = new EUsuario();
            var Usuario = objBO.GetList<EUsuario>(eUsuario);
            ViewBag.TotalRows = Usuario.Count;
            return PartialView("Index", Usuario);
        }

        [HttpGet]
        public PartialViewResult NuevoUsuario(EntityState entityState)
        {
            return PartialView("NuevoUsuario");
        }

        [HttpPost]
        public JsonResult GetBandejaNuevoUsuario(FlexigridParamSamNet Param)
        {

            string strAdPath = "LDAP://" + WebConfigurationManager.AppSettings[ConstSistema.APSET_AD_LDAP];

            DirectoryEntry entry = new DirectoryEntry(strAdPath);
            DirectorySearcher search = new DirectorySearcher(entry);

            search.Filter = "(objectCategory=person)";
            search.PropertiesToLoad.Add("cn");
            search.PropertiesToLoad.Add("objectGUID");
            search.PropertiesToLoad.Add("objectSID");
            search.PropertiesToLoad.Add("samAccountName");
            search.PropertiesToLoad.Add("givenname");
            search.PropertiesToLoad.Add("sn");

            SearchResultCollection results = search.FindAll();
            ICollection<UserActiveDirectory> collectionUser = new List<UserActiveDirectory>();

            UserActiveDirectory userActiveDirectory = new UserActiveDirectory();
            foreach (SearchResult r in results)
            {
                if(r.Properties["samaccountname"].Count > 0)
                    userActiveDirectory.idLogon = r.Properties["samaccountname"][0].ToString();
                if (r.Properties["givenname"].Count > 0)
                    userActiveDirectory.dsNombres = r.Properties["givenname"][0].ToString();
                else
                    userActiveDirectory.dsNombres = "";

                if (r.Properties["sn"].Count > 0)
                    userActiveDirectory.dsApellidos = r.Properties["sn"][0].ToString();
                else
                    userActiveDirectory.dsApellidos = "";
                if (userActiveDirectory.dsNombres != "")
                    collectionUser.Add(userActiveDirectory);
                userActiveDirectory = new UserActiveDirectory();
            }

            collectionUser = collectionUser.OrderBy(node => node.dsApellidos).ToList();

            JsonSamNet jsonR = new JsonSamNet();
            jsonR.rows = jsonR.resultArray<UserActiveDirectory>(userActiveDirectory.ColumnSet(), collectionUser);

            return Json(jsonR);
        }

        [HttpGet]
        public PartialViewResult GetNewUserForEditModel(string idLogon, string dsNombres, string dsApellidos)
        {
            //List<EMenuPage> listMenu;

            EMenuPage eMenuPage = new EMenuPage();
            EUsuario eUsuario = new EUsuario();
            SYBOQry.IUsuario objBOUser = (SYBOQry.IUsuario)WCFHelper.GetObject<SYBOQry.IUsuario>(typeof(SYBOQry.Usuario));

            eUsuario.IdLogon = idLogon.Replace("\n","").Trim();
            eUsuario = (EUsuario)objBOUser.GetByKeyXIdLogon(eUsuario);

            if (eUsuario == null)
            {
                eUsuario = new EUsuario();
                //IBOQuery objBO = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.MenuPage));
                //listMenu = objBO.GetList<EMenuPage>(eMenuPage).ToList();

                ViewBag.EntityState = (int)EntityState.Added;
                eUsuario.EntityState = EntityState.Added;
                eUsuario.IdLogon = idLogon.Replace("\n", "").Trim();
                eUsuario.DsNombres = dsNombres.Replace("\n","").Trim() + " " + dsApellidos.Replace("\n","").Trim();

            }
            else
            {
                //SYBOQry.IMenuPage objIMenuPage = (SYBOQry.IMenuPage)WCFHelper.GetObject<SYBOQry.IMenuPage>(typeof(SYBOQry.MenuPage));
                //listMenu = objIMenuPage.GetListXidRol<EMenuPage>(0).ToList();

                ViewBag.EntityState = (int)EntityState.Modified;
                eUsuario.EntityState = EntityState.Modified;
            }

            //NodeTreeView nodeTreeView = new NodeTreeView();

            //nodeTreeView.id = ConstDefaultValue.ROOTMENU;
            //nodeTreeView.text = "SAMNET";
            //nodeTreeView.value = ConstDefaultValue.ROOTMENU;
            //nodeTreeView.ChildNodes = GetTreeView(listMenu, ConstDefaultValue.ROOTMENU);
            //nodeTreeView.showcheck = false;
            //nodeTreeView.checkstate = 0;
            //nodeTreeView.hasChildren = true;
            //nodeTreeView.isexpand = true;
            //nodeTreeView.complete = true;

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //ViewBag.JsonMenuList = serializer.Serialize(nodeTreeView);

            ViewBag.BackPage = "NuevoUsuario";

            SetComponetValue();

            return PartialView("EditModel", eUsuario);
        }

        [HttpGet]
        public PartialViewResult GetEditModel(string IdUser, EntityState entityState)
        {
            //List<EMenuPage> listMenu;

            //EMenuPage eMenuPage = new EMenuPage();
            EUsuario eUsuario = new EUsuario();
            eUsuario.IdUser = IdUser;
            IBOQuery objBOUser = (IBOQuery)WCFHelper.GetObject<IBOQuery>(typeof(SYBOQry.Usuario));
            eUsuario = (EUsuario)objBOUser.GetByKey(eUsuario);

            if (eUsuario != null)
            {
                //SYBOQry.IMenuPage objIMenuPage = (SYBOQry.IMenuPage)WCFHelper.GetObject<SYBOQry.IMenuPage>(typeof(SYBOQry.MenuPage));
                //listMenu = objIMenuPage.GetListXidRol<EMenuPage>(0).ToList();

                ViewBag.EntityState = (int)entityState;
                eUsuario.EntityState = entityState;
                //NodeTreeView nodeTreeView = new NodeTreeView();

                //nodeTreeView.id = ConstDefaultValue.ROOTMENU;
                //nodeTreeView.text = "SAMNET";
                //nodeTreeView.value = ConstDefaultValue.ROOTMENU;
                //nodeTreeView.ChildNodes = GetTreeView(listMenu, ConstDefaultValue.ROOTMENU);
                //nodeTreeView.showcheck = false;
                //nodeTreeView.checkstate = 0;
                //nodeTreeView.hasChildren = true;
                //nodeTreeView.isexpand = true;
                //nodeTreeView.complete = true;

                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //ViewBag.JsonMenuList = serializer.Serialize(nodeTreeView);
                ViewBag.BackPage = "Index";
            }
            
            //SetComponetValue();

            return PartialView("EditModel", eUsuario);
        }

        //public List<NodeTreeView> GetTreeView(List<EMenuPage> list, string idPadre)
        //{
        //    List<Laive.Entity.Sy.EMenuPage> query = list.Where(fruit => (fruit.IdPadre == idPadre)).OrderBy(fruit => fruit.NuOrden).ToList();
        //    if (query.Count == 0)
        //        return null;

        //    List<NodeTreeView> listNode = new List<NodeTreeView>();

        //    foreach (EMenuPage eMenuPage in query)
        //    {
        //        NodeTreeView nodeTreeView = new NodeTreeView();

        //        nodeTreeView.id = eMenuPage.IdMenuPage;
        //        nodeTreeView.text = eMenuPage.DsMenuPage;
        //        nodeTreeView.value = eMenuPage.IdMenuPage;
        //        nodeTreeView.ChildNodes = GetTreeView(list, eMenuPage.IdMenuPage);
        //        nodeTreeView.showcheck = true;
        //        nodeTreeView.checkstate = eMenuPage.StateCheck;
        //        nodeTreeView.hasChildren = eMenuPage.DsController == "";
        //        nodeTreeView.isexpand = true;
        //        nodeTreeView.complete = true;

        //        listNode.Add(nodeTreeView);
        //    }

        //    return listNode;
        //}

        [HttpPost]
        public String UpdateModel(EUsuario Usuario)
        {
            string mensaje = "";
            try
            {
                IBOUpdate objBOU = (IBOUpdate)WCFHelper.GetObject<IBOUpdate>(typeof(SYBOMnt.Usuario));

                Usuario.IdPc = Session[ConstSessionVar.NAMEPCCLIENT].ToString();
                Usuario.IdUserTk = Session[ConstSessionVar.USERID].ToString();
                Usuario.FeRegistro = DateTime.Now;

                if (Usuario.EntityState == EntityState.Deleted)
                {
                    Usuario.StAnulado = ConstFlagEstado.ACTIVADO;
                    objBOU.DeleteData(Usuario);
                    mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Eliminados Correctamente", Usuario.IdUser);
                }
                else
                {
                    Usuario.StAnulado = ConstFlagEstado.DESACTIVADO;
                    string[] coderesult = objBOU.UpdateData(Usuario);

                    mensaje = CreateMessage(ConstTipoMessage.CORRECTO, "Datos Guardados Correctamente", coderesult != null ? coderesult[0] : Usuario.IdUser);
                }

            }
            catch 
            {
                mensaje = CreateMessage(ConstTipoMessage.ERROR,"Ocurrio un Error durante la operación, Consulte con su Administrador.", Usuario.IdUser);
            }

            return mensaje;
        }
    }
}
