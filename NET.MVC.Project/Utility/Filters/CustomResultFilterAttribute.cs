using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("before rendering view");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("after rendering view");
        }
    }
}
