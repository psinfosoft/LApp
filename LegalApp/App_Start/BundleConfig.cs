﻿using System.Web;
using System.Web.Optimization;

namespace LegalApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Content/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/bootstrap.js",
                      "~/Content/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/bundles/KendoAllCss").Include(
                                        "~/Content/Css/kendo.common-bootstrap.min.css",
                                        "~/Content/Css/kendo.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/KendoAllJs").Include(
                                       "~/Content/Scripts/kendo.all.min.js",
                                       "~/Content/Scripts/kendo.aspnetmvc.min.js"));

        }
    }
}