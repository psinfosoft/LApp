using AutoMapper;
using DAL.DB;
using LegalApp.App_Start;
using LegalApp.Common;
using LegalApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegalApp.Areas.Subscriber.Controllers
{
    [CustomAuth(Roles = Common.ApplicationRole.Subscriber)]
    public class DashboardController : Controller
    {
        // GET: Subscriber/Dashboard
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult GetAllLawyersBySubscriberID(string SubscriberID)
        {
            var SID = Convert.ToInt64(Encryption.DecryptQueryString(SubscriberID.ToString()));
            var resultSubscriber = Mapper.Map<List<EntityLawyer>>(DLLawyer.GetAllLawyersBySubscriberID(SID));
            return Json(resultSubscriber, JsonRequestBehavior.AllowGet);
        }
    }
}