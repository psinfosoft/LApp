using AutoMapper;
using DAL;
using LegalApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LegalApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GetSubscriberByEmailID_Result, EntitySubscriber>().ReverseMap();
                cfg.CreateMap<GetAllLawyersBySubscriberID_Result, EntityLawyer>().ReverseMap();
            });          
          

        }
    }
}
