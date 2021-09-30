using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        private static Dictionary<string, object> _Cache = new();

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new Exception("dasfsaf");
            var key = context.HttpContext.Request.Path;
            if (_Cache.TryGetValue(key, out object result))
            {
                context.Result = (IActionResult)result;
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

            var key = context.HttpContext.Request.Path;
            _Cache[key] = context.Result;

        }
    }


    public class CustomAsyncResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        private static Dictionary<string, object> _Cache = new();
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var key = context.HttpContext.Request.Path;
            if (_Cache.TryGetValue(key, out object result))
            {
                context.Result = (IActionResult)result;
            }
            else
            {
                var executedContext = await next.Invoke();//执行构造函数 

                _Cache[key] = executedContext.Result;

            }

        }
    }
}
