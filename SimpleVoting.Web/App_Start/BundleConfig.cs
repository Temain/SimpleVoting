﻿using System.Web;
using System.Web.Optimization;

namespace SimpleVoting.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/semantic")
                .Include("~/Scripts/semantic.js",
                         "~/Scripts/semantic.site.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/voting")
                .Include("~/Scripts/voting/user.js",
                         "~/Scripts/voting/question.js",
                         "~/Scripts/voting/voting.js"));

            bundles.Add(new ScriptBundle("~/bundles/notifications")
                .Include("~/Scripts/noty/options.js",
                         "~/Scripts/noty/noty.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/semantic")
                .Include("~/Content/semantic.css"));

            bundles.Add(new StyleBundle("~/Content/notifications")
                .Include("~/Content/noty/noty.css"));
        }
    }
}
