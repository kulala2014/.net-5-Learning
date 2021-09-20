using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.AOP
{
    /// <summary>
    /// AOP扩展类
    /// </summary>
    public static class AopExtension
    {
        public static object AOP(this object t, Type interfaceType)
        {
            ProxyGenerator generator = new ProxyGenerator();
            CustomInterceptor interceptor = new CustomInterceptor();
            t = generator.CreateInterfaceProxyWithTarget(interfaceType, t, interceptor);
            return t;
        }

    }
}
