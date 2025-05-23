using System.Web.Mvc;

namespace LAIVE.V1.Areas.CO
{
   public class COAreaRegistration : AreaRegistration
   {
      public override string AreaName
      {
         get
         {
            return "CO";
         }
      }

      public override void RegisterArea(AreaRegistrationContext context)
      {
         context.MapRoute(
             "CO_default",
             "CO/{controller}/{action}/{id}",
             new { action = "Index", id = UrlParameter.Optional }
         );
      }
   }
}
