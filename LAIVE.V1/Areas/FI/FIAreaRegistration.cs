using System.Web.Mvc;

namespace LAIVE.V1.Areas.FI
{
   public class FIAreaRegistration : AreaRegistration
   {
      public override string AreaName
      {
         get
         {
            return "FI";
         }
      }

      public override void RegisterArea(AreaRegistrationContext context)
      {
         context.MapRoute(
             "FI_default",
             "FI/{controller}/{action}/{id}",
             new { action = "Index", id = UrlParameter.Optional }
         );
      }
   }
}
