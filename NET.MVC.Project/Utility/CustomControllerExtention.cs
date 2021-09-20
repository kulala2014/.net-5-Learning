using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility
{
    public class CustomControllerExtention
    {
        public static object SetPropertyInjection(ControllerContext context, Type controllerType, object controllerInstance)
        {
            foreach (var prop in controllerType.GetProperties().Where(p => p.IsDefined(typeof(InjectionAttribute))))
            {
                Type propType = prop.PropertyType;
                object pInstance = context.HttpContext.RequestServices.GetRequiredService(propType);
                prop.SetValue(controllerInstance, pInstance);
            }
            return controllerInstance;
        }

        public static object SetMethodInjection(ControllerContext context, Type controllerType, object controllerInstance)
        {
            foreach (var method in controllerType.GetMethods().Where(p => p.IsDefined(typeof(InjectionAttribute))))
            {
                List<object> parameters = new List<object>();
                foreach (var prop in method.GetParameters())
                {
                    Type propType = prop.ParameterType;
                    object pInstance = context.HttpContext.RequestServices.GetRequiredService(propType);
                    parameters.Add(pInstance);
                }
                method.Invoke(controllerInstance, parameters.ToArray());

            }
            return controllerInstance;
        }
    }
}
