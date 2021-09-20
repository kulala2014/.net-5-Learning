using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Kulala.Learning.AOP
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);

            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..Start.");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..  End.");
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
