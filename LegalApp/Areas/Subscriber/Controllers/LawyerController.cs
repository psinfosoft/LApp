using LegalApp.App_Start;
using LegalApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegalApp.Areas.Subscriber.Controllers
{
    [CustomAuth(Roles = Common.ApplicationRole.Subscriber)]
    public class LawyerController : Controller
    {
        // GET: Subscriber/Lawyer
        public ActionResult AddUpdate()
        {
            return View(new EntityLawyer());
        }
    }
}