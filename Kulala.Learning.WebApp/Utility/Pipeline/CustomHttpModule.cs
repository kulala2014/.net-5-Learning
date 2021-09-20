﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Kulala.Learning.WebApp.Utility.Pipeline
{
    public class CustomHttpModule : IHttpModule
    {
        public void Dispose()
        {
           
        }

        public event EventHandler eventHandler;

        public void Init(HttpApplication application)
        {
            // var path =  context.Request.AppRelativeCurrentExecutionFilePath;
            application.BeginRequest += (s, e) => eventHandler?.Invoke(application, EventArgs.Empty);
            //判断请求从哪里过来的，如果是手机端直接跳转到手机端的webpage
            //context.Request.Browser.IsMobileDevice
            //HostingEnvironment.VirtualPathProvider


            //#region 为每一个事件，都注册了一个动作，向客户端输出信息
            //application.AcquireRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "AcquireRequestState        "));
            //application.AuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "AuthenticateRequest        "));
            //application.AuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "AuthorizeRequest           "));
            //application.BeginRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "BeginRequest               "));
            //application.Disposed += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "Disposed                   "));
            //application.EndRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "EndRequest                 "));
            //application.Error += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "Error                      "));
            //application.LogRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "LogRequest                 "));
            //application.MapRequestHandler += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "MapRequestHandler          "));
            //application.PostAcquireRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostAcquireRequestState    "));
            //application.PostAuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostAuthenticateRequest    "));
            //application.PostAuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostAuthorizeRequest       "));
            //application.PostLogRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostLogRequest             "));
            //application.PostMapRequestHandler += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostMapRequestHandler      "));
            //application.PostReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostReleaseRequestState    "));
            //application.PostRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostRequestHandlerExecute  "));
            //application.PostResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostResolveRequestCache    "));
            //application.PostUpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PostUpdateRequestCache     "));
            //application.PreRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PreRequestHandlerExecute   "));
            //application.PreSendRequestContent += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PreSendRequestContent      "));
            //application.PreSendRequestHeaders += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "PreSendRequestHeaders      "));
            //application.ReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "ReleaseRequestState        "));
            //application.RequestCompleted += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "RequestCompleted           "));
            //application.ResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "ResolveRequestCache        "));
            //application.UpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>来自MyCustomModule 的处理，{0}请求到达 {1}</h1><hr>", DateTime.Now.ToString(), "UpdateRequestCache         "));
            //#endregion


        }
    }
}