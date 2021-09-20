using Kulala.Learning.Common.Model;
using Kulala.Learning.WebApp.Utility.CustomResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.Filter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (httpContext.Session["CurrentUser"] == null
                || !(httpContext.Session["CurrentUser"] is CurrentUser))
            {
                if (!httpContext.Request.IsAjaxRequest())
                {
                    httpContext.Session["CurrentUrl"] = httpContext.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult("~/Fourth/Login");
                }
                else
                {
                    filterContext.Result = new NewtonJsonResult(
                            new AjaxResult()
                            {
                                Result = DoResult.OverTime,
                                DebugMessage = "登陆过期",
                                RetValue = ""
                            });
                }
            }
            else
            {
                //这里有用户，有地址，可以做权限检查
                CurrentUser user = (CurrentUser)httpContext.Session["CurrentUser"];
                return;
            }


        }
    }
}