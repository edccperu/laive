using System;
using System.Web;
using System.Web.Optimization;

namespace LAIVE.V1
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/baseScript").Include(
                     "~/Scripts/jquery.js",
                     "~/Scripts/jquery-migrate.js",
                     "~/Scripts/jquery-ui/jquery-ui.js",
                     "~/Scripts/jquery.layout.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/jquery.smallipop.js",
                        "~/Scripts/flexigrid.js",
                        "~/Scripts/jquery.tokeninput.js",
                        "~/Scripts/plugins/jquery.purr.js",
                        "~/Scripts/plugins/zebra_datepicker.js",
                        "~/Scripts/plugins/jquery.tree.js",
                        "~/Scripts/plugins/jquery.navgoco.js",
                        "~/Scripts/plugins/tableExport.js",
                        "~/Scripts/plugins/jquery.base64.js",
                        "~/Scripts/plugins/jquery.inputmask.js",
                        "~/Scripts/plugins/jquery.inputmask.regex.extensions.js",
                        "~/Scripts/plugins/jquery.inputmask.numeric.extensions.js",
                        "~/Scripts/plugins/jquery.immybox.js",
                        "~/Content/icheck/icheck.js",
						      "~/Scripts/plugins/jquery.fileDownload.js",
                        "~/Scripts/jquery.timeline.js",
                        "~/Scripts/samnet.general.script-{version}.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/fonts/BebasNeue-webfont.css",
                        "~/Scripts/jquery-ui/jquery-ui.css", 
                        "~/Content/jquery.smallipop.css", 
                        "~/Content/flexigrid.css",
                        "~/Content/token-input-facebook.css",
                        "~/Content/ui.switchbutton.css",
                        "~/Content/metallic.css",
                        "~/Content/tree.css",
                        "~/Content/jquery.navgoco.css",
                        "~/Content/immybox.css",
                        "~/Content/icheck/skins/all.css",
                        "~/Content/font-awesome.css",
                        "~/Content/elusive/elusive.css",
                        "~/Content/jquery.timeline.css",
                        "~/Content/site.css"
                        ));


            //Style Login 
            bundles.Add(new StyleBundle("~/Content/StyleLogin").Include(
                        "~/Content/entypo/css/entypo.css",
                        "~/Content/bootstrap.css",
                        "~/Content/laive-login.css"
                       ));

            //Script Login 
            bundles.Add(new ScriptBundle("~/bundles/ScriptLogin").Include(
                       "~/Scripts/jquery.js",
                       "~/Scripts/plugins/TweenMax.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/plugins/joinable.js",
                       "~/Scripts/plugins/resizeable.js",
                       "~/Scripts/jquery.validate.js",
                       "~/Scripts/laive-login.js"
                       ));


        }
    }
}