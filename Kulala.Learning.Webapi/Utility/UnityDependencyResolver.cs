using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace Kulala.Learning.Webapi.Utility
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _UnityContainer = null;
        public UnityDependencyResolver(IUnityContainer container)
        {
            _UnityContainer = container;
        }

        public IDependencyScope BeginScope()//Scope
        {
            return new UnityDependencyResolver(this._UnityContainer.CreateChildContainer());
        }

        public void Dispose()
        {
            this._UnityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this._UnityContainer.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._UnityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}