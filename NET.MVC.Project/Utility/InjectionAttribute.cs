using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method|AttributeTargets.Field)]
    public class InjectionAttribute: Attribute
    {
    }
}
