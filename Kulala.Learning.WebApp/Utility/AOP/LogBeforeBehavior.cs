using Kulala.Learning.WebApp.Utility;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Kulala.Learning.AOP
{
    /// <summary>
    /// 不需要特性
    /// </summary>
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        private Logger logger = new Logger(typeof(LogAfterBehavior));
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //Session 
            logger.Info($"{input.MethodBase.Name} LogBeforeBehavior..Start.");
            foreach (ParameterInfo item in input.Inputs)
            {
                logger.Info($"{item.Name}：{Newtonsoft.Json.JsonConvert.SerializeObject(item)}" );
            }
            logger.Info($"{input.MethodBase.Name} LogBeforeBehavior..  End.");
            return getNext().Invoke(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
