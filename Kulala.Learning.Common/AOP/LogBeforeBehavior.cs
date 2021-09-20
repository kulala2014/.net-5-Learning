using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Kulala.Learning.AOP
{
    /// <summary>
    /// 不需要特性
    /// </summary>
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..Start.");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..  End.");
            return getNext().Invoke(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
