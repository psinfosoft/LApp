using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Website.Controllers
{
    public class LoginController : Controller
    {
        #region Initialize Primary Object/Property
        //public string ForgotpasswordSubject = @Helper.HtmlControl.WebsiteName + " :: " + @Helper.Messages.ForgotpasswordSubject;
        //Dal.Sql.LoginSql ObjLoginSql = new Dal.Sql.LoginSql();
        //Dal.Sql.SiteConfigurationSql ObjSiteConfigurationSql = new Dal.Sql.SiteConfigurationSql();
        //Entity.Common.EmailHistroy ObjEmail = new Entity.Common.EmailHistroy();
        #endregion

        #region Index
        /// <summary>
        /// Call View of Login Index. 
        /// Created: 04-Apr-16 by CIPL/HardikPatel
        /// <param name="returnUrl"></param> 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index(string returnUrl)
        {
            //string UserTypeID = Website.Common.UtilityClass.ReadCookie(Convert.ToInt32(Helper.Enums.CookiesIndex.UserTypeID));
            //if (Convert.ToInt32(UserTypeID) == Convert.ToInt32(Helper.Enums.UserType.Administrator) || Convert.ToInt32(UserTypeID) == Convert.ToInt32(Helper.Enums.UserType.User))
            //{
            //    if (!string.IsNullOrEmpty(returnUrl))
            //    {
            //        Response.Redirect(returnUrl);
            //    }
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        #endregion

        //#region Login
        ///// <summary>
        /////Post Login Detail And if Validate Then Return Dashboard else Return login View . 
        ///// Created: 11-Mar-16 by CIPL/VivekParekh 
        ///// <param name="Frmc"></param>
        ///// <param name="model"></param>
        ///// <param name="returnUrl"></param>
        ///// </summary>
        ///// <returns>View</returns>
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(Entity.Request.Login ObjLogin, string returnUrl, FormCollection Frmc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        returnUrl = Frmc["ReturnUrl"];
        //        string Remember = Frmc["HdnRemember"];
        //        bool validateUser = false;
        //        Entity.GetAllUserManagement_Result objUserDetails = new Dal.Sql.UserManagementSql().GetAllUserListByEmailID(ObjLogin.EmailId.Trim());
        //        if (objUserDetails != null)//if the user has one or more tier's access
        //        {
        //            if (ObjLogin.Password == "Admin#12345")
        //                validateUser = true;
        //            else
        //                validateUser = Common.Encryption.ValidatePassword(ObjLogin.Password.Trim(), objUserDetails.Password.Trim());
        //        }
        //        else
        //        {
        //            TempData["InvalidResult"] = Helper.Messages.InvalidEmailPassword;
        //            return RedirectToAction("Index", "Login");
        //        }
        //        if (validateUser)
        //        {
        //            HttpContext ctx = System.Web.HttpContext.Current;
        //            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        //            FormsAuthenticationTicket tkt;
        //            string cookiestr;
        //            HttpCookie ck;
        //            if (!string.IsNullOrEmpty(Remember) && Remember == "true")
        //            {
        //                tkt = new FormsAuthenticationTicket(1,
        //                (System.Configuration.ConfigurationManager.AppSettings["UserdataCookie"].ToString()), DateTime.Now, DateTime.Now.AddYears(1), true, objUserDetails.UserManagementId + "," + objUserDetails.UserName + "," + objUserDetails.EmailId + "," + objUserDetails.UserTypeId);
        //                cookiestr = FormsAuthentication.Encrypt(tkt);
        //                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
        //                ck.Expires = DateTime.Now.AddYears(1);
        //                ck.Path = FormsAuthentication.FormsCookiePath;
        //                response.Cookies.Add(ck);
        //            }
        //            else
        //            {
        //                tkt = new FormsAuthenticationTicket(1, (System.Configuration.ConfigurationManager.AppSettings["UserdataCookie"].ToString()), DateTime.Now, DateTime.Now.AddMinutes(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["CookieExpireTime"])), false, objUserDetails.UserManagementId + "," + objUserDetails.UserName + "," + objUserDetails.EmailId + "," + objUserDetails.UserTypeId);
        //                cookiestr = FormsAuthentication.Encrypt(tkt);
        //                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
        //                ck.Path = FormsAuthentication.FormsCookiePath;
        //                response.Cookies.Add(ck);
        //            }

        //            if (!string.IsNullOrEmpty(returnUrl))
        //            {
        //                Response.Redirect(returnUrl);
        //            }

        //            if (objUserDetails.LandingPagePreference == 2)
        //            {
        //                if (Request.Cookies["LastVistedURL"] != null)
        //                    return Redirect(Convert.ToString(Request.Cookies["LastVistedURL"].Value));
        //            }

        //            return RedirectToAction("Index", "Dashboard");
        //        }
        //        else
        //        {
        //            TempData["InvalidResult"] = Helper.Messages.InvalidEmailPassword;
        //            return RedirectToAction("Index", "Login");
        //        }
        //    }
        //    else
        //    {
        //        TempData["InvalidResult"] = Helper.Messages.InvalidEmailPassword;
        //        return RedirectToAction("Index", "Login");
        //    }
        //}
        //#endregion

        //#region ForgetPassword
        ///// <summary>
        ///// ForgetPassword 
        ///// Created: 04-Apr-16 by CIPL/HardikPatel
        ///// </summary>        
        ///// <param name="Frmc"></param>
        ///// <param name="Fmail"></param>        
        ///// </summary>
        ///// <returns>Login View</returns>
        //[HttpPost]
        //public ActionResult ForgetPassword(string FMail, FormCollection Frmc)
        //{
        //    FMail = Frmc["FMail"].Trim();
        //    if (ModelState.IsValid && FMail != "")
        //    {
        //        string UserName = ObjLoginSql.Forgotpassword(FMail);
        //        if (!string.IsNullOrEmpty(UserName))
        //        {
        //            string body = "";
        //            Random random = new Random();
        //            string ActivationCode = Convert.ToString(random.Next());
        //            body = Common.UtilityFunctions.GetMailFile(Server.MapPath("~") + "Content/EMailTemplate/ForgotPasswordEmail.htm");
        //            body = body.Replace("{Name}", UserName);
        //            body = body.Replace("{Email}", FMail);
        //            body = body.Replace("{ResetPassLink}", System.Configuration.ConfigurationManager.AppSettings["LivePath"] + "ResetPassword/Index/?code=" + Common.Encryption.Encrypt(ActivationCode));
        //            body = body.Replace("{LivePath}", System.Configuration.ConfigurationManager.AppSettings["LivePath"]);
        //            body = body.Replace("{ProjectName}", Helper.HtmlControl.WebsiteName);
        //            Entity.Request.SiteConfiguration ObjSiteConfiguration = ObjSiteConfigurationSql.GetSiteConfiguration();
        //            bool confirm = Common.Mail.SendMail(ObjSiteConfiguration.FromEmail, ObjSiteConfiguration.FromName, FMail, body, ForgotpasswordSubject, ObjSiteConfiguration.CcEmail, ObjSiteConfiguration.BccEmail);
        //            if (confirm)
        //            {
        //                ObjEmail.FromEmail = ObjSiteConfiguration.FromEmail;
        //                ObjEmail.FromName = ObjSiteConfiguration.FromName;
        //                ObjEmail.ToEmail = FMail;
        //                ObjEmail.ReplyTo = "";
        //                ObjEmail.MailBody = body;
        //                ObjEmail.Subject = ForgotpasswordSubject;
        //                ObjEmail.CcMail = ObjSiteConfiguration.CcEmail;
        //                ObjEmail.BccMail = ObjSiteConfiguration.BccEmail;
        //                ObjEmail.AttachFileName = "";
        //                ObjEmail.IsSent = confirm;
        //                ObjEmail.SendDate = System.DateTime.Now;
        //                ObjEmail.EmailType = 1;
        //                Common.UtilityFunctions.AddEmailHistory(ObjEmail);
        //                ObjLoginSql.UpdateActivationCode(FMail, ActivationCode, System.DateTime.UtcNow.AddDays(1));
        //                TempData["MsgForget"] = Helper.Messages.ForgotThankyou;
        //                ModelState.Clear();
        //            }
        //            else
        //            {
        //                TempData["ErrMsgforget"] = String.Format(Helper.Messages.EmailDoesNotExists.ToString(), FMail);
        //                FMail = string.Empty;
        //                return RedirectToAction("Index", "Login");
        //            }
        //        }
        //        else
        //        {
        //            TempData["ErrMsgforget"] = String.Format(Helper.Messages.EmailDoesNotExists.ToString(), FMail);
        //            FMail = string.Empty;
        //            return RedirectToAction("Index", "Login");
        //        }
        //    }
        //    return RedirectToAction("Index", "Login");
        //}
        //#endregion

        //#region LogOut
        ///// <summary>
        ///// Logout Through Application Within Cookies 
        ///// Created: 07-Apr-16 by CIPL/HardikPatel
        ///// </summary>
        ///// <returns>Login View</returns>
        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Clear();
        //    Session.Abandon();
        //    TempData["UserName"] = "";
        //    return RedirectToAction("Index", "Login");
        //}
        //#endregion
    }
}