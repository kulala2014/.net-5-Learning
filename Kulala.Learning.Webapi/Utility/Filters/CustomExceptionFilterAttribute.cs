using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace Kulala.Learning.Webapi.Utility.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常发生后(没有被catch)，会进到这里
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //actionExecutedContext.Response. 可以获取很多信息,日志一下
            Console.WriteLine(actionExecutedContext.Exception.Message);//日志一下
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                System.Net.HttpStatusCode.OK, new
                {
                    Result = false,
                    Msg = "出现异常，请联系管理员",
                    //Value=
                });//创造一个返回
            //base.OnException(actionExecutedContext);
            //ExceptionHandler
        }
    }
}