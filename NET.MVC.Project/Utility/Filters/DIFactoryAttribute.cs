using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.Filters
{
    public class DIFactoryAttribute : Attribute, IFilterFactory
    {
        private Type _type;
        public DIFactoryAttribute(Type type)
        {
            _type = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var result = serviceProvider.GetService(_type);
            return (IFilterMetadata)result;
        }
    }
}
