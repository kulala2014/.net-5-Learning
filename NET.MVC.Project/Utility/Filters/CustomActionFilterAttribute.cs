using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger<CustomActionFilterAttribute> _logger;
        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(x => x.GetType().Equals(typeof(AllowAnonymousAttribute))))
            {
                return;
            }
            var key = context.HttpContext.Request.Path;
            _logger.LogInformation($"Before action:{ key}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var key = context.HttpContext.Request.Path;
            _logger.LogInformation($"Before action:{ key}");
        }
    }

    public class CustomAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly ILogger<CustomActionFilterAttribute> _logger;
        public CustomAsyncActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var key = context.HttpContext.Request.Path;
            _logger.LogInformation($"Before action:{ key}");

            await next.Invoke();

            _logger.LogInformation($"Before action:{ key}");
        }
    }
}
