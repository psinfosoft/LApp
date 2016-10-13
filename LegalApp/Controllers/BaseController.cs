using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class BaseController : Controller
    {
        //#region Encrypt/DecryptId
        ///// <summary>
        ///// Return Encrypted Value.
        ///// Created: 06-Apr-16 by CIPL/HardikPatel
        ///// <param name="PlainText"></param>
        ///// </summary>
        ///// <returns>Single JsonString</returns>
        //public ActionResult Encrypted(string PlainText)
        //{
        //    return Json(Common.Encryption.Encrypt(Convert.ToString(PlainText)));
        //}

        ///// <summary>
        ///// EncryptQueryStringId
        ///// Created: 06-Apr-16 by CIPL/HardikPatel
        ///// <param name="PlainText"></param>
        ///// </summary>
        ///// <returns>Encrypted String</returns>
        //[HttpGet]
        //public ActionResult EncryptQueryStringId(string id)
        //{
        //    var MasterId = Common.Encryption.EncryptQueryString(id);
        //    return Json(MasterId, JsonRequestBehavior.AllowGet);
        //}
        //#endregion
    }
}