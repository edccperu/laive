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
    public class LECargarInformacionController : SamcontrollerBase
    {
        //
        // GET: /CO/LECargarInformacion/

        public PartialViewResult Index()
        {
            return PartialView();
        }

    }
}
