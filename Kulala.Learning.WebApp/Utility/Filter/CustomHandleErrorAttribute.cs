using Kulala.Learning.Common.Model;
using Kulala.Learning.WebApp.Utility.CustomResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.Filter
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private Logger logger = new Logger(typeof(CustomHandleErrorAttribute));
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var httpContext = filterContext.HttpContext;


            if (!filterContext.ExceptionHandled)//异常没有被处理
            {
                Exception exception = filterContext.Exception;
                logger.Error($"在响应{httpContext.Request.Url.AbsoluteUri}时出现异常，异常信息: {filterContext.Exception.Message}");

                if (httpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new NewtonJsonResult(
                                new AjaxResult()
                                {
                                    Result = DoResult.Failed,
                                    DebugMessage = exception.Message,
                                    RetValue = "",
                                    PromptMsg = "发生错误，请联系管理员"
                                });
                }
                else
                {
                    filterContext.Result = new ViewResult//断路器
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
                filterContext.ExceptionHandled = true;
            }
        }
    }
}