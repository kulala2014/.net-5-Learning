using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace NET.MVC.Project.Utility.AOP
{
    public class CustomInterceptor : StandardInterceptor
    {
        /// <summary>
        /// 调用前的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine($"调用前的拦截器，方法名是: {invocation.Method.Name}");//获取当前执行的方法名
        }


        /// <summary>
        /// 拦截方法返回时 调用的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PerformProceed(IInvocation invocation)
        {
            Action action = () => base.PerformProceed(invocation);

            if (invocation.Method.IsDefined(typeof(AbstractInterceptorAttribute), true))
            {
                foreach (var attribute in invocation.Method.GetCustomAttributes<AbstractInterceptorAttribute>())
                {
                    action = attribute.Do(invocation, action);
                }//前--后--前后
            }

            action.Invoke();

        }

        /// <summary>
        /// 调用后的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("调用后的拦截器，方法名是：{0}。", invocation.Method.Name);
        }
    }
}
