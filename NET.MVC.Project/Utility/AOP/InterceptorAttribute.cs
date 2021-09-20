using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility
{
    public abstract class AbstractInterceptorAttribute: Attribute
    {
        public abstract Action Do(IInvocation invocation, Action action);
    }

    public class LogBeforeAttribute : AbstractInterceptorAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                Console.WriteLine($"before This is {invocation.Method.Name}");
                foreach (var para in invocation.Arguments)
                {
                    Console.WriteLine($"para is {para}");
                }
                Console.WriteLine("**************************************");
                action.Invoke();
            };
        }
    }

    public class MonitorAttribute : AbstractInterceptorAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //真实方法
                action.Invoke();
                stopwatch.Stop();
                Console.WriteLine($"耗时{stopwatch.ElapsedMilliseconds}ms");
            };
        }
    }

    public class LogAfterAttribute : AbstractInterceptorAttribute
    {
        public override Action Do(IInvocation invocation, Action action)
        {
            return () =>
            {
                action.Invoke();
                Console.WriteLine($"After This is {invocation.Method.Name}");
                foreach (var para in invocation.Arguments)
                {
                    Console.WriteLine($"para is {para}");
                }
                Console.WriteLine("**************************************");
            };
        }
    }
}
