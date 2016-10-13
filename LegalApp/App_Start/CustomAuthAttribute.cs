using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace LegalApp.App_Start
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            System.Web.HttpCookie ck = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (ck != null)
            {                
                bool ValidUser = false;
                var lstAttr = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.CustomAttributes;
                foreach (var attr in lstAttr)
                {
                    if (attr.NamedArguments[0].TypedValue.Value.ToString() == LegalApp.Common.UtilityClass.ReadCookie(Convert.ToInt32(Helper.Enums.CookiesIndex.UserTypeID)).ToString())
                        ValidUser = true;
                }

                if(!ValidUser)
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "Login",
                        area = "Subscriber"
                    }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Login",
                    area = "Subscriber"
                }));
            }
        }
    }
}