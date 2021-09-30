using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class CustomAlwaysRunResultFilterAttribute : Attribute, IAlwaysRunResultFilter
    {

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("试图渲染前，执行的方法");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("试图渲染后，执行的方法");
        }
    }
}
