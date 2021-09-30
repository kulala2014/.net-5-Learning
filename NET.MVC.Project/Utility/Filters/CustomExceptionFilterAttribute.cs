using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NET.MVC.Project.Utility.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilterAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {

            if (context.HttpContext.Request.IsAjaxRequest())
            {
                //return ajax result
                context.Result = new  JsonResult(new 
                {
                    Success = false,
                    Message = context.Exception.Message
                });
            }
            else
            {
                var result = new ViewResult//断路器
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
                };
                result.ViewData.Add("Exception", context.Exception.Message);
                context.Result = result;
            }
            context.ExceptionHandled = true;
        }
    }
}
