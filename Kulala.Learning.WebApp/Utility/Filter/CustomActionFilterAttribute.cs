using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Utility.Filter
{
    public class CustomActionFilterAttribute : ActionFilterAttribute 
    {
        private Logger logger = new Logger(typeof(CustomActionFilterAttribute));
        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action method executes.  方法执行前
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.Info("CustomActionFilterAttribute OnActionExecuting");
            filterContext.HttpContext.Response.Write("CustomActionFilterAttribute OnActionExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action method executes.方法执行后
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Info("CustomActionFilterAttribute OnActionExecuted");
            filterContext.HttpContext.Response.Write("CustomActionFilterAttribute OnActionExecuted");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action result executes. result执行前（ExecuteResult）
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            logger.Info("CustomActionFilterAttribute OnResultExecuting");
            filterContext.HttpContext.Response.Write("CustomActionFilterAttribute OnResultExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action result executes. result执行后(ExecuteResult)
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            logger.Info("CustomActionFilterAttribute OnResultExecuted");
            filterContext.HttpContext.Response.Write("CustomActionFilterAttribute OnResultExecuted");
        }
    }

    public class CustomActionClassFilterAttribute : ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomActionFilterAttribute));
        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action method executes.  方法执行前
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.Info("CustomActionClassFilterAttribute OnActionExecuting");
            filterContext.HttpContext.Response.Write("CustomActionClassFilterAttribute OnActionExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action method executes.方法执行后
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Info("CustomActionClassFilterAttribute OnActionExecuted");
            filterContext.HttpContext.Response.Write("CustomActionClassFilterAttribute OnActionExecuted");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action result executes. result执行前（ExecuteResult）
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            logger.Info("CustomActionClassFilterAttribute OnResultExecuting");
            filterContext.HttpContext.Response.Write("CustomActionClassFilterAttribute OnResultExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action result executes. result执行后(ExecuteResult)
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            logger.Info("CustomActionClassFilterAttribute OnResultExecuted");
            filterContext.HttpContext.Response.Write("CustomActionClassFilterAttribute OnResultExecuted");
        }
    }
    public class CustomGlobalActionFilterAttribute : ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomActionFilterAttribute));
        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action method executes.  方法执行前
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.Info("CustomGlobalActionFilterAttribute OnActionExecuting");
            filterContext.HttpContext.Response.Write("CustomGlobalActionFilterAttribute OnActionExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action method executes.方法执行后
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Info("CustomGlobalActionFilterAttribute OnActionExecuted");
            filterContext.HttpContext.Response.Write("CustomGlobalActionFilterAttribute OnActionExecuted");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework before the action result executes. result执行前（ExecuteResult）
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            logger.Info("CustomGlobalActionFilterAttribute OnResultExecuting");
            filterContext.HttpContext.Response.Write("CustomGlobalActionFilterAttribute OnResultExecuting");
        }

        //
        // 摘要:
        //     Called by the ASP.NET MVC framework after the action result executes. result执行后(ExecuteResult)
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            logger.Info("CustomGlobalActionFilterAttribute OnResultExecuted");
            filterContext.HttpContext.Response.Write("CustomGlobalActionFilterAttribute OnResultExecuted");
        }
    }
}