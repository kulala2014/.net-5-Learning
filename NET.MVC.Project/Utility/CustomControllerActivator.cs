using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility
{
    public class CustomControllerActivator : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            Console.WriteLine("This is CustomControllerActivator");
            Type controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();

            var controllerInstance = context.HttpContext.RequestServices.GetRequiredService(controllerType);

            CustomControllerExtention.SetPropertyInjection(context, controllerType, controllerInstance);
            CustomControllerExtention.SetMethodInjection(context, controllerType, controllerInstance);

            return controllerInstance;
        }

        public void Release(ControllerContext context, object controller)
        {
           
        }
    }
}
