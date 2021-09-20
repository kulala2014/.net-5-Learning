using Kulala.Learning.Common.Extension;
using Kulala.Learning.Common.ImageHelper;
using Kulala.Learning.WebApp.Utility;
using Kulala.Learning.WebApp.Utility.Filter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Controllers
{
    [CustomAuthorize]
    public class FourthController : Controller
    {
        // GET: Fourth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string name, string password, string verify)
        {
            var result = HttpContext.Login(name, password, verify);
            if (result == UserManager.LoginResult.Success)
            {
                if (HttpContext.Session["CurrentUrl"] != null)
                {
                    string url = HttpContext.Session["CurrentUrl"].ToString();
                    base.HttpContext.Session.Remove("CurrentUrl");
                    return base.Redirect(url);
                }
                else
                    return Redirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("failed", result.GetRemark());
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            HttpContext.Session["CheckCode"] = code;// session识别用户，为单一用户有效
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//返回 FileContentResult图片
        }

        [AllowAnonymous]

        public void Verify()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            HttpContext.Session["CheckCode"] = code;// session识别用户，为单一用户有效
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            Response.ContentType = "image/gif";
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            HttpContext.UserLogout();
            return RedirectToAction("Index", "Home");
        }
    }
}