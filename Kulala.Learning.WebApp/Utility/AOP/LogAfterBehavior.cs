using Kulala.Learning.WebApp.Utility;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Kulala.Learning.AOP
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        private Logger logger = new Logger(typeof(LogAfterBehavior));
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);

            logger.Info($"{input.MethodBase.Name} LogAfterBehavior..Start.");
            foreach (var item in input.Inputs)
            {
                logger.Info(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }
            logger.Info($"{input.MethodBase.Name} LogAfterBehavior..  End.");
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
