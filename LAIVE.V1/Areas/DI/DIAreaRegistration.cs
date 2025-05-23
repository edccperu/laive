using System.Web.Mvc;

namespace LAIVE.V1.Areas.DI
{
   public class DIAreaRegistration : AreaRegistration
   {
      public override string AreaName
      {
         get
         {
            return "DI";
         }
      }

      public override void RegisterArea(AreaRegistrationContext context)
      {
         context.MapRoute(
             "DI_default",
             "DI/{controller}/{action}/{id}",
             new { action = "Index", id = UrlParameter.Optional }
         );
      }
   }
}
