﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Unity;

namespace Kulala.Learning.WebApp.Utility
{
    public class KulalaControllerFactory: DefaultControllerFactory
    {
        private Logger logger = new Logger(typeof(KulalaControllerFactory));
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            logger.Info($"{nameof(KulalaControllerFactory)} is called");

            IUnityContainer container = IOCFactory.GetContainer();
            return controllerType == null? null : (IController)container.Resolve(controllerType);
            //return base.GetControllerInstance(requestContext, controllerType);
        }
    }

    public class CustomAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}