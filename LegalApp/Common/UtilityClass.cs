using System;
using System.Web.Security;

namespace LegalApp.Common
{
    public class UtilityClass
    {
        #region Cookie Related Classes
        /// <summary>
        /// ReadCookie 
        /// <param name="FieldID"></param>
        /// </summary>
        /// <returns>Id</returns>
        public static string ReadCookie(int FieldID)
        {
            System.Web.HttpCookie ck = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (ck != null)
            {
                System.Web.Security.FormsAuthenticationTicket tkt = System.Web.Security.FormsAuthentication.Decrypt(ck.Value);
                return tkt.UserData.Split(',')[FieldID];
            }
            return null;
        }

        public static long UserID()
        {
            return Convert.ToInt64(LegalApp.Common.UtilityClass.ReadCookie(Convert.ToInt32(Helper.Enums.CookiesIndex.LoginId)));
        }

        public static string UserName()
        {
            return LegalApp.Common.UtilityClass.ReadCookie(Convert.ToInt32(Helper.Enums.CookiesIndex.UserName));
        }
        #endregion
    }
}