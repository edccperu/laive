using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAIVE.V1.Areas.FI.Controllers
{
    public class GenerarArchivoController : Controller
    {
       [HttpGet]
       public PartialViewResult Index()
       {
          return PartialView();
       }



      
    }
}
