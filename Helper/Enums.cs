using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Enums
    {
        #region CookiesIndex
        public enum CookiesIndex
        {
            LoginId = 0,
            UserName = 1,
            EmailID = 2,
            UserTypeID = 3
        }
        #endregion

        #region MessageType
        /// <summary>
        /// Enum for Message Type
        /// </summary>
        public enum MessageType
        {
            success = 0,
            info = 1,
            warning = 2,
            danger = 3
        }
        #endregion
        #region UserType
        /// <summary>
        /// Enum for Message Type
        /// </summary>
        public enum UserType
        {
            Subscriber = 1,
            Lawyer = 2         
        }
        #endregion

    }
}
